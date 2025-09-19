using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ItemWithSpeclizeDtos
{
    public  class UpdateItemsWithSpecilzeDtos
    {
        public UpdateItemsDto item { get; set; }
        public addUpdateSpecilizesDto specilze { get; set; }
        public UpdateItemsWithSpecilzeDtos()
        {
            item = new UpdateItemsDto();
            specilze = new addUpdateSpecilizesDto();
        }
    }
}
