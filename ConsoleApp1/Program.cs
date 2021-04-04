using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

            //var = IDataResult
            // productManager.GetAll().Data ====> list of product döndürür
            var result = productManager.GetAll(); // =>>> IDataResult döndürür . Data
            foreach(var a in productManager.GetAll().Data)
            {
                Console.WriteLine(a.ProductName);

            }







            if (productManager.GetAll().Success)
            {
                
                foreach (var product in productManager.GetAll().Data)
                {
                    
                    Console.WriteLine(product.ProductId+"    >>>    "+product.ProductName);
                }
                Console.WriteLine(productManager.GetAll().Message);
            }
            else
            {
                Console.WriteLine(productManager.GetAll().Message);

            }
            
            
            
            
            
            
            //foreach (var item in productManager.GetAll().Data)
            //{

                
               //Console.WriteLine(item.UnitPrice+" --- "+item.ProductName);
                //Console.Write(item.ProductName+" -- ");
                //Console.Write(item.UnitsInStock + " -- ");
                //Console.Write(item.UnitPrice + " -- ");
                //Console.WriteLine();

                //Console.WriteLine(item.ProductName+" --> "+item.UnitPrice);
                //Product managerdaki methodlarla EfProductdalın methodları arasındaki fark ne
                //productname getireceği şeyi nasıl anlıyor.
            //}

        }
    }
}
