using ASPNetCoreWebAPIClass.Domain.Models.API;
using ASPNetCoreWebAPIClass.Domain.Models.Database;
using AutoMapper;

namespace ASPNetCoreWebAPIClass
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>().ForMember(u => u.Name, opt => opt.MapFrom(x => x.Name)
        )
            .ForMember(u => u.Quantity, opt => opt.MapFrom(x => x.Quantity))
            .ForMember(u => u.Description, opt => opt.MapFrom(x => x.Description))
            .ForMember(u => u.LongDescription, opt => opt.MapFrom(x => x.LongDescription))
            .ForMember(u => u.NormalPrice, opt => opt.MapFrom(x => x.NormalPrice))
            .ForMember(u => u.DiscountPrice, opt => opt.MapFrom(x => x.DiscountPrice))
            .ForMember(u => u.Rating, opt => opt.MapFrom(x => x.Rating));

            CreateMap<ProductResponse, Product>().ForMember(u => u.Name, opt => opt.MapFrom(x => x.Name)
       )
           .ForMember(u => u.Quantity, opt => opt.MapFrom(x => x.Quantity))
           .ForMember(u => u.Description, opt => opt.MapFrom(x => x.Description))
           .ForMember(u => u.LongDescription, opt => opt.MapFrom(x => x.LongDescription))
           .ForMember(u => u.NormalPrice, opt => opt.MapFrom(x => x.NormalPrice))
           .ForMember(u => u.DiscountPrice, opt => opt.MapFrom(x => x.DiscountPrice))
           .ForMember(u => u.Rating, opt => opt.MapFrom(x => x.Rating));




        }
    }
}
