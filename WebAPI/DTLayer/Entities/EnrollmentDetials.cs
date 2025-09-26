using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer.Entities
{
    public  class EnrollmentDetials
    {
        public int enrollDetialsID { get; private set; }
        public int enrollID { get; set; }
        public int TeacherCourseID { get; set; }
        public TeacherCourses TeacherCourse { get;private set; }
        public Enrollments enrollment { get; private set; }
    }
}
