using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DtoLayer.Dtos.PaymentDtos;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public PaymentController(IPaymentService paymentService, IMapper mapper, ICustomerService customerService)
        {
            _paymentService = paymentService;
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var payments = await _paymentService.GetAllPaymentWithCustomer();

            return View(payments);

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var payment = await _paymentService.GetPaymentById(id);
            var customers = await _customerService.GetAllCustomers();

            var map = _mapper.Map<UpdatePaymentDto>(payment);
            map.Customers = customers;
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdatePaymentDto updatePaymentDto)
        {
            updatePaymentDto.Status = true;
            
            await _paymentService.UpdatePaymentAsync(updatePaymentDto);
            return RedirectToAction("Index", "Payment");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var customers = await _customerService.GetAllCustomers();
            
            return View(new CreatePaymentDto { Customers = customers });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentDto createPaymentDto)
        {
            createPaymentDto.Status = true;
            await _paymentService.CreatePaymentAsync(createPaymentDto);

            return RedirectToAction("Index", "Payment");
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _paymentService.DeletePaymentAsync(id);
            return RedirectToAction("Index", "Payment");

        }
    }
}
