using AutoMapper;
using MyApp.Core.Constaint;
using MyApp.Core.Data.Entity;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyApp.Service.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, ICommentRepository commentRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = commentRepository;
        
            _mapper = mapper;
        }

        public Task<BaseViewModel<CommentViewPage>> create(CommentCreateViewPage request)
        {
            throw new System.NotImplementedException();
        }

        public BaseViewModel<bool> delete(string id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return new BaseViewModel<bool>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = false,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            else if (entity.CreateBy != _repository.GetUsername())
            {
                return new BaseViewModel<bool>
                {
                    Code = MessageConstants.FAILURE,
                    Description = ErrMessageConstants.INVALID_PERMISSION,
                    Data = false,
                    StatusCode = HttpStatusCode.PreconditionFailed
                };
            }
            entity.IsDelete = true;
            _repository.Update(entity);
            Save();

            return new BaseViewModel<bool>
            {
                StatusCode = HttpStatusCode.OK,
                Data = true
            };
        }

        public BaseViewModel<PagingResult<CommentViewPage>> getAllComment(CommentPagingRequestViewModel request)
        {
            var pageSize = request.PageSize;
            var pageIndex = request.PageIndex;
            var result = new BaseViewModel<PagingResult<CommentViewPage>>();

            var data = _repository.getAllComment(pageIndex, pageSize, request.TaskId, request.Search).ToList();
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
                var entity = new List<CommentViewPage>();
                entity = _mapper.Map<List<CommentViewPage>>(data);
                foreach (var item in entity)
                {
             
                    item.AvatarPath = _userRepository.GetById(item.Username).AvatarPath;
                }
                result.Data = new PagingResult<CommentViewPage>
                {
                    Results = _mapper.Map<IEnumerable<CommentViewPage>>(entity),
                    PageIndex = pageIndex,
                    PageSize = pageSizeReturn,
                    TotalRecords = data.Count()
                };
            }

            return result;
        }

        public BaseViewModel<CommentViewPage> getCommentById(string id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return new BaseViewModel<CommentViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            return new BaseViewModel<CommentViewPage>
            {
                StatusCode = HttpStatusCode.OK,
                Data = _mapper.Map<CommentViewPage>(entity)
            };
        }



        public BaseViewModel<CommentViewPage> update(CommentUpdateViewPage request)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                return new BaseViewModel<CommentViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            entity.ImageUrl = request.ImageUrl;
            _repository.Update(entity);
            Save();

            return new BaseViewModel<CommentViewPage>
            {
                StatusCode = HttpStatusCode.OK,
                Data = _mapper.Map<CommentViewPage>(entity)
            };
        }
        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
