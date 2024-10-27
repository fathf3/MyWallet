﻿using DtoLayer.Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions
{
	public interface ICustomerService
	{
		Task<List<ResultCustomerDto>> GetAllCustomers();
		Task<List<ResultCustomerForPaymentDto>> GetAllActiveCustomers();
		Task CreateCustomerAsync(CreateCustomerDto createDto);
		Task<GetCustomerDto> GetCustomerById(int id);
		Task<string> UpdateCustomerAsync(UpdateCustomerDto updateDto);
		Task<string> DeleteCustomerAsync(int id);
        Task<string> ActiveCustomerAsync(int id);
        Task<string> PassiveCustomerAsync(int id);
    }
}
