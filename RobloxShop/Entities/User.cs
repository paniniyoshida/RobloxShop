using RobloxShop.Entities.Enums;
using RobloxShop.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public Role Role { get; set; }

        public DateTime Birthday { get; set; }

    }
}
