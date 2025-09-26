using Dtos.EnrollStudentsDtos.Enrollment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaildationLayer.EnrollmentStudentsValidation
{
    public class addStudentEnrollValidation : AbstractValidator<addStudentsEnrollmentDetialsDtos>
    {
        public addStudentEnrollValidation()
        {
            RuleForEach
                (x => x.TeacherCourseIDs)
                .ChildRules
                (x => x.RuleFor(y => y)
                .GreaterThan(0)
                .WithMessage
                ("can not accept value eaqula 0 or less.")
                );

            RuleFor(x => x.enrollID)
                .GreaterThan(0)
                .WithMessage
                ("can not accept value eaqula 0 or less.");


        }

    }
}
