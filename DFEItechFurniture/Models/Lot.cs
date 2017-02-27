using System;

namespace DFEItechFurniture.Models
{
    public class Lot
    {
        public int LotId { get; set; }
        public string LotName { get; set; }
        public string LotImage { get; set; }
        public Category LotType {get; set;}
        public string LotDescript { get; set; }
        public Boolean Exterior { get; set; }
        public Decimal Price { get; set; }
    }
}