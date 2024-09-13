using Microsoft.EntityFrameworkCore.ChangeTracking;
using RobloxShop.Entities;
using RobloxShop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Product Add(Product entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<Product> addedEntity = shopContext.Products.Add(entity);

            shopContext.SaveChanges();

            return addedEntity.Entity;
        }

        public void Delete(int id)
        {
            using ShopContext shopContext = new ShopContext();

            Product product = new Product()
            {
                Id = id
            };

            shopContext.Products.Remove(product);

            shopContext.SaveChanges();
        }

        public Product Get(int id)
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAll()
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Products.ToList();
        }

        public Product Update(Product entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<Product> updatedEntity = shopContext.Products.Update(entity);

            shopContext.SaveChanges();

            return updatedEntity.Entity;
        }
    }
}
