using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public  class UpdateItemsDto
    {
        public short itemID { get; set; }
        public string itemName { get; set; }
                public UpdateItemsDto()
        {
            itemID = 0;
            itemName = string.Empty;
        //specilizeId = 0;
        // specilizeName = string.Empty;

        }

    }
}
