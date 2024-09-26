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
    public class ProductCartItemRepository : IProductCartItemRepository
    {
        public ProductCartItem Add(ProductCartItem entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<ProductCartItem> addedEntity = shopContext.ProductCartItems.Add(entity);

            shopContext.SaveChanges();

            return addedEntity.Entity;
        }

        public void Delete(int id)
        {
            using ShopContext shopContext = new ShopContext();

            ProductCartItem productCartItem = new ProductCartItem()
            {
                Id = id
            };

            shopContext.ProductCartItems.Remove(productCartItem);

            shopContext.SaveChanges();
        }

        public ProductCartItem Get(int id)
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.ProductCartItems.Include(x => x.Product).Include(x => x.ProductCart).FirstOrDefault(p => p.Id == id);
        }

        public List<ProductCartItem> GetAll()
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.ProductCartItems.Include(x => x.Product).Include(x => x.ProductCart).ToList();
        }

        public ProductCartItem Update(ProductCartItem entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<ProductCartItem> updatedEntity = shopContext.ProductCartItems.Update(entity);

            shopContext.SaveChanges();

            return updatedEntity.Entity;
        }
    }
}
