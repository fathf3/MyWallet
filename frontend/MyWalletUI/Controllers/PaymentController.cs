using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstractions;
using DtoLayer.Dtos.ExpenseDtos;
using DtoLayer.Dtos.IncomeDtos;
using DtoLayer.Dtos.PaymentDtos;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWalletUI.Helper;
using System.Globalization;

namespace MyWalletUI.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        private readonly IValidator<Payment> _validator;
        private readonly ICategoryService _categoryService;
        public PaymentController(IPaymentService paymentService, IMapper mapper, ICustomerService customerService, IValidator<Payment> validator, ICategoryService categoryService)
        {
            _paymentService = paymentService;
            _mapper = mapper;
            _customerService = customerService;
            _validator = validator;
            _categoryService = categoryService;
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
            var customers = await _customerService.GetAllActiveCustomers();
            var monthYearList = TimeHelper.GetMonthYearList();
            ViewBag.MonthYearList = monthYearList;
            var map = _mapper.Map<UpdatePaymentDto>(payment);
           
            var categories = await _categoryService.GetAllActiveCategoriesForIncome();
            map.Customers = customers;
            map.Categories = categories;
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdatePaymentDto updatePaymentDto)
        {
            updatePaymentDto.Status = true;
            var map = _mapper.Map<Payment>(updatePaymentDto);
            var result = await _validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await _paymentService.UpdatePaymentAsync(updatePaymentDto);
                return RedirectToAction("Index", "Payment");
            }
            var customers = await _customerService.GetAllActiveCustomers();
            var categories = await _categoryService.GetAllActiveCategoriesForIncome();
            updatePaymentDto.Customers = customers;
            updatePaymentDto.Categories = categories;
            result.AddModelState(this.ModelState);
            return View(updatePaymentDto);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var customers = await _customerService.GetAllActiveCustomers();
            var monthYearList = TimeHelper.GetMonthYearList();
            var categories = await _categoryService.GetAllActiveCategoriesForIncome();
            ViewBag.MonthYearList = monthYearList;
            return View(new CreatePaymentDto { Customers = customers , Categories = categories});
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentDto createPaymentDto)
        {
            createPaymentDto.Status = true;
            var map = _mapper.Map<Payment>(createPaymentDto);
            var result = await _validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await _paymentService.CreatePaymentAsync(createPaymentDto);

                return RedirectToAction("Index", "Payment");
            }
            var customers = await _customerService.GetAllActiveCustomers();
            var categories = await _categoryService.GetAllActiveCategoriesForIncome();
            createPaymentDto.Customers = customers;
            createPaymentDto.Categories = categories;
            result.AddModelState(this.ModelState);
            return View(createPaymentDto);
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _paymentService.DeletePaymentAsync(id);
            return RedirectToAction("Index", "Payment");

        }
        [HttpPost]
        public async Task<JsonResult> AddNewPaymentPeriod()
        {
            await _paymentService.AddMonthlyPayments();
            DateTime date = DateTime.Now; 
            string monthYear = date.ToString("MMMM yyyy"); 
            return Json(new { success = true, message = $"{monthYear} ödeme dönemi için yeni veriler eklendi." });
        }

    }
}
