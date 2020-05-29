using AutoMapper;
using MyApp.Core.Data.DTO;
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
            CreateMap<DateTime, string>().ConvertUsing(new DatetimeToStringConverter());
            CreateMap<string, DateTime>().ConvertUsing(new StringToDatetimeConverter());

            CreateMap<RegisterViewPage, Register>().ReverseMap();
            CreateMap<Register, RegisterViewPage>().ReverseMap();

            CreateMap<CommentViewPage, Comment>().ReverseMap();
            CreateMap<Comment, CommentViewPage>().ReverseMap();

            CreateMap<CommentViewPage, CommentDto>().ReverseMap();
            CreateMap<CommentDto, CommentViewPage>().ReverseMap();

            CreateMap<RecipeCreateViewPage, Recipe>().ReverseMap();
            CreateMap<Recipe, RecipeCreateViewPage>().ReverseMap();

            CreateMap<RecipeViewPage, Recipe>().ReverseMap();
            CreateMap<Recipe, RecipeViewPage>().ReverseMap();

            CreateMap<RecipeUpdateViewPage, Recipe>().ReverseMap();
            CreateMap<Recipe, RecipeUpdateViewPage>().ReverseMap();

            CreateMap<LoginFacebookViewModel, Register>().ReverseMap();
            CreateMap<Register, LoginFacebookViewModel>().ReverseMap();

            CreateMap<DateTime, string>().ConvertUsing(new DatetimeToStringConverter());
            CreateMap<string, DateTime>().ConvertUsing(new StringToDatetimeConverter());
        }

        public class DatetimeToStringConverter : ITypeConverter<DateTime, string>
        {
            public string Convert(DateTime source, string destination, ResolutionContext context)
            {
                return source.ToString("yyyy/MM/dd");
            }
        }
        public class StringToDatetimeConverter : ITypeConverter<string, DateTime>
        {
            public DateTime Convert(string source, DateTime destination, ResolutionContext context)
            {
                return DateTime.ParseExact(source, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }
        }
    }
}
