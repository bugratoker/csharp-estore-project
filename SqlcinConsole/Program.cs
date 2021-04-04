using Sqlcin;
using System;

namespace SqlcinConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            Customer cs1 = new Customer();
            

            foreach (var item in cs1.GetAll())
            {

                if (item.surname.Equals("Toker"))
                {

                    Console.WriteLine(item.surname +" "+item.Id);
                }
            }
            Console.WriteLine("**");
            cs1.add(new Customer(32, "Hilmi", "Isik"));
            foreach (var item in cs1.GetAll())
            {
                Console.WriteLine(item.name+" "+item.surname + " " + item.Id);

            }










        }
    }
}
