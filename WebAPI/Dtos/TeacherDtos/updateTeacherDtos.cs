using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.TeacherDtos
{
    public  class updateTeacherDtos
    {
        public short TeacherID { get; set; }
        public DateOnly hireDate { get; set; }
        public short specilzeID { get; set; }
    }
}
