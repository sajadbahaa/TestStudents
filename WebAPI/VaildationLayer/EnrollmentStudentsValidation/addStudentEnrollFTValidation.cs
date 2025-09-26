using Dtos.EnrollStudentsDtos.EnrollmentDetials;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaildationLayer.PeopleValidation;

namespace VaildationLayer.EnrollmentStudentsValidation
{
    public  class addStudentEnrollFTValidation:AbstractValidator<addStudentsEnrollmentDetialsFTDtos>
    {
       public addStudentEnrollFTValidation()
        {
            RuleForEach(x => x.TeacherCourseIDs).ChildRules(x=>x.RuleFor(y=>y).GreaterThan(0).WithMessage("can not accept value eaqula 0 or less."));
            //addStudentsValidation
            RuleFor(x => x.addStudentDtos).SetValidator(new addStudentsValidation());
            RuleFor(x => x.enrollDtos).SetValidator(new enrollValidation());
        }

    }
}
