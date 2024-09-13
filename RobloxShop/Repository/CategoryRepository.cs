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
    public class CategoryRepository : ICategoryRepository
    {
        public Category Add(Category entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<Category> addedEntity = shopContext.Categories.Add(entity);

            shopContext.SaveChanges();

            return addedEntity.Entity;
        }

        public void Delete(int id)
        {
            using ShopContext shopContext = new ShopContext();

            Category category = new Category()
            {
                Id = id
            };

            shopContext.Categories.Remove(category);

            shopContext.SaveChanges();
        }

        public Category Get(int id)
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public List<Category> GetAll()
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Categories.ToList();
        }

        public Category Update(Category entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<Category> updatedEntity = shopContext.Categories.Update(entity);

            shopContext.SaveChanges();

            return updatedEntity.Entity;
        }
    }
}
