using Shopping_Cart.Models;
using System.Collections.Generic;

namespace Shopping_Cart.Services
{
    public interface IProductService
    {
        IList<Product> GetData();
    }
}