﻿using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.ViewComponents
{
    public class HomeNavbarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
