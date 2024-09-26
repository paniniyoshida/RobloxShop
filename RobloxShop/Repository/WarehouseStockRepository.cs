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
    public class WarehouseStockRepository : IWarehouseStockRepository
    {
        public WarehouseStock Add(WarehouseStock entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<WarehouseStock> addedEntity = shopContext.WarehouseStocks.Add(entity);

            shopContext.SaveChanges();

            return addedEntity.Entity;
        }

        public void Delete(int id)
        {
            using ShopContext shopContext = new ShopContext();

            WarehouseStock warehouseStock = new WarehouseStock()
            {
                Id = id
            };

            shopContext.WarehouseStocks.Remove(warehouseStock);

            shopContext.SaveChanges();
        }

        public WarehouseStock Get(int id)
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.WarehouseStocks.Include(x => x.Product).Include(x => x.Warehouse).FirstOrDefault(w => w.Id == id);
        }

        public List<WarehouseStock> GetAll()
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.WarehouseStocks.Include(x => x.Product).Include(x => x.Warehouse).ToList();
        }

        public WarehouseStock Update(WarehouseStock entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<WarehouseStock> updatedEntity = shopContext.WarehouseStocks.Update(entity);

            shopContext.SaveChanges();

            return updatedEntity.Entity;
        }
    }
}
