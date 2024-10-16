using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Status).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Phone).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez")
                .MinimumLength(2).WithMessage("2 karakterden az olamaz")
                .MaximumLength(40).WithMessage("En fazla 40 karakter olmalı");
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez")
                .MinimumLength(2).WithMessage("2 karakterden az olamaz")
                .MaximumLength(40).WithMessage("En fazla 40 karakter olmalı"); 
        }
    }
}
