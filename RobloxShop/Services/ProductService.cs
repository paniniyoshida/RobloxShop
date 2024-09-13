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
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public Product Add(Product entity)
        {
            return _productRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public Product Get(int id)
        {
            return _productRepository.Get(id);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product Update(Product entity)
        {
            return _productRepository.Update(entity);
        }
    }
}
