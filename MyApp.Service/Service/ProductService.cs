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

namespace MyApp.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryProductRepository _categoryProductrepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IProductRepository userRepository, ICategoryProductRepository categoryProductRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = userRepository;
            _categoryProductrepository = categoryProductRepository;
            _mapper = mapper;
        }

        public BaseViewModel<ProductViewPage> create(ProductCreateViewPage request)
        {
            var entity = new Product();
            entity = _mapper.Map<Product>(request);
            entity.SetDefaultInsertValue(_repository.GetUsername());
            entity.IsDelete = false;
            _repository.Add(entity);
            var temp = new CategoryProduct();
            temp.SetDefaultInsertValue(_categoryProductrepository.GetUsername());
            temp.ProductId = entity.Id;
            temp.CategoryId = request.CategoryId;
            _categoryProductrepository.Add(temp);
            return new BaseViewModel<ProductViewPage>
            {
                Code = MessageConstants.SUCCESS,
                Description = MessageConstants.SUCCESS,
                StatusCode = System.Net.HttpStatusCode.OK,
                Data = _mapper.Map<ProductViewPage>(entity)
            };
        }

        public BaseViewModel<PagingResult<ProductViewPage>> GetAllProduct(BasePagingRequestViewModel request)
        {
            var pageSize = request.PageSize;
            var pageIndex = request.PageIndex;
            var result = new BaseViewModel<PagingResult<ProductViewPage>>();

            var data = _repository.GetAll().Where(_ => _.IsDelete == false).ToList();

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
                result.Data = new PagingResult<ProductViewPage>
                {
                    Results = _mapper.Map<IEnumerable<ProductViewPage>>(data),
                    PageIndex = pageIndex,
                    PageSize = pageSizeReturn,
                    TotalRecords = data.Count()
                };
            }

            return result;
        }

        public BaseViewModel<PagingResult<ProductViewPage>> GetAllProductByCategoryId(ProductPagingRequestModel request)
        {
            var pageSize = request.PageSize;
            var pageIndex = request.PageIndex;
            var result = new BaseViewModel<PagingResult<ProductViewPage>>();

            var data = _repository.GetAllProductByCategoryId(request.CategoryId, request.CategoryName, request.Search).ToList();
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
                result.Data = new PagingResult<ProductViewPage>
                {
                    Results = _mapper.Map<IEnumerable<ProductViewPage>>(data),
                    PageIndex = pageIndex,
                    PageSize = pageSizeReturn,
                    TotalRecords = data.Count()
                };
            }

            return result;
        }

        public BaseViewModel<ProductDetailViewPage> GetProductById(string request)
        {
            var entity = new ProductDetailViewPage();
            var product = _repository.GetById(request);
            if (product == null)
            {
                return new BaseViewModel<ProductDetailViewPage>
                {
                    Code = MessageConstants.NO_RECORD,
                    Description = ErrMessageConstants.PRODUCT_NOT_FOUND,
                    Data = null,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }

            entity = _mapper.Map<ProductDetailViewPage>(product);

            entity.CategoryId = _categoryProductrepository.getByProductId(product.Id).CategoryId;
            entity.CategoryName = _categoryProductrepository.getByProductId(product.Id).Name;

            return new BaseViewModel<ProductDetailViewPage>
            {
                Code = MessageConstants.SUCCESS,
                Description = null,
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }

        private void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
