using HMGreenCityMLM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMGreenCityMLM.Controllers
{
    public class WebsiteController : Controller
    {
        // GET: Website
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult UpdateRankforJob()
        {
            Website model = new Website();
            DataSet ds = model.UpdateRankforJob();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult UpdateHoldStatusforJob()
        {
            Website model = new Website();
            DataSet ds = model.UpdateHoldStatusforJob();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
            }
            return RedirectToAction("Login", "Home");
        }


        public ActionResult UpdateCounterHoldActiveforJob()
        {
            Website model = new Website();
            DataSet ds = model.UpdateCounterHoldActiveforJob();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
            }
            return RedirectToAction("Login", "Home");
        }


        public ActionResult UpdateRankwiseHourlyIncome()
        {
            Website model = new Website();
            DataSet ds = model.RankwiseHourlyIncome();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
            }
            return RedirectToAction("Login", "Home");
        }


    }
}