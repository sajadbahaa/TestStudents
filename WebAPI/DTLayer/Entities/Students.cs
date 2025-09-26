using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer.Entities
{
    public  class Students
    {
    public int StudnetID {  get; private set; }
    public int PersonID { get; private set; }

        public ICollection< Enrollments> enrollment { get; private set; } = new List< Enrollments>();
    public People person { get; set; }



    public Students()
        {
            StudnetID = 0;
            PersonID = 0;
        }
    }
}
