using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal

    {

        List<Product> _products;
        public InMemoryProductDal()
        {

            _products = new List<Product>
            {
                new Product{ProductName="BardakLAR",CategoryId=1,ProductId=1,
                    UnitPrice=15,UnitsInStock=15},
                new Product { ProductName = "Bilgisayar", CategoryId = 2, ProductId = 2,
                    UnitPrice = 15, UnitsInStock = 15 },
                new Product{ProductName="Bardak",CategoryId=1,ProductId=3,
                    UnitPrice=15,UnitsInStock=5},
                new Product{ProductName="Tabak",CategoryId=1,ProductId=4,
                    UnitPrice=15,UnitsInStock=14},
                new Product{ProductName="Telefon",CategoryId=2,ProductId=5,
                    UnitPrice=15,UnitsInStock=45},
                new Product{ProductName="LAMBA",CategoryId=2,ProductId=6,
                    UnitPrice=15,UnitsInStock=0}


            };

        }
        public void add(Product product)
        {
            _products.Add(product);
        }

        public void delete(Product product)
        {
            //LINQ Language Integrated Query
            //Lambda
            Product productTodelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productTodelete);        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllbyCategories(int cat)
        {
            return _products.Where(p => p.CategoryId == cat).ToList();

        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void update(Product product)
        {
            
        }
    }
}
