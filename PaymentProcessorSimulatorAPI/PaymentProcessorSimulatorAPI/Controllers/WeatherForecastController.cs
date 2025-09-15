using Microsoft.AspNetCore.Mvc;
using PaymentApi.Models;
using PaymentApi.Services;

namespace PaymentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult CreatePayment([FromBody] Payment payment)
        {
            var created = _paymentService.CreatePayment(payment);
            return CreatedAtAction(nameof(GetPayment), new { id = created.Id }, created);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetPayment(Guid id)
        {
            var payment = _paymentService.GetPayment(id);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        [HttpGet]
        public IActionResult GetAllPayments()
        {
            return Ok(_paymentService.GetAllPayments());
        }
    }
}