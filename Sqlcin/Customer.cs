using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sqlcin
{
    public class Customer
    {
        public Customer(int id, string name, string surname)
        {
            Id = id;
            this.name = name;
            this.surname = surname;
        }
        public Customer()
        {
            
        }

        public int Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        public List<Customer> GetAll(Expression<Func<Customer,bool>> filter = null)
        {

            using (Class1 context = new Class1())
            {
                return filter == null ? context.Set<Customer>().ToList() :
                    context.Set<Customer>().Where(filter).ToList();
            }


        }
        public void add(Customer entity)
        {
            using (Class1 nC = new Class1())
            {
                var addedEntity = nC.Entry(entity);

                addedEntity.State = EntityState.Added;

                nC.SaveChanges();

            }
        }
    }

}
