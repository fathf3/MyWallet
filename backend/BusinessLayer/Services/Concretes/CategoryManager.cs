using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DataAccessLayer.UnitOfWorks.Abstractions;
using DtoLayer.Dtos.CategoryDtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concretes
{
    public class CategoryManager : ICategoryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CategoryManager(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task CreateCategoryAsync(CreateCategoryDto createDto)
		{
			var map = _mapper.Map<Category>(createDto);
			await _unitOfWork.GetRepository<Category>().AddAsync(map);
			await _unitOfWork.SaveAsync();
		}

		public async Task<string> DeleteCategoryAsync(int id)
		{
			var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
			category.Status = false;
			await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
			await _unitOfWork.SaveAsync();
			return category.Name;
		}
        public async Task<string> ActiveCategoryAsync(int id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
            category.Status = true;
            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return category.Name;
        }
        public async Task<List<ResultCategoryDto>> GetAllCategories()
		{
			var catagories = await _unitOfWork.GetRepository<Category>().GetAllAsync();
			var map = _mapper.Map<List<ResultCategoryDto>>(catagories);
			return map;
		}

		public async Task<GetCategoryDto> GetCategoryById(int id)
		{
			var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(id);
			var map = _mapper.Map<GetCategoryDto>(category);
			return map;
		}

		public async Task<string> UpdateCategoryAsync(UpdateCategoryDto updateDto)
		{
			var map = _mapper.Map<Category>(updateDto);
			await _unitOfWork.GetRepository<Category>().UpdateAsync(map);
			await _unitOfWork.SaveAsync();
			return updateDto.Name;
		}

        public async Task<List<ResultCategoryDto>> GetAllActiveCategories()
        {
            var catagories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => x.Status);
            var map = _mapper.Map<List<ResultCategoryDto>>(catagories);
            return map;
        }

        public async Task<List<ResultCategoryDto>> GetAllActiveCategoriesForIncome()
        {
            var catagories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => x.Status && x.CategoryType == true);
            var map = _mapper.Map<List<ResultCategoryDto>>(catagories);
            return map;
        }

        public async Task<List<ResultCategoryDto>> GetAllActiveCategoriesForExpense()
        {
            var catagories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => x.Status && x.CategoryType == false);
            var map = _mapper.Map<List<ResultCategoryDto>>(catagories);
            return map;
        }
    }
}
