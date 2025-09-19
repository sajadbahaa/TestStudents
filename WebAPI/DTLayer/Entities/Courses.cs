using DTLayer.Entities.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer.Entities
{
    public  class Courses
    {
        public short courseID { get; set; }
        public string title { get; set; }
        public string ?description { get; set; }
        public short itemID { get;set; }
        public DateOnly CreateAt { get; set; }
        public bool IsActive {  get; set; }
        public Items Items { get; set; }
        public CourseEnums level { get; set; } 

        public Courses() 
        {
            courseID = 0;
            title = string.Empty;
            description = null;
            IsActive = true;
            CreateAt = DateOnly.MinValue;
            level = CourseEnums.beginners;
        }

    }
}
