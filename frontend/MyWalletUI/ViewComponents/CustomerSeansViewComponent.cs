using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.ViewComponents
{
    public class CustomerSeansViewComponent : ViewComponent
    {
        private readonly ISeansService _seansService;

        public CustomerSeansViewComponent(ISeansService seansService)
        {
            _seansService = seansService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int customerId)
        {
            var result = await _seansService.GetAllSeansWithCustomer(customerId);
            return View(result);
        }
    }
}
