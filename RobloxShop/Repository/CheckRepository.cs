using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using RobloxShop.Entities;
using RobloxShop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Repository
{
    public class CheckRepository : ICheckRepository
    {
        public Check Add(Check entity)
        {
            using ShopContext shopContext = new ShopContext();

            entity.Date = entity.Date.ToUniversalTime();

            EntityEntry<Check> addedEntity = shopContext.Checks.Add(entity);

            

            shopContext.SaveChanges();

            return addedEntity.Entity;
        }

        public void Delete(int id)
        {
            using ShopContext shopContext = new ShopContext();

            Check check = new Check()
            {
                Id = id
            };

            shopContext.Checks.Remove(check);

            shopContext.SaveChanges();
        }

        public Check Get(int id)
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Checks.Include(x => x.User).Include(x => x.CheckPositions).Include(x => x.Promocode).FirstOrDefault(c => c.Id == id);
        }

        public List<Check> GetAll()
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Checks.Include(x => x.User).Include(x => x.CheckPositions).Include(x => x.Promocode).ToList();
        }

        public Check Update(Check entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<Check> updatedEntity = shopContext.Checks.Update(entity);

            shopContext.SaveChanges();

            return updatedEntity.Entity;
        }
    }
}
