using Dtos.EnrollStudentsDtos.StudentsDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaildationLayer.PeopleValidation;

namespace VaildationLayer.EnrollmentStudentsValidation
{
    public  class addStudentsValidation:AbstractValidator<addStudentDtos>
    {
        public addStudentsValidation()
        {
            RuleFor(x => x.addPeopleDtos).SetValidator(new addPeopleValidation());
            RuleFor(x => x.addPeopleDtos.birth)
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
     return age >= 6 && age <= 24;
 })
 .WithMessage("تاريخ الميلاد غير صالح، يجب أن يكون العمر بين 6 24 سنة ولا يكون اليوم أو المستقبل.");

        }

    }
}
