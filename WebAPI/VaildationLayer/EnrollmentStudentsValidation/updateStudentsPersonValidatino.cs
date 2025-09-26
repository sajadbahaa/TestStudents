using Dtos.EnrollStudentsDtos.StudentsDtos;
using Dtos.PeopleDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaildationLayer.PeopleValidation;

namespace VaildationLayer.EnrollmentStudentsValidation
{
    public  class updateStudentsPersonValidatino:AbstractValidator<updateStudentsPersonDtos>
    {
        public updateStudentsPersonValidatino()
        {
            RuleFor(x=>x.updatePeopleDtos).SetValidator(new updatePeopleVaildation());
        }
    }
}
