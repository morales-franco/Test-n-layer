using NWind.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NWind.Service
{
    public interface IService
    {
        Products CreateProduct(Products newProduct);
        Products RetrieveProductByID(int ID);
        bool UpdateProduct(Products productToUpdate);
        bool DeleteProduct(int ID);
        List<Products> FilterProductsByCategoryID(int ID);
        Categories CreateCategory(Categories newCategory);
    }
}
