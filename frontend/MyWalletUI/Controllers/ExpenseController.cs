using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DtoLayer.Dtos.ExpenseDtos;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public ExpenseController(IExpenseService expenseService, IMapper mapper, ICategoryService categoryService)
        {
            _expenseService = expenseService;
            _mapper = mapper;
            _categoryService = categoryService;
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
            await _expenseService.UpdateExpenseAsync(updateExpenseDto);
            return RedirectToAction("Index", "Expense");
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
            await _expenseService.CreateExpenseAsync(createExpenseDto);

            return RedirectToAction("Index", "Expense");
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _expenseService.DeleteExpenseAsync(id);
            return RedirectToAction("Index", "Expense");

        }
    }
}
