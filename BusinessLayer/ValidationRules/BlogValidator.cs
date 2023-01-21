using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Başlık Boş Geçilemez.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik Boş Geçilemez.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Görsel Boş Geçilemez.");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Max 150 karakter girebilirsiniz.").
                MinimumLength(3).WithMessage("Minimum 3 Karakter giriniz."); ;
        }
    }
}
