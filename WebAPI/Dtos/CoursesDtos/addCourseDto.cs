using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.CoursesDtos
{
    public  class addCourseDto
    {
        public short courseID { get; set; }
        public string title { get; set; }
        public string? description { get; set; }
        public short itemID { get; set; }
        public DateOnly CreateAt { get; set; }
        public byte level { get; set; }
        public bool IsActive { get; set; }

        public addCourseDto()
        {
            courseID = 0;
            title = string.Empty;
            description = null;
            itemID = 0;
            CreateAt = new DateOnly();
            level = 0;
            IsActive = true;
        }
    }
}
