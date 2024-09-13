using RobloxShop.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Entities
{
    public class Payment : IEntity
    {
        public int Id { get; set; }

        public int PaymentProviderID { get; set; }

        public PaymentProvider PaymentProvider { get; set; }

        public int CheckID { get; set; }

        public Check Check { get; set; }

    }
}
