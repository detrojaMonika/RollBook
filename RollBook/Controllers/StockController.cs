using RollBook.DAL;
using RollBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollBook.Controllers
{
    public class StockController : Controller
    {
        Stock_DAL _StockDAL = new Stock_DAL();

        // GET: Stock
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetData()
        {
            try
            {
                List<StockMaster> lstStock = _StockDAL.GetStock();

                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(lstStock), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}