using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public  class ItemsDtos
    {
        public short itemID { get; set; }
        public string itemName { get; set; }
        public ItemsDtos()
        {
            itemID = 0;
            itemName = string.Empty;
        }
    }
}
