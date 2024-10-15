using DtoLayer.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions
{
	public interface ICategoryService
	{

		Task<List<ResultCategoryDto>> GetAllCategories();
		Task CreateCategoryAsync(CreateCategoryDto createDto);
		Task<GetCategoryDto> GetCategoryById(int id);
		Task<string> UpdateCategoryAsync(UpdateCategoryDto updateDto);
		Task<string> DeleteCategoryAsync(int id);
		Task<string> ActiveCategoryAsync(int id);
		


	}
}
