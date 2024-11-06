using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstractions;
using DtoLayer.Dtos.CustomerDtos;
using DtoLayer.Dtos.ExpenseDtos;
using DtoLayer.Dtos.IncomeDtos;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.Controllers
{
    [Authorize]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IValidator<Expense> _validator;

        public ExpenseController(IExpenseService expenseService, IMapper mapper, ICategoryService categoryService, IValidator<Expense> validator)
        {
            _expenseService = expenseService;
            _mapper = mapper;
            _categoryService = categoryService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var expenses = await _expenseService.GetAllExpensesWithCategory();

            return View(expenses);

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var expense = await _expenseService.GetExpenseById(id);
            var categories = await _categoryService.GetAllActiveCategoriesForExpense();

            var map = _mapper.Map<UpdateExpenseDto>(expense);
            map.Categories = categories;
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateExpenseDto updateExpenseDto)
        {
            var map = _mapper.Map<Expense>(updateExpenseDto);
            var result = await _validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await _expenseService.UpdateExpenseAsync(updateExpenseDto);
                return RedirectToAction("Index", "Expense");
            }
            var categories = await _categoryService.GetAllActiveCategoriesForIncome();
            updateExpenseDto.Categories = categories;
            result.AddModelState(this.ModelState);
            return View(updateExpenseDto);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllActiveCategoriesForExpense();
            return View(new CreateExpenseDto { Categories = categories });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExpenseDto createExpenseDto)
        {
            var map = _mapper.Map<Expense>(createExpenseDto);
            var result = await _validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await _expenseService.CreateExpenseAsync(createExpenseDto);

                return RedirectToAction("Index", "Expense");
            }
            var categories = await _categoryService.GetAllActiveCategoriesForIncome();
            createExpenseDto.Categories = categories;
            result.AddModelState(this.ModelState);
            return View(createExpenseDto);
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _expenseService.DeleteExpenseAsync(id);
            return RedirectToAction("Index", "Expense");

        }
    }
}
