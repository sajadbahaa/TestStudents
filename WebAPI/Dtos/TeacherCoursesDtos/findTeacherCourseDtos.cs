using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.TeacherCoursesDtos
{
    public  class findTeacherCourseDtos
    {
        public int TeacherCourseID { get; set; }
        public string teacherName { get; set; }
        public string courseName { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate
        {
            get; set;
        }
        public string? note { get; set; }
    }
}
