using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.EnrollStudentsDtos.EnrollmentDetials
{
    public  class findEnrollmentDtos
    {
        public int enrollID { get; private set; }
        public int StudnetID { get; private set; }
        public DateOnly enrollDate { get; private set; }
        public string enrollStatus { get; private set; }
    }
}
