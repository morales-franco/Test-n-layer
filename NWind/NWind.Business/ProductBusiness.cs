using NWind.DAL;
using NWind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWind.Business
{
    public class ProductsBusiness
    {

        public Products Create(Products newProducts)
        {
            Products Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Buscar si el nombre de Productso existe
                Products res =
                r.Retrieve<Products>(
                p => p.ProductName == newProducts.ProductName);
                if (res == null)
                {
                    // No existe, podemos crearlo
                    Result = r.Create(newProducts);
                }
                else
                {
                    // Podríamos aquí lanzar una excepción
                    // para notificar que el Productso ya existe.
                    // Podríamos incluso crear una capa de Excepciones
                    // personalizadas y consumirla desde otras
                    // capas.
                }
            }
            return Result;
        }

        public Products RetrieveByID(int ID)
        {
            Products Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Retrieve<Products>(p => p.ProductID == ID);
            }
            return Result;
        }

        public bool Update(Products ProductsToUpdate)
        {
            bool Result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Validar que el nombre de Productso no exista
                Products temp =
                r.Retrieve<Products>
                (p => p.ProductName == ProductsToUpdate.ProductName
                && p.ProductID != ProductsToUpdate.ProductID);
                if (temp == null)
                {
                    // No existe
                    Result = r.Update(ProductsToUpdate);
                }
                else
                {
                    // Podemos implementar alguna lógica para
                    // indicar que no se pudo modificar
                }
            }
            return Result;
        }

        public bool Delete(int ID)
        {
            bool Result = false;
            // Buscar el Productso para ver si tiene existencias
            var Products = RetrieveByID(ID);
            if (Products != null)
            {
                if (Products.UnitsInStock == 0)
                {
                    // Eliminar el Productso
                    using (var r = RepositoryFactory.CreateRepository())
                    {
                        Result = r.Delete(Products);
                    }
                }
                else
                {
                    // Podemos implementar alguna lógica adicional
                    // para indicar que no se pudo eliminar el Productso
                }
            }
            else
            {
                // Podemos implementar alguna lógica
                // para indicar que el Productso no existe
            }
            return Result;
        }

        public List<Products> FilterByCategoryID(int categoryID)
        {
            List<Products> Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Filter<Products>
                (p => p.CategoryID == categoryID);
            }
            return Result;
        }

    }
}
