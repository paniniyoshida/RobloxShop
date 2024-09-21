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
    public class PromocodeService : IPromocodeService
    {
        private readonly IPromocodeRepository _promocodeRepository;

        public PromocodeService(IPromocodeRepository promocodeRepository)
        {
            _promocodeRepository = promocodeRepository;
        }
        public Promocode Add(Promocode entity)
        {
            return _promocodeRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _promocodeRepository?.Delete(id);
        }

        public Promocode Get(int id)
        {
            return _promocodeRepository.Get(id);
        }

        public List<Promocode> GetAll()
        {
            return _promocodeRepository.GetAll();
        }

        public Promocode Update(Promocode entity)
        {
            return _promocodeRepository.Update(entity);
        }
    }
}
