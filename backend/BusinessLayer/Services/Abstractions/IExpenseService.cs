using DtoLayer.Dtos.ExpenseDtos;
using DtoLayer.Dtos.ExpenseDtos;
using DtoLayer.Dtos.IncomeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions
{
	public interface IExpenseService
	{
        Task<List<ResultExpenseDto>> GetAllExpenses();
        Task<List<ResultExpenseDto>> GetAllExpensesWithCategory();
        Task<List<GetMonthlyExpenseDto>> GetExpenseWithDateFilter(bool status, DateTime date);
       
        Task CreateExpenseAsync(CreateExpenseDto createDto);
        Task<GetExpenseDto> GetExpenseById(int id);
        Task<string> UpdateExpenseAsync(UpdateExpenseDto updateDto);
        Task<string> DeleteExpenseAsync(int id);
        Task<decimal> GetTotalExpense();
        Task<decimal> GetTotalExpenseThisMonth();
        Task<decimal> GetTotalExpenseDay();
        Task<decimal> GetTotalExpenseThisWeek();
        Task<decimal> GetExpenseWithTwoDateFilter(bool status, DateTime startDate, DateTime endDate);



    }
}
