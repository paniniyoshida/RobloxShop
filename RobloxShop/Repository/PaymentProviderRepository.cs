using Microsoft.EntityFrameworkCore.ChangeTracking;
using RobloxShop.Entities;
using RobloxShop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Repository
{
    public class PaymentProviderRepository : IPaymentProviderRepository
    {
        public PaymentProvider Add(PaymentProvider entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<PaymentProvider> addedEntity = shopContext.PaymentProviders.Add(entity);

            shopContext.SaveChanges();

            return addedEntity.Entity;
        }

        public void Delete(int id)
        {
            using ShopContext shopContext = new ShopContext();

            PaymentProvider paymentProvider = new PaymentProvider()
            {
                Id = id
            };

            shopContext.PaymentProviders.Remove(paymentProvider);

            shopContext.SaveChanges();
        }

        public PaymentProvider Get(int id)
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.PaymentProviders.FirstOrDefault(p => p.Id == id);
        }

        public List<PaymentProvider> GetAll()
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.PaymentProviders.ToList();
        }

        public PaymentProvider Update(PaymentProvider entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<PaymentProvider> updatedEntity = shopContext.PaymentProviders.Update(entity);

            shopContext.SaveChanges();

            return updatedEntity.Entity;
        }
    }
}
