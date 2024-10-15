using AutoMapper;
using BusinessLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MyWalletUI.Models;
using System.Diagnostics;

namespace MyWalletUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICategoryService _categoryService;
		

		public HomeController(ILogger<HomeController> logger, IMapper mapper, ICategoryService categoryService)
		{
			_logger = logger;
			
			_categoryService = categoryService;
		}

		public async Task<IActionResult> Index()
		{
			var categories = await _categoryService.GetAllCategories();
			 
			return View(categories);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
