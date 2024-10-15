using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DataAccessLayer.UnitOfWorks.Abstractions;
using DtoLayer.Dtos.IncomeDtos;
using EntityLayer.Entities;

namespace BusinessLayer.Services.Concretes
{
    public class IncomeManager : IIncomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IncomeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateIncomeAsync(CreateIncomeDto createDto)
        {
            var map = _mapper.Map<Income>(createDto);
            await _unitOfWork.GetRepository<Income>().AddAsync(map);
            await _unitOfWork.SaveAsync();
        }

        public async Task<string> DeleteIncomeAsync(int id)
        {
            var income = await _unitOfWork.GetRepository<Income>().GetByIdAsync(id);
            income.Status = false;
            await _unitOfWork.GetRepository<Income>().UpdateAsync(income);
            await _unitOfWork.SaveAsync();
            return income.Id.ToString();
        }

        public async Task<List<ResultIncomeDto>> GetAllIncomes()
        {
            var incomes = await _unitOfWork.GetRepository<Income>().GetAllAsync();
            var map = _mapper.Map<List<ResultIncomeDto>>(incomes);
            return map;
        }
        public async Task<string> ActiveIncomeAsync(int id)
        {
            var income = await _unitOfWork.GetRepository<Income>().GetByIdAsync(id);
            income.Status = true;
            await _unitOfWork.GetRepository<Income>().UpdateAsync(income);
            await _unitOfWork.SaveAsync();
            return income.Id.ToString();
        }
        public async Task<List<ResultIncomeDto>> GetAllIncomesWithCategory()
        {
            var incomes = await _unitOfWork
                .GetRepository<Income>()
                .GetAllAsync(x => x.Status, x => x.Category);
            var map = _mapper.Map<List<ResultIncomeDto>>(incomes);
            return map;
        }

        public async Task<GetIncomeDto> GetIncomeById(int id)
        {
            var income = await _unitOfWork.GetRepository<Income>().GetByIdAsync(id);
            var map = _mapper.Map<GetIncomeDto>(income);
            return map;
        }

        public async Task<string> UpdateIncomeAsync(UpdateIncomeDto updateDto)
        {
            var map = _mapper.Map<Income>(updateDto);
            await _unitOfWork.GetRepository<Income>().UpdateAsync(map);
            await _unitOfWork.SaveAsync();
            return updateDto.Id.ToString();
        }

        public async Task<decimal> GetTotalIncome()
        {

            var sumIncome = await _unitOfWork
                .GetRepository<Income>()
                .SumAsync(x => x.Status, y => y.Cost);
            return sumIncome;
        }
        public async Task<decimal> GetTotalIncomeThisMonth()
        {

            var sumIncome = await _unitOfWork
                .GetRepository<Income>()
                .SumAsync(x => x.Status && (x.IncomeDate.Month == DateTime.Now.Month) && (x.IncomeDate.Year == DateTime.Now.Year), y => y.Cost);
            return sumIncome;
        }

        public async Task<decimal> GetIncomeDifWithLastMonth()
        {

            var sumIncome = await _unitOfWork
                .GetRepository<Income>()
                .SumAsync(x => x.Status && (x.IncomeDate.Month == DateTime.Now.Month) && (x.IncomeDate.Year == DateTime.Now.Year), y => y.Cost);
            var sumIncome2 = await _unitOfWork
               .GetRepository<Income>()
               .SumAsync(x => x.Status && (x.IncomeDate.Month == DateTime.Now.Month - 1) && (x.IncomeDate.Year == DateTime.Now.Year), y => y.Cost);
            if (sumIncome == 0 || sumIncome2 == 0)
            {
                return 100;
            }
            else
            {
                decimal result = ((sumIncome - sumIncome2) / sumIncome) * 100;
                return result;
            }

        }

        public async Task<List<ResultIncomeDto>> GetIncomeWithDateFilter()
        {
            var result = await _unitOfWork
               .GetRepository<Income>()
               .GetAllAsync(x => (x.Status) && (x.IncomeDate.Month == 11) && (x.IncomeDate.Year == 2024));
            var map = _mapper.Map<List<ResultIncomeDto>>(result);
            return map;
        }
    }
}
