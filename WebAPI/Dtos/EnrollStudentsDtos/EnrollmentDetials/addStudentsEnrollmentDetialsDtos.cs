using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.EnrollStudentsDtos.Enrollment
{
    public  class addStudentsEnrollmentDetialsDtos
    { 
   public int enrollID  { get; set; }
   public List<int> TeacherCourseIDs { get; set; } = new List<int>();
    }
}
