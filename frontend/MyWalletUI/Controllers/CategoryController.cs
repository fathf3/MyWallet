using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Services.Abstractions;
using DtoLayer.Dtos.CategoryDtos;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyWalletUI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<Category> _validator;

        public CategoryController(ICategoryService categoryService, IMapper mapper, IValidator<Category> validator)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _validator = validator;
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
            
            var map = _mapper.Map<Category>(updateCategoryDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _categoryService.UpdateCategoryAsync(updateCategoryDto);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                result.AddModelState(this.ModelState);
                return View(updateCategoryDto);
            }
            

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            var map = _mapper.Map<Category>(createCategoryDto);
            var result = await _validator.ValidateAsync(map);
            if(result.IsValid)
            {
                await _categoryService.CreateCategoryAsync(createCategoryDto);

                return RedirectToAction("Index", "Category");
            }
            result.AddModelState(this.ModelState);
            return View(createCategoryDto);
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
        public async Task<IActionResult> Passive(int id)
        {
            await _categoryService.PassiveCategoryAsync(id);
            return RedirectToAction("Index", "Category");

        }
    }
}
