using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        //_IProductDal.GetAll() -->> data ,  
        // T data == List<Product> _IProductDal.GetAll() 
        public SuccessDataResult(T data,string message):base(data,true,message){}
        public SuccessDataResult(T data) : base(data, true){}
        public SuccessDataResult(string message) : base(default, true, message) {}
        public SuccessDataResult() : base(default, true) {}
        // data == _IProductDal.GetAll() bu da bana list of product döndürdü 
        //T de zaten List<Product>
        //public SuccessDataResult(Product data) : base(data, true){}

        // productManager.
        // List<Product> _IProductDal.GetAll() alp toker 11, bugra toker 45, toker toker 47
    }
}
