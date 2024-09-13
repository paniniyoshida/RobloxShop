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
    public class ProductCartService : IProductCartService
    {
            
        private readonly IProductCartRepository _productCartRepository;

        public ProductCartService(IProductCartRepository repository)
        {
            _productCartRepository = repository;
        }

        public ProductCart Add(ProductCart entity)
        {
            return _productCartRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _productCartRepository.Delete(id);
        }

        public ProductCart Get(int id)
        {
            return _productCartRepository.Get(id);
        }

        public List<ProductCart> GetAll()
        {
            return _productCartRepository.GetAll();
        }

        public ProductCart Update(ProductCart entity)
        {
            return _productCartRepository.Update(entity);
        }
    }
}
