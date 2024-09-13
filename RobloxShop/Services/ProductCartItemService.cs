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
    public class ProductCartItemService : IProductCartItemService
    {

        private readonly IProductCartItemRepository _productCartItemRepository;

        public ProductCartItem Add(ProductCartItem entity)
        {
            return _productCartItemRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _productCartItemRepository?.Delete(id); 
        }

        public ProductCartItem Get(int id)
        {
            return _productCartItemRepository.Get(id);
        }

        public List<ProductCartItem> GetAll()
        {
            return _productCartItemRepository.GetAll();
        }

        public ProductCartItem Update(ProductCartItem entity)
        {
            return _productCartItemRepository.Update(entity);
        }
    }
}
