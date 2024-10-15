using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DtoLayer.Dtos.CustomerDtos;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
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
            await _customerService.CreateCustomerAsync(createCustomerDto);

            return RedirectToAction("Index", "Customer");
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
            await _customerService.UpdateCustomerAsync(updateCustomerDto);
            return RedirectToAction("Index", "Customer");
        }


        public async Task<IActionResult> Delete(int id)
        {

            await _customerService.DeleteCustomerAsync(id);
            return RedirectToAction("Index", "Customer");

        }
    }
}
