using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer.Entities
{
    public class Teachers
    {
        public short TeacherID { get; set; }
        public int personID { get; set; }
        public DateOnly hireDate { get; set; }
        public short specilzeID { get; set; }
        public Specilzeations specilze { get; set; } = null!;
        public People person { get; set; } = null!;
        


    }
}
