using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLayer.Entities
{
    public  class Specilzeations
    {
        public  short specilizeId {  get; set; }
        public string specilizeName { get; set; } = string.Empty;

        public ICollection<Items>Items { get; set; }
       
    }
}
