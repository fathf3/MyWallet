using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstractions;
using DtoLayer.Dtos.ExpenseDtos;
using DtoLayer.Dtos.IncomeDtos;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IValidator<Income> _validator;

        public IncomeController(IIncomeService incomeService, IMapper mapper, ICategoryService categoryService, IValidator<Income> validator)
        {
            _incomeService = incomeService;
            _mapper = mapper;
            _categoryService = categoryService;
            _validator = validator;
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
            var map = _mapper.Map<Income>(updateIncomeDto);
            var result = await _validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await _incomeService.UpdateIncomeAsync(updateIncomeDto);
                return RedirectToAction("Index", "Income");
            }
            var categories = await _categoryService.GetAllActiveCategoriesForIncome();
            updateIncomeDto.Categories = categories;
            result.AddModelState(this.ModelState);
            return View(updateIncomeDto);

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
            var map = _mapper.Map<Income>(createIncomeDto);
            var result = await _validator.ValidateAsync(map);
            if (result.IsValid)
            {
               
                await _incomeService.CreateIncomeAsync(createIncomeDto);

                return RedirectToAction("Index", "Income");
            }
            {
                result.AddModelState(this.ModelState);
                var categories = await _categoryService.GetAllActiveCategoriesForIncome();
                createIncomeDto.Categories = categories;
                return View(createIncomeDto);
            }
            
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _incomeService.DeleteIncomeAsync(id);
            return RedirectToAction("Index", "Income");

        }
       
    }
}
