using Dtos.CoursesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaildationLayer.CoursesValidation
{
    public  class updateCourseValidation:AbstractValidator<updateCourseDtos>
    {
        public updateCourseValidation()
        {
         RuleFor(x=>x.title).NotEmpty().WithMessage(" لا يجب ان يكون فارغ ");
                     RuleFor(x => x.itemID).GreaterThan((short)0)
                .WithMessage(" لا يجب ان يكون فارغ ");
            RuleFor(x => x.level)
           .InclusiveBetween((byte)0, (byte)3)
           .WithMessage("لا يجب أن يكون أصغر من 0 أو أكبر من 3");


         
        }
    }
    }

