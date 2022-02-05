using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.Valid
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad & Soyad boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail boş geçilemez.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Ad & Soyad minimum 2 karakter olmalı");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Ad & Soyad maksimum 50 karakteri geçemez ");
            RuleFor(x => x.WriterPassword).Must(IsPasswordValid).WithMessage("Parolanızda en az bir küçük harf bir büyük harf ve rakam içermelidir.");
        }
        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
