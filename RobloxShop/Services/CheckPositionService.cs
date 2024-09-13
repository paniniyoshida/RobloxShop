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
    public class CheckPositionService : ICheckPositionService
    {
        private readonly ICheckPositionRepository _checkPositionRepository;

        public CheckPositionService(ICheckPositionRepository repository)
        {
            _checkPositionRepository = repository;
        }
        public CheckPosition Add(CheckPosition entity)
        {
            return _checkPositionRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _checkPositionRepository.Delete(id);
        }

        public CheckPosition Get(int id)
        {
            return _checkPositionRepository.Get(id);
        }

        public List<CheckPosition> GetAll()
        {
            return _checkPositionRepository.GetAll();
        }

        public CheckPosition Update(CheckPosition entity)
        {
            return _checkPositionRepository.Update(entity);
        }
    }
}
