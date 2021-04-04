using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _ICategoryDal;

        public CategoryManager(ICategoryDal iCategoryDal)
        {
            _ICategoryDal = iCategoryDal;
        }
        
        
        
        IDataResult<List<Category>> ICategoryService.GetAll()
        {
            return new SuccessDataResult<List<Category>>(_ICategoryDal.GetAll());
        }

        IDataResult<Category> ICategoryService.GetById(int id)
        {
            return new SuccessDataResult<Category>(_ICategoryDal.Get(c => c.CategoryId == id));
        }
    }
}
