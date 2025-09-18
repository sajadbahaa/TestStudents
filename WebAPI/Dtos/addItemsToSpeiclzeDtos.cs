using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public  class addItemsToSpeiclzeDtos
    {
        public List<ItemsDtos> Items { get; set; } = new List<ItemsDtos>();
        public short specilizeId { get; set; }
        public addItemsToSpeiclzeDtos()
        {
            Items = new List<ItemsDtos>();
            specilizeId = 0;
        }
    }
}
