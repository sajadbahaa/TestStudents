using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.CoursesDtos
{
    public  class updateCourseDtos
    {
        public short courseID { get; set; }
        public string title { get; set; }
        public string? description { get; set; }
        public DateOnly CreateAt { get; set; }
        public short itemID { get; set; }
        public byte level { get; set; }

        public updateCourseDtos()
        {
            courseID = 0;
            title = string.Empty;
            description = null;
            CreateAt = new DateOnly();
            level = 0;
            itemID= 0;
        }
    }
}
