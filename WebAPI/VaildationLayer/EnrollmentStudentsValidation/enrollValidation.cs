using Dtos.EnrollStudentsDtos.EnrollmentDetials;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaildationLayer.EnrollmentStudentsValidation
{
    public  class enrollValidation:AbstractValidator<EnrollDtos>
    {
        public enrollValidation()
        {
           // RuleFor(x => x.StudnetID)
           //.GreaterThan(0)
           //.WithMessage("Required");
            RuleFor(x => x.enrollStatus)
           .InclusiveBetween((byte)0, (byte)2)
            .WithMessage
        ("لا يجب أن يكون أصغر من 0 أو أكبر من 1");
        }
    }
}
