using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DataAccessLayer.UnitOfWorks.Abstractions;
using DtoLayer.Dtos.CustomerDtos;
using EntityLayer.Entities;

namespace BusinessLayer.Services.Concretes
{
    public class CustomerManager : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateCustomerAsync(CreateCustomerDto createDto)
        {
            var map = _mapper.Map<Customer>(createDto);
            await _unitOfWork.GetRepository<Customer>().AddAsync(map);
            await _unitOfWork.SaveAsync();
        }

        public async Task<string> DeleteCustomerAsync(int id)
        {
            var customer = await _unitOfWork.GetRepository<Customer>().GetByIdAsync(id);
            await _unitOfWork.GetRepository<Customer>().DeleteAsync(customer);
            await _unitOfWork.SaveAsync();
            return customer.Id.ToString();
        }

        public async Task<List<ResultCustomerDto>> GetAllCustomers()
        {
            var customers = await _unitOfWork.GetRepository<Customer>().GetAllAsync();
            var map = _mapper.Map<List<ResultCustomerDto>>(customers);
            return map;
        }
        public async Task<string> ActiveCustomerAsync(int id)
        {
            var customer = await _unitOfWork.GetRepository<Customer>().GetByIdAsync(id);
            customer.Status = true;
            await _unitOfWork.GetRepository<Customer>().UpdateAsync(customer);
            await _unitOfWork.SaveAsync();
            return customer.Id.ToString();
        }


        public async Task<GetCustomerDto> GetCustomerById(int id)
        {
            var customer = await _unitOfWork.GetRepository<Customer>().GetByIdAsync(id);
            var map = _mapper.Map<GetCustomerDto>(customer);
            return map;
        }

        public async Task<string> UpdateCustomerAsync(UpdateCustomerDto updateDto)
        {
            var map = _mapper.Map<Customer>(updateDto);
            await _unitOfWork.GetRepository<Customer>().UpdateAsync(map);
            await _unitOfWork.SaveAsync();
            return updateDto.Id.ToString();
        }

        public async Task<string> PassiveCustomerAsync(int id)
        {
            var customer = await _unitOfWork.GetRepository<Customer>().GetByIdAsync(id);
            customer.Status = false;
            await _unitOfWork.GetRepository<Customer>().UpdateAsync(customer);
            await _unitOfWork.SaveAsync();
            return customer.Id.ToString();
        }

        public async Task<List<ResultCustomerForPaymentDto>> GetAllActiveCustomersForPayment()
        {
            var customers = await _unitOfWork.GetRepository<Customer>().GetAllAsync(x => x.Status);
            var map = _mapper.Map<List<ResultCustomerForPaymentDto>>(customers);
            return map;
        }
    }
}
