using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer.Entities
{
    public class Items
    {
        public short itemID { get; set; }
        public string itemName { get; set; }

        public short specilizeID { get; set; }
        public Specilzeations specilize { get; set; }
        public Items()
        {
            itemID = 0;
            itemName = string.Empty;
            specilizeID = 0;
            specilize = new Specilzeations();
        }
        public Items(string itemName, short specilizeID)
        {
           
            this.itemName = itemName;
            this.specilizeID = specilizeID;
        }
    }
}
