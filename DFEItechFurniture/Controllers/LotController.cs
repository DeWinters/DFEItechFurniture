using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DFEItechFurniture.Models;

namespace DFEItechFurniture.Controllers
{
    public class LotController : Controller
    {
 
        public ActionResult ListAllLots()
        {
            Lot lot1 = new Lot() { LotId = 1, LotName = "Lot 1", LotImage="image1.jpg", LotDescript = "leather recliner", Exterior = false, Price = 1900.00m };
            Lot lot2 = new Lot() { LotId = 2, LotName = "Lot 2", LotImage="image2.jpg", LotDescript = "picnic table", Exterior = true, Price = 190.00m };
            List<Lot> allLots = new List<Lot>();
            allLots.Add(lot1);
            allLots.Add(lot2);
            return View(allLots);
        }
    }
}