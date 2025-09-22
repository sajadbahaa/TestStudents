using Dtos.PeopleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.TeacherDtos
{
    public  class addTeacherDtos
    {
        public DateOnly hireDate { get; set; }
        public short specilzeID { get; set; }
        public addPeopleDtos person { get; set; }
    }
}
