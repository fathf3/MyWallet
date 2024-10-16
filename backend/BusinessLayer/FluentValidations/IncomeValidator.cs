using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class IncomeValidator : AbstractValidator<Income>
    {
        public IncomeValidator()
        {
            RuleFor(x => x.Status).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.IncomeDate).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Cost).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez")
                .GreaterThan(0).WithMessage("0 dan büyük bir sayı girmelisiniz");
            
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez")
                .MinimumLength(2).WithMessage("2 karakterden az olamaz")
                .MaximumLength(200).WithMessage("En fazla 200 karakter olmalı");
            
        }
    }
}
