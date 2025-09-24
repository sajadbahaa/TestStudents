using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.TeacherCoursesDtos
{
    public  class updateTeacherCoursrDtos
    {
        public int TeacherCourseID { get; set; }
        public short courseID { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate
        {
            get; set;
        }
        public string? note { get; set; }
    
    }
}
