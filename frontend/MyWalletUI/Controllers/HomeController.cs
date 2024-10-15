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
			
			 
			return View();
		}

		
	}
}
