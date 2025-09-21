using Dtos.PeopleDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaildationLayer.PeopleValidation
{
    public  class updatePeopleVaildation:AbstractValidator<updatePeopleDtos>
    {
        public updatePeopleVaildation()
        {
            RuleFor(x => x.PersonID).GreaterThan(0)
                .WithMessage(" لا يجب ان يكون فارغ ");

            RuleFor(x => x.firstName).NotEmpty().WithMessage(" لا يجب ان يكون فارغ ");
            RuleFor(x => x.secondName).NotEmpty().WithMessage(" لا يجب ان يكون فارغ ");
            RuleFor(x => x.lastName).NotEmpty().WithMessage(" لا يجب ان يكون فارغ ");

            RuleFor(x => x.email)
            .EmailAddress().WithMessage("البريد غير صحيح")
            .When(x => !string.IsNullOrEmpty(x.email));

            RuleFor(x => x.phone)
            .MaximumLength(12).WithMessage("رقم الهاتف غير صحيح")
            .Matches(@"^\d+$").WithMessage("رقم الهاتف يجب أن يحتوي على أرقام فقط")
            .When(x => !string.IsNullOrEmpty(x.phone));


            RuleFor(x => x.gendor)
            .InclusiveBetween((byte)1, (byte)2)
            .WithMessage("لا يجب أن يكون أصغر من 0 أو أكبر من 2");

            RuleFor(x => x.birth)
    .NotEmpty().WithMessage("تاريخ الميلاد مطلوب.")
    .Must(birth =>
    {
        if (birth == null) return false;

        var today = DateOnly.FromDateTime(DateTime.Today);

        // منع تاريخ اليوم والمستقبل
        if (birth >= today)
            return false;

        // حساب العمر
        var age = today.Year - birth.Year;
        if (birth > today.AddYears(-age)) age--;

        // العمر بين 6 و22
        return age >= 6 && age <= 22;
    })
    .WithMessage("تاريخ الميلاد غير صالح، يجب أن يكون العمر بين 6 و22 سنة ولا يكون اليوم أو المستقبل.");

        }
    }
}
