using Microsoft.EntityFrameworkCore;
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
    public class ProductCartRepository : IProductCartRepository
    {
        public ProductCart Add(ProductCart entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<ProductCart> addedEntity = shopContext.ProductCarts.Add(entity);

            shopContext.SaveChanges();

            return addedEntity.Entity;
        }

        public void Delete(int id)
        {
            using ShopContext shopContext = new ShopContext();

            ProductCart productCart = new ProductCart()
            {
                Id = id
            };

            shopContext.ProductCarts.Remove(productCart);

            shopContext.SaveChanges();
        }

        public ProductCart Get(int id)
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.ProductCarts.Include(x => x.ProductCartItems).Include(x => x.User).FirstOrDefault(p => p.Id == id);
        }

        public List<ProductCart> GetAll()
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.ProductCarts.Include(x => x.ProductCartItems).Include(x => x.User).ToList();
        }

        public ProductCart Update(ProductCart entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<ProductCart> updatedEntity = shopContext.ProductCarts.Update(entity);

            shopContext.SaveChanges();

            return updatedEntity.Entity;
        }
    }
}
