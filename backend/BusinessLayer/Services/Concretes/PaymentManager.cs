using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DataAccessLayer.UnitOfWorks.Abstractions;
using DtoLayer.Dtos.IncomeDtos;
using DtoLayer.Dtos.PaymentDtos;
using EntityLayer.Entities;

namespace BusinessLayer.Services.Concretes
{
    public class PaymentManager : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIncomeService _incomeService;
        private readonly ICustomerService _customerService;

        public PaymentManager(IUnitOfWork unitOfWork, IMapper mapper, IIncomeService incomeService, ICustomerService customerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _incomeService = incomeService;
            _customerService = customerService;
        }

        public async Task<List<ResultPaymentDto>> GetAllPayments()
        {
            var payments = await _unitOfWork.GetRepository<Payment>().GetAllAsync();
            var map = _mapper.Map<List<ResultPaymentDto>>(payments);
            return map;
        }

        public async Task CreatePaymentAsync(CreatePaymentDto createDto)
        {
            var map = _mapper.Map<Payment>(createDto);
            await _unitOfWork.GetRepository<Payment>().AddAsync(map);
           
            await _unitOfWork.SaveAsync();
        }

        public async Task<string> DeletePaymentAsync(int id)
        {
            var payment = await _unitOfWork.GetRepository<Payment>().GetByIdAsync(id);
            await _unitOfWork.GetRepository<Payment>().DeleteAsync(payment);
            
           
            await _unitOfWork.SaveAsync();
            return payment.Id.ToString();
        }

        
        public async Task<string> ActivePaymentAsync(int id)
        {
            var payment = await _unitOfWork.GetRepository<Payment>().GetByIdAsync(id);
            payment.Status = true;
            await _unitOfWork.GetRepository<Payment>().UpdateAsync(payment);
            await _unitOfWork.SaveAsync();
            return payment.Id.ToString();
        }


        public async Task<GetPaymentDto> GetPaymentById(int id)
        {
            var payment = await _unitOfWork.GetRepository<Payment>().GetByIdAsync(id);
            var map = _mapper.Map<GetPaymentDto>(payment);
            return map;
        }

        public async Task<string> UpdatePaymentAsync(UpdatePaymentDto updateDto)
        {
            var map = _mapper.Map<Payment>(updateDto);
            await _unitOfWork.GetRepository<Payment>().UpdateAsync(map);
          
            await _unitOfWork.SaveAsync();
            return updateDto.Id.ToString();
        }

        public async Task<List<ResultPaymentDto>> GetAllPaymentWithCustomer()
        {
            var payments = await _unitOfWork
                .GetRepository<Payment>()
                .GetAllAsync(null, y => y.Customer);
            var result = _mapper.Map<List<ResultPaymentDto>>(payments);
            return result;
        }

        public async Task<List<ResultPaymentDto>> GetAllPaymentWithCustomerById(int id)
        {
            var payments = await _unitOfWork.GetRepository<Payment>().GetAllAsync(x => x.CustomerId == id);
            var map = _mapper.Map<List<ResultPaymentDto>>(payments);
            return map;
        }
    }
}
