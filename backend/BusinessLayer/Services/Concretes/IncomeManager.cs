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
                .GetAllAsync(x => x.Status ,x => x.Category);
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

        
    }
}
