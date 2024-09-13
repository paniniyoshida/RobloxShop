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
    public class UserRepository : IUserRepository
    {
        public User Add(User entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<User> addedEntity = shopContext.Users.Add(entity);

            shopContext.SaveChanges();

            return addedEntity.Entity;
        }

        public void Delete(int id)
        {
            using ShopContext shopContext = new ShopContext();

            User user = new User()
            {
                Id = id
            };

            shopContext.Users.Remove(user);

            shopContext.SaveChanges();
        }

        public User Get(int id)
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Users.ToList();
        }

        public User Update(User entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<User> updatedEntity = shopContext.Users.Update(entity);

            shopContext.SaveChanges();

            return updatedEntity.Entity;
        }
    }
}
