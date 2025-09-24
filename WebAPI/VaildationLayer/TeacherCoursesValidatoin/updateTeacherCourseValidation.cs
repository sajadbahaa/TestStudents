using Dtos.TeacherCoursesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaildationLayer.TeacherCourses
{
    public  class updateTeacherCourseValidation : AbstractValidator<updateTeacherCoursrDtos>
    {

        public updateTeacherCourseValidation() 
        {
                        RuleFor(x => x.TeacherCourseID).GreaterThan(0).WithMessage("required");

            RuleFor(x => x.courseID).GreaterThan((short)0).WithMessage("required");

            RuleFor(x => x.startDate).NotEmpty();
            RuleFor(x => x.startDate)
    .NotEmpty()
    .WithMessage("required");

            RuleFor(x => x.endDate)
                .NotEmpty()
                .Must(NotPastDate)
                .WithMessage("End date can not be in the past");


        }
        private bool NotPastDate(DateOnly date)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            return date >= today; // يقبل اليوم وما بعده فقط
        }
    }
}
