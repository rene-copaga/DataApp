using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
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

        public Product GetProduct(long id)
        {
            return context.Products.Find(id);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            Console.WriteLine("GetAllProducts");
            return context.Products;
        }

        public IEnumerable<Product> GetFilteredProducts(string category = null,
            decimal? price = null)
        {
            IQueryable<Product> data = context.Products;
            if (category != null)
            {
                data = data.Where(p => p.Category == category);
            }
            if (price != null)
            {
                data = data.Where(p => p.Price >= price);
            }
            return data;
        }

        public void CreateProduct(Product newProduct)
        {
            newProduct.Id = 0;
            context.Products.Add(newProduct);
            context.SaveChanges();
            Console.WriteLine($"New Key: {newProduct.Id}");
        }

        public void UpdateProduct(Product changedProduct, Product originalProduct = null)
        {
            if (originalProduct == null)
            {
                originalProduct = context.Products.Find(changedProduct.Id);
            }
            else
            {
                context.Products.Attach(originalProduct);
            }
            
            originalProduct.Name = changedProduct.Name;
            originalProduct.Category = changedProduct.Category;
            originalProduct.Price = changedProduct.Price;

            EntityEntry entry = context.Entry(originalProduct);
            Console.WriteLine($"Entity State: {entry.State}");
            foreach (string p_name in new string[]
                    { "Name", "Category", "Price" })
            {
                Console.WriteLine($"{p_name} - Old: " +
                    $"{entry.OriginalValues[p_name]}, " +
                    $"New: {entry.CurrentValues[p_name]}");
            }

            context.SaveChanges();
        }

        public void DeleteProduct(long id)
        {
            context.Products.Remove(new Product { Id = id });
            context.SaveChanges();
        }
    }
}
