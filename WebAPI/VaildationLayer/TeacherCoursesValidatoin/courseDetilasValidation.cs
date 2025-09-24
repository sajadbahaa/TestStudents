using Dtos.TeacherCoursesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaildationLayer.TeacherCourses
{
    public class courseDetilasValidation : AbstractValidator<coursesDetialsdtos>
    {
        public courseDetilasValidation()
        {
            RuleFor(x => x.courseID).NotEmpty().GreaterThan((short)0);

            RuleFor(x => x.startDate).NotEmpty();
            RuleFor(x => x.startDate)
    .NotEmpty()
    .Must(NotPastDate)
    .WithMessage("Start date can not be in the past");

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
