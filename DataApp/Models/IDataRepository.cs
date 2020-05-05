using System.Collections.Generic;

namespace DataApp.Models
{
    public interface IDataRepository
    {
        //IQueryable<Product> Products { get; }
        IEnumerable<Product> GetProductsByPrice(decimal minPrice);
    }
}
