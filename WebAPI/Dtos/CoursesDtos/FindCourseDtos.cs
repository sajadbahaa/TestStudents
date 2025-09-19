using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.CoursesDtos
{
    public  class FindCourseDtos
    {
        public short courseID { get; init; }
        public string title { get; init; }
        public string? description { get; init; }
        public string itemName { get; init; }
        public DateOnly CreateAt { get; init; }
        public bool IsActive { get; init; }
        public string level { get; init; }

        public FindCourseDtos()
        {
            courseID = 0;
            title = string.Empty;
            description = null;
            itemName = string.Empty;
            CreateAt = new DateOnly();
            IsActive = false;
            level = string.Empty;
        }

    }
}
