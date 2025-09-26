using Dtos.PeopleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.EnrollStudentsDtos.StudentsDtos
{
    public  class findStudentsDtos
    {
        public int StudentID { get; init; }
        public findPeopleDtos findPeople { get; init; } = null!;
    }
}
