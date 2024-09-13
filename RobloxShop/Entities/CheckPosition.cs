using RobloxShop.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Entities
{
    public class CheckPosition : IEntity
    {
        public int Id { get; set; }

        public int ProductID { get; set; }

        public Product Product { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public int CheckID { get; set; }

        public Check Check { get; set; }

    }
}
