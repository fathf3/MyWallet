﻿using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DataAccessLayer.UnitOfWorks.Abstractions;
using DtoLayer.Dtos.ExpenseDtos;
using EntityLayer.Entities;

namespace BusinessLayer.Services.Concretes
{
    public class ExpenseManager : IExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpenseManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateExpenseAsync(CreateExpenseDto createDto)
        {
            var map = _mapper.Map<Expense>(createDto);
            await _unitOfWork.GetRepository<Expense>().AddAsync(map);
            await _unitOfWork.SaveAsync();
        }

        public async Task<string> DeleteExpenseAsync(int id)
        {
            var expense = await _unitOfWork.GetRepository<Expense>().GetByIdAsync(id);
            await _unitOfWork.GetRepository<Expense>().DeleteAsync(expense);
            await _unitOfWork.SaveAsync();
            return expense.Id.ToString();
        }

        public async Task<List<ResultExpenseDto>> GetAllExpenses()
        {
            var expenses = await _unitOfWork.GetRepository<Expense>().GetAllAsync();
            var map = _mapper.Map<List<ResultExpenseDto>>(expenses);
            return map;
        }
       
        public async Task<List<ResultExpenseDto>> GetAllExpensesWithCategory()
        {
            var expenses = await _unitOfWork
                .GetRepository<Expense>()
                .GetAllAsync(x => x.Status, x => x.Category);
            var map = _mapper.Map<List<ResultExpenseDto>>(expenses);
            return map;
        }

        public async Task<GetExpenseDto> GetExpenseById(int id)
        {
            var expense = await _unitOfWork.GetRepository<Expense>().GetByIdAsync(id);
            var map = _mapper.Map<GetExpenseDto>(expense);
            return map;
        }

        public async Task<string> UpdateExpenseAsync(UpdateExpenseDto updateDto)
        {
            var map = _mapper.Map<Expense>(updateDto);
            await _unitOfWork.GetRepository<Expense>().UpdateAsync(map);
            await _unitOfWork.SaveAsync();
            return updateDto.Id.ToString();
        }
        public async Task<decimal> GetTotalExpense()
        {
            var sumExpense = await _unitOfWork
                .GetRepository<Expense>()
                .SumAsync(x => x.Status, y => y.Cost);
            return sumExpense;
        }

        public async Task<decimal> GetTotalExpenseThisMonth()
        {

            var sumExpense = await _unitOfWork
                .GetRepository<Expense>()
                .SumAsync(x => x.Status && (x.ExpenseDate.Month == DateTime.Now.Month) && (x.ExpenseDate.Year == DateTime.Now.Year), y => y.Cost);
            return sumExpense;
        }

        public async Task<decimal> GetTotalExpenseDay()
        {
            var sumExpense = await _unitOfWork
               .GetRepository<Expense>()
               .SumAsync(x => x.Status && (x.ExpenseDate.Day == DateTime.Now.Day) && (x.ExpenseDate.Month == DateTime.Now.Month) && (x.ExpenseDate.Year == DateTime.Now.Year), y => y.Cost);
            return sumExpense;
        }

        public async Task<decimal> GetTotalExpenseThisWeek()
        {
            DateTime today = DateTime.Now.Date;
            DateTime lastWeek = today.AddDays(-7);
            var sumIncome = await _unitOfWork
              .GetRepository<Expense>()
              .SumAsync(x => x.Status && (x.ExpenseDate >= lastWeek && x.ExpenseDate <= today), y => y.Cost);
            return sumIncome;
        }

       
    }
}
