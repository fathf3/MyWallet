using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DtoLayer.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyWalletUI.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategories();

            return View(categories);

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            var map = _mapper.Map<UpdateCategoryDto>(category);
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            
            return RedirectToAction("Index", "Category");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);

            return RedirectToAction("Index", "Category");
        }

        public async Task<IActionResult> Delete(int id)
        {
            
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index", "Category");

        }
        public async Task<IActionResult> Active(int id)
        {

            await _categoryService.ActiveCategoryAsync(id);
            return RedirectToAction("Index", "Category");

        }
    }
}
