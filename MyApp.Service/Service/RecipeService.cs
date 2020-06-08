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

namespace MyApp.Service.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RecipeService(IUnitOfWork unitOfWork, IMapper mapper, IRecipeRepository recipeRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = recipeRepository;

            _mapper = mapper;
        }
        public BaseViewModel<RecipeViewPage> create(RecipeCreateViewPage request)
        {
            var entity = _mapper.Map<Recipe>(request);
            entity.SetDefaultInsertValue(_repository.GetCurrentUserId());
            _repository.Update(entity);
            Save();

            return new BaseViewModel<RecipeViewPage>
            {
                StatusCode = HttpStatusCode.Created,
                Data = _mapper.Map<RecipeViewPage>(entity)
            };
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
                    StatusCode = HttpStatusCode.PreconditionFailed
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

        public BaseViewModel<PagingResult<RecipeViewPage>> getAllRecipeByAuthor()
        {

            var result = new BaseViewModel<PagingResult<RecipeViewPage>>();

            var data = _repository.getAllRecipeByAuthor(_repository.GetCurrentUserId()).ToList();
            if (data == null || data.Count == 0)
            {
                result.Description = MessageConstants.NO_RECORD;
                result.Code = MessageConstants.NO_RECORD;
            }
            else
            {

                var entity = new List<RecipeViewPage>();
                entity = _mapper.Map<List<RecipeViewPage>>(data);

                result.Data = new PagingResult<RecipeViewPage>
                {
                    Results = _mapper.Map<IEnumerable<RecipeViewPage>>(entity),
                    PageIndex = 0,
                    PageSize = 0,
                    TotalRecords = data.Count()
                };
            }

            return result;
        }

        public BaseViewModel<RecipeViewPage> getRecipeById(string id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return new BaseViewModel<RecipeViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            return new BaseViewModel<RecipeViewPage>
            {
                StatusCode = HttpStatusCode.OK,
                Data = _mapper.Map<RecipeViewPage>(entity)
            };
        }

        public BaseViewModel<RecipeViewPage> update(RecipeUpdateViewPage request)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                return new BaseViewModel<RecipeViewPage>
                {
                    Code = MessageConstants.NOTFOUND,
                    Description = ErrMessageConstants.NOTFOUND,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            _repository.Update(entity);
            Save();

            return new BaseViewModel<RecipeViewPage>
            {
                StatusCode = HttpStatusCode.OK,
                Data = _mapper.Map<RecipeViewPage>(entity)
            };
        }
        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
