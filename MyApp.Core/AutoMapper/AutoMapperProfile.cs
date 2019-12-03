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

            CreateMap<UserViewPage, Account>().ReverseMap();
            CreateMap<Account, UserViewPage>().ReverseMap();

            CreateMap<CommentViewPage, Account>().ReverseMap();
            CreateMap<Account, CommentViewPage>().ReverseMap();

            CreateMap<NotificationViewPage, Notification>().ReverseMap();
            CreateMap<Notification, NotificationViewPage>().ReverseMap();

            CreateMap<LoginFacebookViewModel, Account>().ReverseMap();
            CreateMap<Account, LoginFacebookViewModel>().ReverseMap();

            CreateMap<WorkflowViewPage, Workflow>().ReverseMap();
            CreateMap<Workflow, WorkflowViewPage>().ReverseMap();

            CreateMap<WorkflowViewPage, WorkflowDto>().ReverseMap();
            CreateMap<WorkflowDto, WorkflowViewPage>().ReverseMap();

            CreateMap<UserViewModel, Account>().ReverseMap();
            CreateMap<Account, UserViewModel>().ReverseMap();

            CreateMap<TaskViewPage, Task>().ReverseMap();
            CreateMap<Task, TaskViewPage>().ReverseMap();

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
