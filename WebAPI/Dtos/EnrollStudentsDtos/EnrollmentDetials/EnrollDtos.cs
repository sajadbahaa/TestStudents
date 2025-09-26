using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.EnrollStudentsDtos.EnrollmentDetials
{
    public  class EnrollDtos
    {
        public int StudnetID { get; set; }
        public DateOnly enrollDate { get; set; }
        public byte enrollStatus { get; set; }
    }
}
