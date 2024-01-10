using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo2
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts();

        public void InsertProduct(string Name, double Price, int CategoryID);

        public void UpdateProduct(int newProductID, string newName, double newPrice, int newCategoryID);

        public void DeleteProduct(int ProductID);

    }
}
