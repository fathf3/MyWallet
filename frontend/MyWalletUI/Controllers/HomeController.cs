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
        
    }

}
