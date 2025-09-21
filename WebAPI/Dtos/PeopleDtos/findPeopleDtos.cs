using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.PeopleDtos
{
    public  class findPeopleDtos
    {
        public int PersonID { get; init; }
        public string fullName { get; init; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public DateOnly birth { get; set; }
        public string gendor { get; set; }
        public findPeopleDtos()
        {
            PersonID = 0;
            fullName = string.Empty;
            email = string.Empty;
            phone = string.Empty;
            gendor = string.Empty;
        }

    }
}
