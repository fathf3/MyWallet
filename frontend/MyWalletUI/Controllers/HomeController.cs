using AutoMapper;
using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MyWalletUI.Models;
using System.Diagnostics;

namespace MyWalletUI.Controllers
{
	public class HomeController : Controller
	{
		
		private readonly IIncomeService _incomeService;
		private readonly IExpenseService _expenseService;

        public HomeController(IExpenseService expenseService, IIncomeService incomeService)
        {
            _expenseService = expenseService;
            _incomeService = incomeService;
        }


        public async Task<IActionResult> Index()
		{
			// Ust 3 Alan
			ViewBag.totalIncome = await _incomeService.GetTotalIncome();
			ViewBag.totalExpense = await _expenseService.GetTotalExpense();
			ViewBag.totalBalance = ViewBag.totalIncome- ViewBag.totalExpense;

			// Günlük Gelir Hesaplama
			ViewBag.incomeDay = await _incomeService.GetTotalIncomeDay();
			ViewBag.incomeDayDif = await _incomeService.GetIncomeDifLastDay();

            // Aylık Gelir Hesaplama
            ViewBag.incomeThisMonth = await _incomeService.GetTotalIncomeThisMonth();
			ViewBag.incomeThisMonthDif = await _incomeService.GetIncomeDifWithLastMonth();

            // Günlük Gider Hesaplama
            ViewBag.expenseDay = await _expenseService.GetTotalExpenseDay();
            ViewBag.expenseDayDif = await _expenseService.GetExpenseDifLastDay();

            // Aylık Gider Hesaplama
            ViewBag.expenseThisMonth = await _expenseService.GetTotalExpenseThisMonth();
            ViewBag.expenseThisMonthDif = await _expenseService.GetExpenseDifWithLastMonth();
            return View();
		}

		
	}
}
