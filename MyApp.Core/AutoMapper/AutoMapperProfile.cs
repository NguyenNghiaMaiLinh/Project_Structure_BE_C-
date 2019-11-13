using AutoMapper;
using MyApp.Core.Data.Entity;
using MyApp.Core.ViewModel.ViewPage;
using System;
using System.Globalization;

namespace MyApp.Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserViewPage, User>().ReverseMap();
            CreateMap<User, UserViewPage>().ReverseMap();

            CreateMap<BannerViewPage, Banner>().ReverseMap();
            CreateMap<Banner, BannerViewPage>().ReverseMap();

            CreateMap<ProductViewPage, Product>().ReverseMap();
            CreateMap<Product, ProductViewPage>().ReverseMap();

            CreateMap<ProductCreateViewPage, Product>().ReverseMap();
            CreateMap<Product, ProductCreateViewPage>().ReverseMap();

            CreateMap<ProductDetailViewPage, Product>().ReverseMap();
            CreateMap<Product, ProductDetailViewPage>().ReverseMap();

            CreateMap<CategoryViewPage, Category>().ReverseMap();
            CreateMap<Category, CategoryViewPage>().ReverseMap();

            CreateMap<DateTime, string>().ConvertUsing(new DatetimeToStringConverter());
            CreateMap<string, DateTime>().ConvertUsing(new StringToDatetimeConverter());
        }
        public class GuidToStringConverter : ITypeConverter<Guid, string>
        {
            public string Convert(Guid source, string destination, ResolutionContext context)
            {
                return source.ToString();
            }
        }
        public class StringToGuidConverter : ITypeConverter<string, Guid>
        {
            public Guid Convert(string source, Guid destination, ResolutionContext context)
            {
                return Guid.Parse(source);
            }
        }
        public class DatetimeToStringConverter : ITypeConverter<DateTime, string>
        {
            public string Convert(DateTime source, string destination, ResolutionContext context)
            {
                return source.ToString("yyyyMMdd");
            }
        }
        public class StringToDatetimeConverter : ITypeConverter<string, DateTime>
        {
            public DateTime Convert(string source, DateTime destination, ResolutionContext context)
            {
                return DateTime.ParseExact(source, "yyyyMMdd", CultureInfo.InvariantCulture);
            }
        }
    }
}
