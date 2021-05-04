using Newtonsoft.Json.Linq;
using Shopping_Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shopping_Cart.Services
{
    public class ProductService : IProductService
    {
        public IList<Product> GetData()
        {
            string url = "https://fakestoreapi.com/products";
            using (var client = new WebClient())
            {
                var content = client.DownloadString(url);
                var list = DeserializeToList<Product>(content);
                return list;
            }
        }


        private IList<T> DeserializeToList<T>(string jsonString)
        {
            var array = JArray.Parse(jsonString);
            IList<T> objectsList = new List<T>();

            foreach (var item in array)
            {
                try
                {
                    // CorrectElements  
                    objectsList.Add(item.ToObject<T>());
                }
                catch
                {

                }
            }

            return objectsList;
        }
    }
}
