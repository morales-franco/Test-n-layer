using NWind.DAL;
using NWind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWind.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCategoryAndProduct();
            Console.Write("Presione <enter> para finalizar");
            Console.ReadLine();
        }

        static void AddCategoryAndProduct()
        {
            Categories c = new Categories()
            {
                CategoryName = "Cereales",
                Description = "Productos de Maíz"
            };
            Products Cereal = new Products
            {
                ProductName = "Cereal",
                UnitsInStock = 0,
                UnitPrice = 15
            };
            c.Products.Add(Cereal);
            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(c);
            }
            Console.WriteLine($"Categoría:{c.CategoryID}, " +
            $"Producto:{Cereal.ProductID}");
        }
    }
}
