using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.ViewComponents
{
    public class DashboardMonthlyExpenseChartViewComponent : ViewComponent
    {
        private readonly IExpenseService expenseService;

        public DashboardMonthlyExpenseChartViewComponent(IExpenseService expenseService)
        {
            this.expenseService = expenseService;
        }
        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync(DateTime filterIncomeDate)
        {
            filterIncomeDate = filterIncomeDate == default ? DateTime.Now : filterIncomeDate;
            var data = await expenseService.GetExpenseWithDateFilter(true, filterIncomeDate);

            ViewData["TotalExpense"] = data.Sum(x => x.TotalAmount);
            return View(data);
        }
    }
}
