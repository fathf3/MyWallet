using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.ViewComponents
{
    public class CustomerPaymentsViewComponent : ViewComponent
    {
        private readonly IPaymentService paymentService;

        public CustomerPaymentsViewComponent(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int customerId)
        {
            var result = await paymentService.GetAllPaymentWithCustomerById(customerId);
            return View(result);
        }
    }
}
