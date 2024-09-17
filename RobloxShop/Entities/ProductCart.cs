using RobloxShop.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Entities
{
    public class ProductCart : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public List<ProductCartItem> ProductCartItems { get; set; }
    }
}
