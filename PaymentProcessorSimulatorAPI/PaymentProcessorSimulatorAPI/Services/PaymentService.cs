using PaymentApi.Models;

namespace PaymentApi.Services
{
    public class PaymentService : IPaymentService
    {
        private static readonly List<Payment> _payments = new();

        public Payment CreatePayment(Payment payment)
        {
            _payments.Add(payment);
            return payment;
        }

        public Payment? GetPayment(Guid id)
        {
            return _payments.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _payments;
        }
    }
}