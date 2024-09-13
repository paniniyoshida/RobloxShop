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
    public class PaymentProviderService : IPaymentProviderService
    {

        private readonly IPaymentProviderRepository _paymentProviderRepository;

        public PaymentProviderService(IPaymentProviderRepository repository)
        {
            _paymentProviderRepository = repository;
        }
        public PaymentProvider Add(PaymentProvider entity)
        {
            return _paymentProviderRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _paymentProviderRepository.Delete(id);
        }

        public PaymentProvider Get(int id)
        {
            return _paymentProviderRepository.Get(id);
        }

        public List<PaymentProvider> GetAll()
        {
            return _paymentProviderRepository.GetAll();
        }

        public PaymentProvider Update(PaymentProvider entity)
        {
            return _paymentProviderRepository.Update(entity);
        }
    }
}
