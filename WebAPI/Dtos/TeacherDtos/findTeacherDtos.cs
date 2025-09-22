using Dtos.PeopleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.TeacherDtos
{
    public  class findTeacherDtos
    {
        public short TeacherID { get; init; }
        public findPeopleDtos person { get; init; } = null!;
        public DateOnly hireDate { get; init; } 
        public string specilzeName { get; init; } = null!;
    }
}
