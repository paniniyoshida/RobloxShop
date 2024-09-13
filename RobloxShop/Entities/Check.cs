using RobloxShop.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Entities
{
    public class Check : IEntity
    {
        public int Id { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public List<CheckPosition> CheckPositions { get; set; }

        public DateTime Date { get; set; }

        public int? PromocodeID { get; set; }

        public Promocode? Promocode { get; set; }
    }
}
