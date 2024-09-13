using RobloxShop.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Entities
{
    public class WarehouseStock : IEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }

        public int WarehouseID { get; set; }

        public Warehouse Warehouse { get; set; }
        
    }
}
