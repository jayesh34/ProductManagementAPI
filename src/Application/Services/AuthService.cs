using Application.DTOs;
using Application.Interfaces;


namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IJwtService _jwtService;
   
    private readonly IUnitOfWork _unitOfWork;

   public AuthService(IJwtService jwtService, IUnitOfWork unitOfWork)
{
    _jwtService = jwtService;
    _unitOfWork = unitOfWork;
}

   public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
{
    var user = await _unitOfWork.Users.GetByUsernameAsync(request.Username);

    if (user == null)
        return null;

    if (user.PasswordHash != request.Password)
        return null;

    var accessToken = _jwtService.GenerateAccessToken(user);
    var refreshToken = _jwtService.GenerateRefreshToken();

    user.RefreshTokens.Add(new Domain.Entities.RefreshToken
    {
        Token = refreshToken,
        ExpiryDate = DateTime.UtcNow.AddDays(7),
        IsRevoked = false,
        UserId = user.Id
    });

    await _unitOfWork.SaveChangesAsync();

    return new LoginResponseDto
    {
        AccessToken = accessToken,
        RefreshToken = refreshToken
    };
}

   public async Task<LoginResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request)
{
    var user = await _unitOfWork.Users.GetByRefreshTokenAsync(request.RefreshToken);

    if (user == null)
        return null;

    var oldToken = user.RefreshTokens.First(x => x.Token == request.RefreshToken);

    oldToken.IsRevoked = true;

    var newAccessToken = _jwtService.GenerateAccessToken(user);
    var newRefreshToken = _jwtService.GenerateRefreshToken();

    user.RefreshTokens.Add(new Domain.Entities.RefreshToken
    {
        Token = newRefreshToken,
        ExpiryDate = DateTime.UtcNow.AddDays(7),
        IsRevoked = false,
        UserId = user.Id
    });

    await _unitOfWork.SaveChangesAsync();

    return new LoginResponseDto
    {
        AccessToken = newAccessToken,
        RefreshToken = newRefreshToken
    };
}
}