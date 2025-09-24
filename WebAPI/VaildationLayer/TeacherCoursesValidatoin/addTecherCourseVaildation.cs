using Dtos.TeacherCoursesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaildationLayer.ItemsValidation;

namespace VaildationLayer.TeacherCourses
{
    public  class addTecherCourseVaildation:AbstractValidator<addTeacherCourseDtos>
    {
        public addTecherCourseVaildation()
        {
            RuleForEach(x => x.TeacherCourse.Keys).ChildRules(x => x.RuleFor(y => y).NotEmpty().GreaterThan((short)0).WithMessage("required"));
            RuleForEach(x => x.TeacherCourse.Values)
            .NotEmpty().WithMessage("Course list cannot be empty")
            .Must(hs => hs.All(cd => cd != null))
            .WithMessage("Courses cannot contain null values")
            .ForEach(course => course.SetValidator(new courseDetilasValidation()));
        }
    }
}
