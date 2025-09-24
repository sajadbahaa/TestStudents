using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.TeacherCoursesDtos
{
    public  class addTeacherCourseDtos
    {
        public Dictionary<short, HashSet<coursesDetialsdtos>> TeacherCourse { get; set; } = null!;
 
    }
}
