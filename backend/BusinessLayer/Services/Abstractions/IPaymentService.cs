using DtoLayer.Dtos.ExpenseDtos;
using DtoLayer.Dtos.PaymentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions
{
	public interface IPaymentService
	{
		Task<List<ResultPaymentDto>> GetAllPayments();
        Task<List<ResultPaymentDto>> GetAllPaymentWithCustomer();
        Task CreatePaymentAsync(CreatePaymentDto createDto);
		Task<GetPaymentDto> GetPaymentById(int id);
		Task<string> UpdatePaymentAsync(UpdatePaymentDto updateDto);
		Task<string> DeletePaymentAsync(int id);
	}
}
