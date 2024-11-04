using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.ViewComponents
{
    public class DashboardMonthlyIncomeChartViewComponent : ViewComponent
    {
        private readonly IIncomeService _incomeService;

        public DashboardMonthlyIncomeChartViewComponent(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }
        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync(DateTime filterIncomeDate)
        {
            filterIncomeDate = filterIncomeDate == default ? DateTime.Now : filterIncomeDate;
            var data = await _incomeService.GetIncomeWithDateFilter(true, filterIncomeDate);
            
            ViewData["TotalIncome"] = data.Sum(x => x.TotalAmount);
            return View(data);
        }
    }
}
