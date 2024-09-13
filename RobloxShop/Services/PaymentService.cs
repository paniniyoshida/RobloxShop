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
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository repository)
        {
            _paymentRepository = repository;
        }
        public Payment Add(Payment entity)
        {
            return _paymentRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _paymentRepository.Delete(id);
        }

        public Payment Get(int id)
        {
            return _paymentRepository.Get(id);
        }

        public List<Payment> GetAll()
        {
            return _paymentRepository.GetAll();
        }

        public Payment Update(Payment entity)
        {
            return _paymentRepository.Update(entity);
        }
    }
}
