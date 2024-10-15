using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DtoLayer.Dtos.IncomeDtos;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;
        private readonly IMapper _mapper;

        public IncomeController(IIncomeService incomeService, IMapper mapper)
        {
            _incomeService = incomeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var incomes = await _incomeService.GetAllIncomesWithCategory();

            return View(incomes);

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var income = await _incomeService.GetIncomeById(id);
            var map = _mapper.Map<UpdateIncomeDto>(income);
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateIncomeDto updateIncomeDto)
        {
            var income = await _incomeService.UpdateIncomeAsync(updateIncomeDto);

            return RedirectToAction("Index", "Income");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIncomeDto createIncomeDto)
        {
            await _incomeService.CreateIncomeAsync(createIncomeDto);

            return RedirectToAction("Index", "Income");
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _incomeService.DeleteIncomeAsync(id);
            return RedirectToAction("Index", "Income");

        }
       
    }
}
