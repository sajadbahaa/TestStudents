using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.PeopleDtos
{
    public  class updatePeopleDtos
    {
        public int PersonID { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string lastName { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public DateOnly birth { get; set; }
        public byte gendor { get; set; }

        public updatePeopleDtos()
        {
            PersonID = 0;
            firstName = string.Empty;
            secondName = string.Empty;
            lastName = string.Empty;
            email = string.Empty;
            phone = string.Empty;
            gendor = 0;
        }
    }
}
