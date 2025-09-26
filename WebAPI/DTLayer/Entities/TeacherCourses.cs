using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer.Entities
{
    public  class TeacherCourses
    {
    public int TeacherCourseID { get; set; }
        public short teacherID { get; set; }
        public short courseID { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate
        {
            get; set;
        }
        public string? note { get; set; }

        public Courses course { get; set; }
        public Teachers teacher { get; set; }
    public ICollection< EnrollmentDetials  > enrollmentDetials { get;  set;} = new HashSet< EnrollmentDetials >();
    }
}
