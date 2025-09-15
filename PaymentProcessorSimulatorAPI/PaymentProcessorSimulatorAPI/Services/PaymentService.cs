using PaymentApi.Models;

namespace PaymentApi.Services
{
    public interface IPaymentService
    {
        Payment CreatePayment(Payment payment);
        Payment? GetPayment(Guid id);
        IEnumerable<Payment> GetAllPayments();
    }

    public class PaymentService : IPaymentService
    {
        private static readonly List<Payment> _payments = new();

        public Payment CreatePayment(Payment payment)
        {
            _payments.Add(payment);
            return payment;
        }

        public Payment? GetPayment(Guid id) =>
            _payments.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Payment> GetAllPayments() => _payments;
    }
}