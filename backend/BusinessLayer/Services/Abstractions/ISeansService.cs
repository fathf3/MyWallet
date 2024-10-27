using DtoLayer.Dtos.SeansDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions
{
    public interface ISeansService
    {
        Task<List<ResultSeansDto>> GetAllSeansWithCustomer(int id);
        Task CreateSeansAsync(CreateSeansDto createDto);
        Task<string> DeleteSeansAsync(int id);
        Task<string> ActiveSeansAsync(int id);
        Task<string> PassiveSeansAsync(int id);
    }
}
