using Dtos.TeacherDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaildationLayer.PeopleValidation;

namespace VaildationLayer.TeacherVaildation
{
    public  class addTeacherVaildation:AbstractValidator<addTeacherDtos>
    {
        public addTeacherVaildation()
        {
            RuleFor(x => x.person).SetValidator(new addPeopleValidation());
            RuleFor(x => x.specilzeID).NotEmpty().GreaterThan((short)0).WithMessage("required");
            RuleFor(x => x.hireDate).NotEmpty().WithMessage("required");

        }
    }
}
