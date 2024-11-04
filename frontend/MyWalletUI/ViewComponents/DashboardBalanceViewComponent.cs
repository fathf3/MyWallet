﻿using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.ViewComponents
{
    public class DashboardBalanceViewComponent : ViewComponent
    {
        private readonly IIncomeService _incomeService;
        private readonly IExpenseService _expenseService;

        public DashboardBalanceViewComponent(IIncomeService incomeService, IExpenseService expenseService)
        {
            _incomeService = incomeService;
            _expenseService = expenseService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Ust 3 Alan
            ViewBag.totalIncome = await _incomeService.GetTotalIncome();
            ViewBag.totalExpense = await _expenseService.GetTotalExpense();
            ViewBag.totalBalance = ViewBag.totalIncome - ViewBag.totalExpense;

            // Günlük Gelir Hesaplama
            var incomeDay = await _incomeService.GetTotalIncomeDay();
            var expenseDay = await _expenseService.GetTotalExpenseDay();
            ViewBag.incomeDay = incomeDay - expenseDay;
            if (incomeDay < 1 || expenseDay < 1)
            {
                ViewBag.incomeDayDif = 100;
            }
            else
            {
                ViewBag.incomeDayDif = ((incomeDay - expenseDay) / incomeDay) * 100; ;

            }



            // Aylık Gelir Hesaplama
            var incomeThisMonth = await _incomeService.GetTotalIncomeThisMonth();
            var expenseThisMonth = await _expenseService.GetTotalExpenseThisMonth();

            ViewBag.incomeThisMonth = incomeThisMonth - expenseThisMonth;

            if (incomeThisMonth < 1 || expenseThisMonth < 1)
            {
                ViewBag.incomeThisMonthDif = 100;
            }
            else
            {
                ViewBag.incomeThisMonthDif = ((incomeThisMonth - expenseThisMonth) / incomeThisMonth) * 100; ;

            }

            // Aylık Gider Hesaplama
            var incomeThisWeek = await _incomeService.GetTotalIncomeThisWeek();
            var expenseThisWeek = await _expenseService.GetTotalExpenseThisWeek();

            ViewBag.incomeThisWeek = incomeThisWeek - expenseThisWeek;

            if (incomeThisWeek < 1 || expenseThisWeek < 1)
            {
                ViewBag.incomeThisWeekDif = 100;
            }
            else
            {
                ViewBag.incomeThisWeekDif = ((incomeThisWeek - expenseThisWeek) / incomeThisWeek) * 100; ;

            }
            return View();
        }
    }
}
