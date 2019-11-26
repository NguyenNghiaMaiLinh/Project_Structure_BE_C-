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
            CreateMap<UserViewPage, Account>().ReverseMap();
            CreateMap<Account, UserViewPage>().ReverseMap();

            CreateMap<WorkflowViewPage, Workflow>().ReverseMap();
            CreateMap<Workflow, WorkflowViewPage>().ReverseMap();

            CreateMap<TaskViewPage, Task>().ReverseMap();
            CreateMap<Task, TaskViewPage>().ReverseMap();

            CreateMap<DateTime, string>().ConvertUsing(new DatetimeToStringConverter());
            CreateMap<string, DateTime>().ConvertUsing(new StringToDatetimeConverter());
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
