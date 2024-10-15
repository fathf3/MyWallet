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
        private readonly ICategoryService _categoryService;

        public IncomeController(IIncomeService incomeService, IMapper mapper, ICategoryService categoryService)
        {
            _incomeService = incomeService;
            _mapper = mapper;
            _categoryService = categoryService;
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
            var categories = await _categoryService.GetAllActiveCategoriesForIncome();
            
            var map = _mapper.Map<UpdateIncomeDto>(income);
            map.Categories = categories;
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateIncomeDto updateIncomeDto)
        {
            await _incomeService.UpdateIncomeAsync(updateIncomeDto);
            return RedirectToAction("Index", "Income");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllActiveCategoriesForIncome();
            return View(new CreateIncomeDto { Categories = categories});
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
