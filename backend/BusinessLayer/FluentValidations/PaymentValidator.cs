using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.Status).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.IsPaid).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.PaymentDate).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Amount).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez")
                .GreaterThan(0).WithMessage("0 dan büyük deger girmeniz gerekir");
           
            
        }
    }
}
