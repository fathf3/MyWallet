﻿using DtoLayer.Dtos.CategoryDtos;
using DtoLayer.Dtos.IncomeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions
{
	public interface IIncomeService
	{
		Task<List<ResultIncomeDto>> GetAllIncomes();
		Task<List<ResultIncomeDto>> GetAllIncomesWithCategory();
		Task<List<GetMonthlyIncomeDto>> GetIncomeWithDateFilter(bool status,DateTime date);
        Task CreateIncomeAsync(CreateIncomeDto createDto);
		Task<GetIncomeDto> GetIncomeById(int id);
		Task<string> UpdateIncomeAsync(UpdateIncomeDto updateDto);
		Task<string> DeleteIncomeAsync(int id);
		Task<string> ActiveIncomeAsync(int id);
		Task<decimal> GetTotalIncome();
		Task<decimal> GetTotalIncomeThisMonth();
		Task<decimal> GetTotalIncomeDay();
		Task<decimal> GetTotalIncomeThisWeek();

    }
}
