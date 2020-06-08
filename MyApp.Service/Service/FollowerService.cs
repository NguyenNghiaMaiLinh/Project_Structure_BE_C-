using AutoMapper;
using MyApp.Core.Constaint;
using MyApp.Core.Data.Infrastructure;
using MyApp.Core.Repository;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service.Service
{
  public  class FollowerService : IFollowerService
    {
        private readonly IFollowerRepository _repository;
        private readonly IRegisterRepository _registerRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FollowerService(IUnitOfWork unitOfWork, IMapper mapper, IFollowerRepository followerRepository, IRegisterRepository registerRepository, IRecipeRepository recipeRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = followerRepository;
            _registerRepository = registerRepository;
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public BaseViewModel<FollowerViewPage> follow(FollowerCreateViewPage request)
        {
            var entity = _repository.checkExsist(request.Author, request.Follower);
            if(entity != null)
            {
                return new BaseViewModel<FollowerViewPage>
                {
                    Code = MessageConstants.FOLLOWER_EXISTED,
                    Description = ErrMessageConstants.FOLLOWER_ALREADY_EXISTED,
                    Data = null,
                    StatusCode = HttpStatusCode.PreconditionFailed
                };
            }
            entity.SetDefaultInsertValue(_repository.GetCurrentUserId());
            entity.FollowerId = request.Follower;
            entity.AuthorId = request.Author;
            entity.IsDelete = false;
            _repository.Add(entity);
            Save();
            return new BaseViewModel<FollowerViewPage>
            {
                Code = null,
                Description = null,
                Data = _mapper.Map<FollowerViewPage>(entity),
                StatusCode = HttpStatusCode.OK
            };
        }

        public BaseViewModel<PagingResult<FollowerViewPage>> getAllFollowerByAuthor()
        {
            var result = new BaseViewModel<PagingResult<FollowerViewPage>>();
            var list = new List<FollowerViewPage>();
            var followers = _repository.getALlFollowerByAuthor(_repository.GetCurrentUserId()).ToList();
            if (followers == null || followers.Count == 0)
            {
                result.Description = MessageConstants.NO_RECORD;
                result.Code = MessageConstants.NO_RECORD;
            }
            else
            {
                foreach (var item in followers)
                {
                    var entity = _repository.GetById(item.FollowerId);
                    var data = _mapper.Map<FollowerViewPage>(entity);
                    data.NumberRecipe = _recipeRepository.getAllRecipeByAuthor(item.FollowerId).Count();
                    data.NumberFollower = _repository.getALlFollowerByAuthor(item.FollowerId).Count();
                    list.Add(data);
                }


                result.Data = new PagingResult<FollowerViewPage>
                {
                    Results = _mapper.Map<IEnumerable<FollowerViewPage>>(list),
                    PageIndex = 0,
                    PageSize = 0,
                    TotalRecords = list.Count()
                };
            }

            return result;
        }

        public BaseViewModel<FollowerViewPage> unfollow(FollowerCreateViewPage request)
        {
            var entity = _repository.checkExsist(request.Author, request.Follower);
            if (entity == null)
            {
                return new BaseViewModel<FollowerViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.PreconditionFailed
                };
            }
            entity.SetDefaultUpdateValue(_repository.GetCurrentUserId());
            entity.IsDelete = true;
            _repository.Update(entity);
            Save();
            return new BaseViewModel<FollowerViewPage>
            {
                Code = null,
                Description = null,
                Data = _mapper.Map<FollowerViewPage>(entity),
                StatusCode = HttpStatusCode.OK
            };
        }
        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
   
}
