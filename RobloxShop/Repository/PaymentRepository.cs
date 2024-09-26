using Microsoft.EntityFrameworkCore;
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
    public class PaymentRepository : IPaymentRepository
    {
        public Payment Add(Payment entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<Payment> addedEntity = shopContext.Payments.Add(entity);

            shopContext.SaveChanges();

            return addedEntity.Entity;
        }

        public void Delete(int id)
        {
            using ShopContext shopContext = new ShopContext();

            Payment payment = new Payment()
            {
                Id = id
            };

            shopContext.Payments.Remove(payment);

            shopContext.SaveChanges();
        }

        public Payment Get(int id)
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Payments.Include(x => x.Check).Include(x => x.PaymentProvider).FirstOrDefault(p => p.Id == id);
        }

        public List<Payment> GetAll()
        {
            using ShopContext shopContext = new ShopContext();
            return shopContext.Payments.Include(x => x.Check).Include(x => x.PaymentProvider).ToList();
        }

        public Payment Update(Payment entity)
        {
            using ShopContext shopContext = new ShopContext();

            EntityEntry<Payment> updatedEntity = shopContext.Payments.Update(entity);

            shopContext.SaveChanges();

            return updatedEntity.Entity;
        }
    }
}
