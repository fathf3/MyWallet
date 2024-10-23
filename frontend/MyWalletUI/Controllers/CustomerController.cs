using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstractions;
using DtoLayer.Dtos.CustomerDtos;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly IValidator<Customer> _validator;
        public CustomerController(ICustomerService customerService, IMapper mapper, IValidator<Customer> validator)
        {
            _customerService = customerService;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllCustomers();

            return View(customers);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerDto createCustomerDto)
        {
            var map =  _mapper.Map<Customer>(createCustomerDto);
            var result = await _validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await _customerService.CreateCustomerAsync(createCustomerDto);

                return RedirectToAction("Index", "Customer");
            }
            result.AddModelState(this.ModelState);
            return View(createCustomerDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            var map = _mapper.Map<UpdateCustomerDto>(customer);

            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCustomerDto updateCustomerDto)
        {
            var map = _mapper.Map<Customer>(updateCustomerDto);
            var result = await _validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await _customerService.UpdateCustomerAsync(updateCustomerDto);
                return RedirectToAction("Index", "Customer");
            }
            result.AddModelState(this.ModelState);
            return View(updateCustomerDto);
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return RedirectToAction("Index", "Customer");
        }
        public async Task<IActionResult> Active(int id)
        {
            await _customerService.ActiveCustomerAsync(id);
            return RedirectToAction("Index", "Customer");
        }
        public async Task<IActionResult> Passive(int id)
        {
            await _customerService.PassiveCustomerAsync(id);
            return RedirectToAction("Index", "Customer");
        }
    }
}
