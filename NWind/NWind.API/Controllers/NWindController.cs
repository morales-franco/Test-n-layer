using NWind.Business;
using NWind.Entities;
using NWind.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NWind.API.Controllers
{
    public class NWindController : ApiController, IService
    {
        [HttpPost]
        public Categories CreateCategory(Categories newCategory)
        {
            var BL = new CategoryBusiness();
            var NewCategory = BL.Create(newCategory);
            return NewCategory;
        }
        [HttpPost]
        public Products CreateProduct(Products newProduct)
        {
            var BL = new ProductsBusiness();
            var NewProduct = BL.Create(newProduct);
            return NewProduct;
        }
        [HttpGet]
        public bool DeleteProduct(int ID)
        {
            var BL = new ProductsBusiness();
            var Result = BL.Delete(ID);
            return Result;
        }
        [HttpGet]
        public List<Products> FilterProductsByCategoryID(int ID)
        {
            var BL = new ProductsBusiness();
            var Result = BL.FilterByCategoryID(ID);
            return Result;
        }

        [HttpGet]
        public Products RetrieveProductByID(int ID)
        {
            var BL = new ProductsBusiness();
            var Result = BL.RetrieveByID(ID);
            return Result;
        }
        [HttpPost]
        public bool UpdateProduct(Products productToUpdate)
        {
            var BL = new ProductsBusiness();
            var Result = BL.Update(productToUpdate);
            return Result;
        }
    }
}
