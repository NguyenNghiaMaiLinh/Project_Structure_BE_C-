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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = categoryRepository;
            _mapper = mapper;
        }

        public BaseViewModel<CategoryViewPage> create(CategoryCreateViewPage request)
        {
            throw new System.NotImplementedException();
        }

        public BaseViewModel<bool> delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public BaseViewModel<PagingResult<CategoryViewPage>> getAllCategory(BasePagingRequestViewModel request)
        {
            throw new System.NotImplementedException();
        }

        public BaseViewModel<CategoryViewPage> update(string id, CategoryUpdateViewPage request)
        {
            throw new System.NotImplementedException();
        }

        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
