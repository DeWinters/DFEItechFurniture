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
            return View(butler.GetAllLots());
        }

        [HttpPost]
        public ActionResult ListLots(int lotId=0, string lotName=null, int lotType=0, string lotImage=null, string LotDescript=null, Boolean exterior=false, Decimal price=0)
        {
            if (lotId != 0)                                     { return View(butler.GetLotsById(lotId)); }
            else if (exterior == true && lotName != null)       { return View(butler.GetLotsByNameAndExterior(lotName, exterior)); }           
            else if (lotName != null && lotType != 0)           { return View(butler.GetLotsByTypeAndName(lotType, lotName)); }
            else if (lotType != 0)                              { return View(butler.GetLotsByType(lotType)); }
            else if (lotName !=null)                            { return View(butler.GetLotsByName(lotName)); }
            else if (exterior == true)                          { return View(butler.GetLotsByExterior(true)); }
            else                                                { return View(butler.GetAllLots()); }            
        }

        public ActionResult NewLot(string lotName=null, int lotType=0, string lotImage=null, string lotDescript=null, Boolean exterior=false, Decimal price=0)
        {
            return View(butler.InsertLot(lotName, lotType, lotImage, lotDescript, exterior, price));
        }

        public ActionResult DeleteLot(int id)
        {
            return View(butler.DeleteLot(id));
        }

        public ActionResult CreateLot()
        {

            return View(butler.GetAllCategories());
        }
    }
}