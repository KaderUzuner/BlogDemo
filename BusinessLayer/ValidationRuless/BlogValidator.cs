using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Valid
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş geçilemez");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş geçilemez");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görseli boş geçilemez");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Blog başlığı 150 karakteri geçemez");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen Blog başlığı 5 karakterden az olamaz");
        }
        
    }
}
