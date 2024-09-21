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
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        public Warehouse Add(Warehouse entity)
        {
            return _warehouseRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _warehouseRepository?.Delete(id);
        }

        public Warehouse Get(int id)
        {
            return _warehouseRepository.Get(id);
        }

        public List<Warehouse> GetAll()
        {
            return _warehouseRepository.GetAll();
        }

        public Warehouse Update(Warehouse entity)
        {
            return _warehouseRepository.Update(entity);
        }
    }
}
