using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _IProductDal;
        ICategoryService _categoryService;


       

        public ProductManager(IProductDal iProductDal,ICategoryService categoryService)
        {
            _IProductDal = iProductDal;
            _categoryService = categoryService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        
        public IResult Add(Product product)
        {
            //business
            //validation
            //ValidationTool.Validate(new ProductValidator(), product);
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameIsExist(product.ProductName),CheckIfCategoryLimitExceed());


            if (result != null)
            {

                return result;
            }
            _IProductDal.add(product);
            return new SuccessResult();

        }

        //public interface IDataResult<T>:IResult
        //yukarıdaki T        AŞAĞIDAKİ list<Product>a denk geliyor
        public IDataResult<List<Product>> GetAll()
        {

            if (DateTime.Now.Hour == 4)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Product>>(_IProductDal.GetAll(),Messages.ProductsListed);
        //      return new _IProductDal.GetAll();               DATA
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> (_IProductDal.GetAll(p => p.CategoryId == id));

        }


        public IDataResult<Product> GetById(int Id)
        {
            return new SuccessDataResult<Product>(_IProductDal.Get( p=>p.ProductId==Id));
        }

        public IDataResult<List<Product>>  GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_IProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new  SuccessDataResult<List<ProductDetailDto>>(_IProductDal.GetProductDetails());
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {

            var result = _IProductDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult("Product count of category");

            }
            return new SuccessResult();

        }

        private IResult CheckIfProductNameIsExist(String productName)
        {
            var result = _IProductDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {

                return new ErrorResult("P. Name is exist");
            }
            return new SuccessResult(Messages.ProductAdded);



        }

        private IResult CheckIfCategoryLimitExceed()
        {

            var result = _categoryService.GetAll();
            if (result.Data.Count >= 15)
            {
                return new ErrorResult("limit asildi");
            }
            return new SuccessResult();
        }
       
    }


}
