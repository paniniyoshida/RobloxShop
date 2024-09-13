using RobloxShop.Entities;
using RobloxShop.Repository.Interfaces;
using RobloxShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Services
{
    public class WarehouseStockService : IWarehouseStockService
    {
        private readonly IWarehouseStockRepository _warehouseStockRepository;

        public WarehouseStock Add(WarehouseStock entity)
        {
            return _warehouseStockRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _warehouseStockRepository.Delete(id);
        }

        public WarehouseStock Get(int id)
        {
            return _warehouseStockRepository.Get(id);
        }

        public List<WarehouseStock> GetAll()
        {
            return _warehouseStockRepository.GetAll();
        }

        public WarehouseStock Update(WarehouseStock entity)
        {
            return _warehouseStockRepository.Update(entity);
        }
    }
}
