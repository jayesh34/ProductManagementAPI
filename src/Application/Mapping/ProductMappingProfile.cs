using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductResponseDto>();

        CreateMap<CreateProductDto, Product>()
            .ForMember(dest => dest.CreatedOn,
                opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<UpdateProductDto, Product>()
            .ForMember(dest => dest.ModifiedOn,
                opt => opt.MapFrom(_ => DateTime.UtcNow));
    }
}