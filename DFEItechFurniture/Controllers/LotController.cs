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
        MySqlButler butler = new MySqlButler();

        [HttpGet]
        public ActionResult ListLots()
        {
            /** Dummy Return **/
            Lot lot1 = new Lot() { LotId = 1, LotName = "Lot 1", LotImage = "image1.jpg", LotType = 1, LotDescript = "leather recliner", Exterior = false, Price = 1900.00m };
            Lot lot2 = new Lot() { LotId = 2, LotName = "Lot 2", LotImage = "image2.jpg", LotType = 3, LotDescript = "picnic table", Exterior = true, Price = 190.00m };
            List<Lot> allLots = new List<Lot>();
            allLots.Add(lot1);
            allLots.Add(lot2);

            return View(allLots);
        }
        [HttpPost]
        public ActionResult ListLots(int lotId=0, string lotName=null, int lotType=0, string lotImage=null, string LotDescript=null, Boolean exterior=false, Decimal price=0)
        {
            List<Lot> allLots = new List<Lot>();
            if (lotId != 0) {                                   // GetLotsById (should get single match)
           // } else if (exterior != false && lotName != null) {  // GetLotsByNameAndType 
          //  } else if (lotName != null && lotType != 0) {       // GetLotsByName&Exterior
           // } else if (lotType != 0) {                          // GetLotByType                  
          //  }else if (lotType != 0)
          //  {                                             // GetAllLots
                /** Dummy Return2 **/
                Lot lot1 = new Lot() { LotId = 1, LotName = "Lot 1", LotImage = "image2.jpg", LotType = 1, LotDescript = "leather recliner", Exterior = false, Price = 1900.00m };
                Lot lot2 = new Lot() { LotId = 2, LotName = "Lot 2", LotImage = "image1.jpg", LotType = 3, LotDescript = "picnic table", Exterior = true, Price = 190.00m };
                
                allLots.Add(lot1);
                allLots.Add(lot2);
            }
            else
            {
                /** Dummy Return1 **/
                Lot lot1 = new Lot() { LotId = 1, LotName = "Lot 1", LotImage = "image1.jpg", LotType = 1, LotDescript = "leather recliner", Exterior = false, Price = 1900.00m };
                Lot lot2 = new Lot() { LotId = 2, LotName = "Lot 2", LotImage = "image2.jpg", LotType = 3, LotDescript = "picnic table", Exterior = true, Price = 190.00m };
                
                allLots.Add(lot1);
                allLots.Add(lot2);

            }
            

            return View(allLots);
        }

        public ActionResult CreateLot(string lotName, int lotType, string lotImage, string lotDescript, Boolean exterior, Decimal price)
        {
            return View(butler.InsertLot(lotName, lotType, lotImage, lotDescript, exterior, price));
        }
    }
}