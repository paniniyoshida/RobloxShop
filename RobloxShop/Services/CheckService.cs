using RobloxShop.Entities;
using RobloxShop.Repository;
using RobloxShop.Repository.Interfaces;
using RobloxShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Services
{
    public class CheckService : ICheckService
    {
        private readonly ICheckRepository _checkRepository;

        public CheckService(ICheckRepository repository)
        {
            _checkRepository = repository;
        }
        public Check Add(Check entity)
        {
            return _checkRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _checkRepository.Delete(id);
        }

        public Check Get(int id)
        {
            return _checkRepository.Get(id);
        }

        public List<Check> GetAll()
        {
           return _checkRepository.GetAll();
        }

        public Check Update(Check entity)
        {
            return _checkRepository.Update(entity);
        }
    }
}
