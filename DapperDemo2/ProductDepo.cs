using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo2
{
    public class ProductDepo : IProductRepo
    {
        private readonly IDbConnection _connection;
        public ProductDepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void InsertProduct(string Name, double Price, int CategoryID)
        {
            _connection.Query<Product>("INSERT INTO products(Name,Price,CategoryID) VALUES (@Name,@Price,@CategoryID);",
                new { Name, Price, CategoryID});
        }

        public void UpdateProduct(int newProductID, string newName, double newPrice, int newCategoryID)
        {
            _connection.Query<Product>("UPDATE products SET Name = @newName, Price = @newPrice, CategoryID = @newCategoryID WHERE ProductID = @newProductID;",
                new { newProductID, newName, newPrice, newCategoryID });
        }

        public void DeleteProduct(int ProductID)
        {
            _connection.Query<Product>("DELETE FROM products WHERE ProductID = @ProductID",
                new { ProductID });
        }
    }
}
