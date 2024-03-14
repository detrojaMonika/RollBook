using RollBook.DAL;
using RollBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollBook.Controllers
{
    public class QualityController : Controller
    {
        Quality_DAL _QualityDAL = new Quality_DAL();
        // GET: Quality
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetData()
        {
            try
            {
                List<QualityMaster> lstQuality = _QualityDAL.GetQuality();

                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(lstQuality), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Save(QualityMaster Roll)
        {
            Boolean mres = _QualityDAL.SaveData(Roll);
            try
            {
                if (mres==true)
                {
                    return Json("Successful...!!!", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Error :", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}