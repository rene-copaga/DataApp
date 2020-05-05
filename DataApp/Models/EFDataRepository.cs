using System.Collections.Generic;
using System.Linq;

namespace DataApp.Models
{
    public class EFDataRepository : IDataRepository
    {
        private EFDatabaseContext context;

        public EFDataRepository(EFDatabaseContext ctx)
        {
            context = ctx;
        }

        //public IQueryable<Product> Products => context.Products;

        public IEnumerable<Product> GetProductsByPrice(decimal minPrice)
        {
            return context.Products.Where(p => p.Price >= minPrice).ToArray();
        }
    }
}
