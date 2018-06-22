using NWind.Service;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using NWind.Entities;
using System.Collections.Generic;

namespace NWind.ProxyService
{
    public class Proxy : IService
    {
        string BaseAddress = "http://localhost:53021";


        public async Task<T> SendPost<T, PostData>(string requestURI, PostData data)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    // URL Absoluto
                    requestURI = BaseAddress + requestURI;
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add
                    (new MediaTypeWithQualityHeaderValue("application/json"));
                    var JSONData = JsonConvert.SerializeObject(data);
                    HttpResponseMessage Response =
                    await Client.PostAsync(requestURI,
                    new StringContent(JSONData.ToString(),
                    Encoding.UTF8, "application/json"));
                    var ResultWebAPI = await Response.Content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<T>(ResultWebAPI);
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                }
            }
            return Result;
        }

        public async Task<T> SendGet<T>(string requestURI)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    requestURI = BaseAddress + requestURI; // URL Absoluto
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                    var ResultJSON = await Client.GetStringAsync(requestURI);
                    Result = JsonConvert.DeserializeObject<T>(ResultJSON);
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                }
            }
            return Result;
        }

        public async Task<Products> CreateProductAsync(Products newProduct)
        {
            return await SendPost<Products, Products>
            ("/api/nwind/createproduct", newProduct);
        }
        public Products CreateProduct(Products newProduct)
        {
            Products Result = null;
            // Ejecutar la tarea en un nuevo hilo
            // para que no se bloquee el hilo síncrono
            // con Wait esperamos la operación asíncrona
            Task.Run(async () => Result =
            await CreateProductAsync(newProduct)).Wait();
            return Result;
        }
        public async Task<Products> RetrieveProductByIDAsync(int ID)
        {
            return await SendGet<Products>($"/api/nwind/RetrieveProductByID/{ID}");
        }
        public Products RetrieveProductByID(int ID)
        {
            Products Result = null;
            Task.Run(async () =>
            Result = await RetrieveProductByIDAsync(ID)).Wait();
            return Result;
        }
        public async Task<bool> UpdateProductAsync(Products productToUpdate)
        {
            return await SendPost<bool, Products>
            ("/api/nwind/UpdateProduct", productToUpdate);
        }
        public bool UpdateProduct(Products productToUpdate)
        {
            bool Result = false;
            Task.Run(async () => Result = await
            UpdateProductAsync(productToUpdate)).Wait();
            return Result;
        }
        public async Task<bool> DeleteProductAsync(int ID)
        {
            return await SendGet<bool>($"/api/nwind/DeleteProduct/{ID}");
        }
        public bool DeleteProduct(int ID)
        {
            bool Result = false;
            Task.Run(async () => Result = await DeleteProductAsync(ID)).Wait();
            return Result;
        }

        public async Task<List<Products>> FilterProductsByCategoryIDAsync(int ID)
        {
            return await SendGet<List<Products>>
            ($"/api/nwind/FilterProductsByCategoryID/{ID}");
        }
        public List<Products> FilterProductsByCategoryID(int ID)
        {
            List<Products> Result = null;
            Task.Run(async () => Result = await
            FilterProductsByCategoryIDAsync(ID)).Wait();
            return Result;
        }
        public async Task<Categories> CreateCategoryAsync(Categories newCategory)
        {
            return await SendPost<Categories, Categories>
            ("/api/nwind/CreateCategory", newCategory);
        }
        public Categories CreateCategory(Categories newCategory)
        {
            Categories Result = null;
            Task.Run(async () => Result = await
            CreateCategoryAsync(newCategory)).Wait();
            return Result;
        }


    }
}
