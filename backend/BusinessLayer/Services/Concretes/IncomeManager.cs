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
            await _unitOfWork.GetRepository<Income>().DeleteAsync(income);
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
                .GetAllAsync(x => x.Status || !x.Status, x => x.Category);
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
        public async Task<List<GetMonthlyIncomeDto>> GetIncomeWithDateFilter(bool status, DateTime date = default)
        {
            date = date == default ? DateTime.Now : date;
            var result = await _unitOfWork
               .GetRepository<Income>()
               .GetAllAsync(x => status && (x.IncomeDate.Month == date.Month) && (x.IncomeDate.Year == date.Year), x => x.Category);

           var data = result.GroupBy(i => i.Category.Name)
                .Select(g => new GetMonthlyIncomeDto
                {
                    CategoryName = g.Key,
                    TotalAmount = g.Sum(i => i.Cost)
                }).ToList();

            
            return data;
        }
        public async Task<decimal> GetTotalIncomeThisMonth()
        {

            var sumIncome = await _unitOfWork
                .GetRepository<Income>()
                .SumAsync(x => x.Status && (x.IncomeDate.Month == DateTime.Now.Month) && (x.IncomeDate.Year == DateTime.Now.Year), y => y.Cost);
            return sumIncome;
        }

        public async Task<decimal> GetTotalIncomeDay()
        {
            var sumIncome = await _unitOfWork
               .GetRepository<Income>()
               .SumAsync(x => x.Status && (x.IncomeDate.Day == DateTime.Now.Day) && (x.IncomeDate.Month == DateTime.Now.Month) && (x.IncomeDate.Year == DateTime.Now.Year), y => y.Cost);
            return sumIncome;
        }


        public async Task<decimal> GetTotalIncomeThisWeek()
        {
            DateTime today = DateTime.Now.Date;
            DateTime lastWeek = today.AddDays(-7);
            var sumIncome = await _unitOfWork
              .GetRepository<Income>()
              .SumAsync(x => x.Status && (x.IncomeDate >= lastWeek && x.IncomeDate <= today), y => y.Cost);
            return sumIncome;
        }




    }
}
