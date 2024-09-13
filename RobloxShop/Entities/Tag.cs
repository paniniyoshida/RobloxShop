using RobloxShop.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Entities
{
    public class Tag : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; }




    }
}
