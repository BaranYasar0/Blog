using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class CategoryValidator:AbstractValidator<Category>
	{
		public CategoryValidator()
		{
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Boş geçilemez")
				.MaximumLength(20).WithMessage("Kategori Maksimum 20 karakter olmalı!")
				.MinimumLength(2).WithMessage("Kategori minimum 2 karakter olmalı!");
			
			
			
			
		}
	}
}
