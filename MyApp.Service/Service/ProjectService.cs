using AutoMapper;
using MyApp.Core.Constaint;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using MyApp.Service.HelperService;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MyApp.Service.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IProjectMembersRepository _projectMembersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper, IProjectRepository projectRepository, IProjectMembersRepository projectMembersRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = projectRepository;
            _projectMembersRepository = projectMembersRepository;
            _mapper = mapper;
        }

        public BaseViewModel<ProjectViewPage> create(ProjectCreateViewPage request)
        {
           
            var entity = new Project();
            entity.SetDefaultInsertValue(_repository.GetUsername());
            entity.ProjectName = request.ProjectName;
            entity.Status = MyEnum.StatusProject.Started;
            entity.IsDelete = false;
            _repository.Add(entity);

            var temp = new ProjectMembers();
            temp.SetDefaultInsertValue(_repository.GetUsername());
            temp.IsDelete = false;
            temp.ProjectId = entity.Id;
            temp.UserId = _repository.GetUsername();
            _projectMembersRepository.Add(temp);

            Save();
            return new BaseViewModel<ProjectViewPage>
            {
                Code = MessageConstants.SUCCESS,
                Description = null,
                StatusCode = HttpStatusCode.Created,
                Data = _mapper.Map<ProjectViewPage>(entity)
            };
        }

        public BaseViewModel<PagingResult<ProjectViewPage>> GetAllProject(BasePagingRequestViewModel request)
        {
            var pageSize = request.PageSize;
            var pageIndex = request.PageIndex;
            var result = new BaseViewModel<PagingResult<ProjectViewPage>>();

            var data = _repository.GetAllProject(pageIndex, pageSize, _repository.GetUsername()).ToList();
            if (data == null || data.Count == 0)
            {
                result.Description = MessageConstants.NO_RECORD;
                result.Code = MessageConstants.NO_RECORD;
            }
            else
            {
                var pageSizeReturn = pageSize;
                if (data.Count < pageSize)
                {
                    pageSizeReturn = data.Count;
                }
                result.Data = new PagingResult<ProjectViewPage>
                {
                    Results = _mapper.Map<IEnumerable<ProjectViewPage>>(data),
                    PageIndex = pageIndex,
                    PageSize = pageSizeReturn,
                    TotalRecords = data.Count()
                };
            }

            return result;
        }

        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
