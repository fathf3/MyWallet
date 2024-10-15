using DtoLayer.Dtos.ExpenseDtos;
using DtoLayer.Dtos.ExpenseDtos;
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
        Task CreateExpenseAsync(CreateExpenseDto createDto);
        Task<GetExpenseDto> GetExpenseById(int id);
        Task<string> UpdateExpenseAsync(UpdateExpenseDto updateDto);
        Task<string> DeleteExpenseAsync(int id);
        Task<string> ActiveExpenseAsync(int id);
        Task<decimal> GetTotalExpense();
    }
}
