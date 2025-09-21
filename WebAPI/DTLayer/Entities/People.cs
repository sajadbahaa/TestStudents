using DTLayer.Entities.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer.Entities
{
    public  class People
    {
        public int  PersonID { get; init;}
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string lastName { get; set; }
        public string ?email {  get; set; }
        public string? phone { get; set; }
        public DateOnly birth { get; set; }
        public  PeopleEnum gendor { get; set; }

        public People()
        {
 PersonID = 0;
            firstName = string.Empty;
            secondName = string.Empty;
            lastName = string.Empty;
            email = string.Empty;
            phone = string.Empty;
            gendor = PeopleEnum.male;       
        
        }
    }
}
