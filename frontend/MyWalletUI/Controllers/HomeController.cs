using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DtoLayer.Dtos.IncomeDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWalletUI.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyWalletUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly IIncomeService _incomeService;
        private readonly IExpenseService _expenseService;


        public HomeController(IExpenseService expenseService, IIncomeService incomeService)
        {
            _expenseService = expenseService;
            _incomeService = incomeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(DateTime filterIncomeDate, DateTime filterExpenseDate)
        {
            ViewBag.dateForIncomeChart = filterIncomeDate;
            ViewBag.dateForExpenseChart = filterExpenseDate;
           
            return View();
        }
        //[HttpGet]
        //public async Task<IActionResult> GetTwoDate(DateTime startDate, DateTime endDate)
        //{
        //   var income = await _incomeService.GetIncomeWithTwoDateFilter(true, startDate, endDate);
        //   var expense = await _expenseService.GetExpenseWithTwoDateFilter(true, startDate, endDate);

        //    return View();
        //}
        public async Task<JsonResult> GetTwoDate(DateTime startDate, DateTime endDate)
        {
            var income = await _incomeService.GetIncomeWithTwoDateFilter(true, startDate, endDate);
            var expense = await _expenseService.GetExpenseWithTwoDateFilter(true, startDate, endDate);
            return Json(new { Income = income.ToString("C"), Expense = expense.ToString("C") });

        }
    }

}
