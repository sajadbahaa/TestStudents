using Dtos.EnrollStudentsDtos.StudentsDtos;
using Dtos.PeopleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.EnrollStudentsDtos.EnrollmentDetials
{
    public  class addStudentsEnrollmentDetialsFTDtos
    {
        public addStudentDtos addStudentDtos { get; set; } = null!;
        public EnrollDtos enrollDtos {get;set;} = null!;
        // add enroll
        public List<int> TeacherCourseIDs { get; set; } = new List<int>();
    
    }
}
