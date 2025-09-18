using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class FindItemsDtos
    {
        public short itemID { get; init; }
        public string itemName { get; init; }
        public short specilizeId { get; init; }
        public string specilizeName { get; init; }
    }
}
