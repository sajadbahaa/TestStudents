using DTLayer.Entities.EntityEnums;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer.Entities
{
    public  class Enrollments
    {
    public int enrollID { get; private set; }
    public int StudnetID { get; private set; }
    public DateOnly enrollDate { get; set; }
    public EnrollmentEnums enrollStatus { get; set; }
    
       public Students student { get; set; }
    public ICollection<EnrollmentDetials> enrollmentDetials { get; private set; } = new List<EnrollmentDetials>();
        public Enrollments() 
        {
        enrollID = 0;
            enrollDate = DateOnly.MinValue;
            enrollStatus = EnrollmentEnums.Active;
        }


    }
}
