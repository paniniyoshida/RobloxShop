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
    public class PromocodeRepository : IPromocodeRepository
    {
        public Promocode Add(Promocode entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<Promocode> addedEntity = shopContext.Promocodes.Add(entity);

            shopContext.SaveChanges();

            return addedEntity.Entity;
        }

        public void Delete(int id)
        {
            using ShopContext shopContext = new ShopContext();

            Promocode promocode = new Promocode()
            {
                Id = id
            };

            shopContext.Promocodes.Remove(promocode);

            shopContext.SaveChanges();
        }

        public Promocode Get(int id)
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Promocodes.FirstOrDefault(p => p.Id == id);
        }

        public List<Promocode> GetAll()
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Promocodes.ToList();
        }

        public Promocode Update(Promocode entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<Promocode> updatedEntity = shopContext.Promocodes.Update(entity);

            shopContext.SaveChanges();

            return updatedEntity.Entity;
        }
    }
}
