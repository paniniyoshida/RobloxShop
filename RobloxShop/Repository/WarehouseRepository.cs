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
    public class WarehouseRepository : IWarehouseRepository
    {
        public Warehouse Add(Warehouse entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<Warehouse> addedEntity = shopContext.Warehouses.Add(entity);

            shopContext.SaveChanges();

            return addedEntity.Entity;
        }

        public void Delete(int id)
        {
            using ShopContext shopContext = new ShopContext();

            Warehouse warehouse = new Warehouse()
            {
                Id = id
            };

            shopContext.Warehouses.Remove(warehouse);

            shopContext.SaveChanges();
        }

        public Warehouse Get(int id)
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Warehouses.FirstOrDefault(w => w.Id == id);
        }

        public List<Warehouse> GetAll()
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Warehouses.ToList();
        }

        public Warehouse Update(Warehouse entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<Warehouse> updatedEntity = shopContext.Warehouses.Update(entity);

            shopContext.SaveChanges();

            return updatedEntity.Entity;
        }
    }
}
