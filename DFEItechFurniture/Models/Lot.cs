using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFEItechFurniture.Models
{
    public class Lot
    {
        public int LotId { get; set; }
        public string LotName { get; set; }
        public string LotImage { get; set; }
        public int LotType {get; set;} // make me Type LotType
        public string LotDescript { get; set; }
        public Boolean Exterior { get; set; }
        public Decimal Price { get; set; }
    }
}