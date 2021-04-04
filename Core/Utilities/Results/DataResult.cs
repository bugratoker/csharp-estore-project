using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success,string message):base(success,message)
        {
            // data = _IProductDal.GetAll()
            Data = data;
        }

        public DataResult(T data,bool success):base(success)
        {
            Data = data;
        }

        // public List<Product> _IProductDal.GetAll()
        public T Data { get; }
    }
}
