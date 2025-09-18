using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public  class addItemsToSpecilzeFirstTimeDtos
    { 
        public List<ItemsDtos> Items { get; set; } 
public  addUpdateSpecilizesDto speclize {  get; set; }  
        public addItemsToSpecilzeFirstTimeDtos()
        {
            Items = new List<ItemsDtos>();
            speclize = new addUpdateSpecilizesDto();
        }
    }
}
