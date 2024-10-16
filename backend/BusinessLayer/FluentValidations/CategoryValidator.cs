using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez")
                .NotEmpty().WithMessage("Bu alan boş geçilemez")
                .MinimumLength(2).WithMessage("2 karakterden az olamaz")
                .MaximumLength(150).WithMessage("En fazla 150 karakter olmalı");

            RuleFor(x => x.CategoryType).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Status).NotNull().WithMessage("Bu alan boş geçilemez");
                


        }
    }
}
