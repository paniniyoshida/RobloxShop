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
    public class CheckPositionRepository : ICheckPositionRepository
    {
        public CheckPosition Add(CheckPosition entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<CheckPosition> addedEntity = shopContext.CheckPositions.Add(entity);

            shopContext.SaveChanges();

            return addedEntity.Entity;
        }

        public void Delete(int id)
        {
            using ShopContext shopContext = new ShopContext();

            CheckPosition checkPosition = new CheckPosition()
            {
                Id = id
            };

            shopContext.CheckPositions.Remove(checkPosition);

            shopContext.SaveChanges();
        }

        public CheckPosition Get(int id)
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.CheckPositions.FirstOrDefault(c => c.Id == id);
        }

        public List<CheckPosition> GetAll()
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.CheckPositions.ToList();
        }

        public CheckPosition Update(CheckPosition entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<CheckPosition> updatedEntity = shopContext.CheckPositions.Update(entity);

            shopContext.SaveChanges();

            return updatedEntity.Entity;
        }
    }
}
