using System.Collections.Generic;

namespace DataApp.Models
{
    public interface IDataRepository
    {
        Product GetProduct(long id);

        IEnumerable<Product> GetAllProducts();

        void CreateProduct(Product newProduct);

        void UpdateProduct(Product changedProduct);

        void DeleteProduct(long id);
    }
}
