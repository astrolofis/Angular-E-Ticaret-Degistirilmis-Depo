using API.Core.DbModels;
using API.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace API.Infrastructure.Implements
{
    public class PaymentService : IPaymentService
    {
        public Task<CustomerBasket> CreateOrPaymentIntent(string basketId)
        {
            throw new NotImplementedException();
        }
    }
}
