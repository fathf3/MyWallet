using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.ViewComponents
{
    public class HomeScriptViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
