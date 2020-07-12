using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMGreenCityMLM.Models;
using HMGreenCityMLM.Filter;

namespace HMGreenCityMLM.Controllers
{
    public class MasterController : AdminBaseController
    {
        #region ProductMaster
        public ActionResult ProductList(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.ProductList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.ProductID = r["Pk_ProductId"].ToString();
                    obj.ProductName = r["ProductName"].ToString();
                    obj.ProductPrice = r["ProductPrice"].ToString();
                    obj.IGST = r["IGST"].ToString();
                    obj.CGST = r["CGST"].ToString();
                    obj.SGST = (r["SGST"].ToString());
                    obj.BinaryPercent = (r["BinaryPercent"].ToString());
                    obj.DirectPercent = (r["DirectPercent"].ToString());
                    obj.ROIPercent = (r["ROIPercent"].ToString());
                    obj.BV = (r["BV"].ToString());

                    lst.Add(obj);
                }
                model.lstproduct = lst;
            }
            return View(model);
        }

        public ActionResult DeleteProduct(string id)
        {
            string FormName = "";
            string Controller = "";
            try
            {
                Master obj = new Master();
                obj.ProductID = id;
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.DeleteProduct();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["Product"] = "Product deleted successfully";
                        FormName = "ProductList";
                        Controller = "Master";
                    }
                    else
                    {
                        TempData["Product"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        FormName = "ProductList";
                        Controller = "Master";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Product"] = ex.Message;
                FormName = "ProductList";
                Controller = "Master";
            }

            return RedirectToAction(FormName, Controller);
        }

        public ActionResult ProductMaster(string productID)
        {
            Master obj = new Master();
            if (productID != null)
            {
                
                try
                {
                    obj.ProductID = productID;

                    DataSet ds = obj.ProductList();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        obj.ProductID = ds.Tables[0].Rows[0]["Pk_ProductId"].ToString();
                        obj.ProductName = ds.Tables[0].Rows[0]["ProductName"].ToString();
                        obj.ProductPrice = ds.Tables[0].Rows[0]["ProductPrice"].ToString();
                        obj.IGST = ds.Tables[0].Rows[0]["IGST"].ToString();
                        obj.CGST = ds.Tables[0].Rows[0]["CGST"].ToString();
                        obj.SGST = ds.Tables[0].Rows[0]["SGST"].ToString();
                        obj.BinaryPercent = ds.Tables[0].Rows[0]["BinaryPercent"].ToString();
                        obj.DirectPercent = ds.Tables[0].Rows[0]["DirectPercent"].ToString();
                        obj.ROIPercent = ds.Tables[0].Rows[0]["ROIPercent"].ToString();
                        obj.BV = ds.Tables[0].Rows[0]["BV"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    TempData["Product"] = ex.Message;
                }
                return View(obj);
            }
            else
            {
                return View(obj);
            }
            
        }

        public ActionResult SaveProduct(string ProductName, string ProductPrice, string IGST, string CGST, string SGST, string BinaryPercent, string DirectPercent, string ROIPercent,string BV)
        {
            Master obj = new Master();
            try
            {
                obj.ProductName = ProductName;
                obj.ProductPrice = ProductPrice;
                obj.IGST = IGST;
                obj.CGST = CGST;
                obj.SGST = SGST;
                obj.BinaryPercent = BinaryPercent;
                obj.DirectPercent = DirectPercent;
                obj.ROIPercent = ROIPercent;
                obj.BV = BV;
                obj.AddedBy = Session["PK_AdminId"].ToString();

                DataSet ds = obj.SaveProduct();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        obj.Result = "Product saved successfully";
                    }
                    else
                    {
                        obj.Result = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                obj.Result = ex.Message;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateProduct(string ProductID, string ProductName, string ProductPrice, string IGST, string CGST, string SGST, string BinaryPercent, string DirectPercent, string ROIPercent,string BV)
        {
            Master obj = new Master();
            try
            {
                obj.ProductID = ProductID;
                obj.ProductName = ProductName;
                obj.ProductPrice = ProductPrice;
                obj.IGST = IGST;
                obj.CGST = CGST;
                obj.SGST = SGST;
                obj.BinaryPercent = BinaryPercent;
                obj.DirectPercent = DirectPercent;
                obj.ROIPercent = ROIPercent;
                obj.BV = BV;
                obj.UpdatedBy = Session["PK_AdminId"].ToString();

                DataSet ds = obj.UpdateProduct();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        obj.Result = "Product updated successfully";
                    }
                    else
                    {
                        obj.Result = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
              
            }
            catch (Exception ex)
            {
                obj.Result = ex.Message;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region NewsMaster

        public ActionResult AddNews(string NewsID)
        {
            if (NewsID != null)
            {
                Master obj = new Master();
                try
                {
                    obj.NewsID = NewsID;

                    DataSet ds = obj.NewsList();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        obj.NewsID = ds.Tables[0].Rows[0]["PK_NewsID"].ToString();
                        obj.NewsDate = ds.Tables[0].Rows[0]["NewsDate"].ToString();
                        obj.NewsHeading = ds.Tables[0].Rows[0]["NewsHeading"].ToString();
                        obj.NewsBody = ds.Tables[0].Rows[0]["NewsBody"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    TempData["News"] = ex.Message;
                }
                return View(obj);
            }
            else
            {
                return View();
            }
        }

        public ActionResult SaveNews(string NewsHeading, string NewsBody)
        {
            Master obj = new Master();
            try
            {
                obj.NewsHeading = NewsHeading;
                obj.NewsBody = NewsBody;
                obj.AddedBy = Session["PK_AdminId"].ToString();

                DataSet ds = obj.SaveNews();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        obj.Result = "News saved successfully";
                    }
                    else
                    {
                        obj.Result = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                obj.Result = ex.Message;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateNews(string NewsID, string NewsHeading, string NewsBody)
        {
            Master obj = new Master();
            try
            {
                obj.NewsID = NewsID;
                obj.NewsHeading = NewsHeading;
                obj.NewsBody = NewsBody;
                obj.UpdatedBy = Session["PK_AdminId"].ToString();

                DataSet ds = obj.UpdateNews();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        obj.Result = "News updated successfully";
                    }
                    else
                    {
                        obj.Result = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                obj.Result = ex.Message;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NewsList(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.NewsList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.NewsID = r["PK_NewsID"].ToString();
                    obj.NewsDate = r["NewsDate"].ToString();
                    obj.NewsHeading = r["NewsHeading"].ToString();
                    obj.NewsBody = r["NewsBody"].ToString();
                    
                    lst.Add(obj);
                }
                model.lstNews = lst;
            }
            return View(model);
        }

        public ActionResult DeleteNews(string id)
        {
            string FormName = "";
            string Controller = "";
            try
            {
                Master obj = new Master();
                obj.NewsID = id;
                obj.AddedBy = Session["PK_AdminId"].ToString();
                DataSet ds = obj.DeleteNews();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0][0].ToString() == "1"))
                    {
                        TempData["Product"] = "News deleted successfully";
                        FormName = "NewsList";
                        Controller = "Master";
                    }
                    else
                    {
                        TempData["Product"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        FormName = "NewsList";
                        Controller = "Master";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Product"] = ex.Message;
                FormName = "NewsList";
                Controller = "Master";
            }

            return RedirectToAction(FormName, Controller);
        }

        #endregion

        #region Site

        public ActionResult SiteMaster(string SiteID)
        {
            Master model = new Master();
        
            if (SiteID != null)
            {
                model.SiteID = SiteID;
                List<Master> lst = new List<Master>();
                DataSet dsSite = model.GetSiteList();
                if (dsSite != null && dsSite.Tables.Count > 0)
                {
                    model.SiteName = dsSite.Tables[0].Rows[0]["SiteName"].ToString();
                    model.Location = dsSite.Tables[0].Rows[0]["Location"].ToString();
                }
            }

            return View(model);
        }


        [HttpPost]
        [ActionName("SiteMaster")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult SaveSite(Master obj)
        {
            try
            {
               
                obj.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = new DataSet();
                ds = obj.SaveSite();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["SiteMaster"] = "Site saved successfully";
                    }
                    else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        TempData["SiteMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["SiteMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }

            }
            catch (Exception ex)
            {
                TempData["SiteMaster"] = ex.Message;
            }
            return RedirectToAction("SiteMaster", "Master");
        }

        [HttpPost]
        [ActionName("SiteMaster")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateSite(Master obj)
        {
            try
            {
                obj.UpdatedBy= Session["Pk_AdminId"].ToString();
                DataSet ds = new DataSet();
                ds = obj.UpdateSite();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["SiteMasterList"] = "Site Updated successfully";
                    }
                    else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        TempData["SiteMaster"] = ds.Tables[0].Rows[0][0].ToString();
                    }
                }
                else
                {
                    TempData["SiteMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }

            }
            catch (Exception ex)
            {
                TempData["SiteMaster"] = ex.Message;
            }
            return RedirectToAction("SiteMasterList", "Master");
        }

        public ActionResult SiteMasterList(Master model)
        {
            List<Master> lst = new List<Master>();

            DataSet ds = model.GetSiteList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.SiteID = r["PK_SiteID"].ToString();
                    obj.EncryptKey = Crypto.Encrypt(r["PK_SiteID"].ToString());
                    obj.SiteName = r["SiteName"].ToString();
                    obj.Location = r["Location"].ToString();
                    lst.Add(obj);
                }
                model.lstSite = lst;
            }
            return View(model);
        }

        public ActionResult DeleteSite(string id)
        {
            string FormName = "";
            string Controller = "";
            try
            {
                Master obj = new Master();
                obj.SiteID = id;
                obj.UpdatedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = obj.DeleteSite();

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["SiteMasterList"] = "Site deleted successfully";
                        FormName = "SiteMasterList";
                        Controller = "Master";
                    }
                    else
                    {
                        TempData["SiteMasterList"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        FormName = "SiteMasterList";
                        Controller = "Master";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["SiteMasterList"] = ex.Message;
                FormName = "SiteMasterList";
                Controller = "Master";
            }
            return RedirectToAction(FormName, Controller);
        }

        public ActionResult GetSiteDetails(string SiteID)
        {
            try
            {
                Master model = new Master();
                model.SiteID = SiteID;

                #region GetSectors
                List<SelectListItem> ddlSector = new List<SelectListItem>();
                DataSet dsSector = model.GetSectorList();

                if (dsSector != null && dsSector.Tables.Count > 0)
                {
                    foreach (DataRow r in dsSector.Tables[0].Rows)
                    {
                        ddlSector.Add(new SelectListItem { Text = r["SectorName"].ToString(), Value = r["PK_SectorID"].ToString() });

                    }
                }

                model.Result = "yes";
                ViewBag.ddlSector = ddlSector;
                model.ddlSector = ddlSector;
                #endregion

                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


        #endregion

        #region SectorMaster

        public ActionResult SectorMaster(string SectorID)
        {
            Master model = new Master();
            #region ddlSite
            Master obj = new Master();
            int count = 0;
            List<SelectListItem> ddlSite = new List<SelectListItem>();
            DataSet ds1 = obj.GetSiteList();
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds1.Tables[0].Rows)
                {
                    if (count == 0)
                    {
                        ddlSite.Add(new SelectListItem { Text = "Select Site", Value = "0" });
                    }
                    ddlSite.Add(new SelectListItem { Text = r["SiteName"].ToString(), Value = r["PK_SiteID"].ToString() });
                    count = count + 1;
                }
            }

            ViewBag.ddlSite = ddlSite;

            #endregion

            if (SectorID != null)
            {
                model.SectorID = SectorID;
                List<Master> lst = new List<Master>();
                DataSet dsSite = model.GetSector();
                if (dsSite != null && dsSite.Tables.Count > 0)
                {
                    model.SiteName = dsSite.Tables[0].Rows[0]["SiteName"].ToString();
                    model.SiteID = dsSite.Tables[0].Rows[0]["FK_SiteID"].ToString();
                    model.SectorID = dsSite.Tables[0].Rows[0]["PK_SectorID"].ToString();
                    model.SectorName = dsSite.Tables[0].Rows[0]["SectorName"].ToString();
                }
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("SectorMaster")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult SaveSector(Master obj)
        {
            try
            {

                obj.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = new DataSet();
                ds = obj.SaveSector();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["SectorMaster"] = "Sector saved successfully";
                    }
                    else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        TempData["SectorMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["SectorMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }

            }
            catch (Exception ex)
            {
                TempData["SectorMaster"] = ex.Message;
            }
            return RedirectToAction("SectorMaster", "Master");
        }

        [HttpPost]
        [ActionName("SectorMaster")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateSector(Master obj)
        {
            try
            {

                obj.UpdatedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = new DataSet();
                ds = obj.UpdateSector();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["SectorList"] = "Sector updated successfully";
                    }
                    else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        TempData["SectorMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["SectorMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }

            }
            catch (Exception ex)
            {
                TempData["SectorMaster"] = ex.Message;
            }
            return RedirectToAction("SectorList", "Master");
        }

        public ActionResult SectorList(Master model)
        {
            List<Master> lst = new List<Master>();

            DataSet ds = model.GetSector();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.SiteName = r["SiteName"].ToString();
                    obj.SectorID = r["PK_SectorID"].ToString();
                    obj.SiteID = r["FK_SiteID"].ToString();
                    obj.EncryptKey = Crypto.Encrypt(r["PK_SectorID"].ToString());
                    obj.SectorName = r["SectorName"].ToString();

                    lst.Add(obj);
                }
                model.lstSector = lst;
            }
            return View(model);
        }

        public ActionResult DeleteSector(string id)
        {
            string FormName = "";
            string Controller = "";
            try
            {
                Master obj = new Master();
                obj.SectorID = id;
                obj.UpdatedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = obj.DeleteSector();

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["SectorList"] = "Sector deleted successfully";
                        FormName = "SectorList";
                        Controller = "Master";
                    }
                    else
                    {
                        TempData["SectorList"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        FormName = "SectorList";
                        Controller = "Master";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["SectorList"] = ex.Message;
                FormName = "SectorList";
                Controller = "Master";
            }
            return RedirectToAction(FormName, Controller);
        }

        #endregion

        #region BlockMaster
        public ActionResult BlockMaster(string BlockID)
        {
            Master model = new Master();
            if (BlockID != null)
            {
                model.BlockID = BlockID;

                DataSet dsSite = model.GetBlockList();
                if (dsSite != null && dsSite.Tables.Count > 0)
                {
                    model.SiteName = dsSite.Tables[0].Rows[0]["SiteName"].ToString();
                    model.SiteID = dsSite.Tables[0].Rows[0]["PK_SiteID"].ToString();
                    model.SectorID = dsSite.Tables[0].Rows[0]["PK_SectorID"].ToString();
                    model.SectorName = dsSite.Tables[0].Rows[0]["SectorName"].ToString();
                    model.BlockName = dsSite.Tables[0].Rows[0]["BlockName"].ToString();
                    model.BlockID = dsSite.Tables[0].Rows[0]["PK_BlockID"].ToString();



                    #region GetSectors
                    List<SelectListItem> ddlSector = new List<SelectListItem>();
                    DataSet dsSector = model.GetSectorList();

                    if (dsSector != null && dsSector.Tables.Count > 0)
                    {
                        foreach (DataRow r in dsSector.Tables[0].Rows)
                        {
                            ddlSector.Add(new SelectListItem { Text = r["SectorName"].ToString(), Value = r["PK_SectorID"].ToString() });

                        }
                    }
                    ViewBag.ddlSector = ddlSector;
                    #endregion
                    model.SectorID = dsSite.Tables[0].Rows[0]["PK_SectorID"].ToString();
                    #region BlockList
                    List<SelectListItem> lstBlock = new List<SelectListItem>();
                    Master objmodel = new Master();
                    objmodel.SiteID = dsSite.Tables[0].Rows[0]["PK_SiteID"].ToString();


                    ViewBag.ddlBlock = lstBlock;
                    #endregion

                }
            }
            else
            {

                List<SelectListItem> ddlSector = new List<SelectListItem>();
                ddlSector.Add(new SelectListItem { Text = "Select Sector", Value = "0" });
                ViewBag.ddlSector = ddlSector;


            }

            #region ddlSite
            int count1 = 0;
            List<SelectListItem> ddlSite = new List<SelectListItem>();
            DataSet Site = model.GetSiteList();
            if (Site != null && Site.Tables.Count > 0 && Site.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in Site.Tables[0].Rows)
                {
                    if (count1 == 0)
                    {
                        ddlSite.Add(new SelectListItem { Text = "Select Site", Value = "0" });
                    }
                    ddlSite.Add(new SelectListItem { Text = r["SiteName"].ToString(), Value = r["PK_SiteID"].ToString() });
                    count1 = count1 + 1;

                }
            }
            ViewBag.ddlSite = ddlSite;
            #endregion

            return View(model);

        }

        [HttpPost]
        [ActionName("BlockMaster")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult SaveBlock(Master obj)
        {
            try
            {
                obj.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = new DataSet();
                ds = obj.SaveBlock();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["BlockMaster"] = "Block saved successfully";
                    }
                    else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        TempData["BlockMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["BlockMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }

            }
            catch (Exception ex)
            {
                TempData["BlockMaster"] = ex.Message;
            }
            return RedirectToAction("BlockMaster", "Master");
        }

        [HttpPost]
        [ActionName("BlockMaster")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateBlock(Master obj)
        {
            try
            {

                obj.UpdatedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = new DataSet();
                ds = obj.UpdateBlock();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["BlockList"] = "Block updated successfully";
                    }
                    else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        TempData["BlockMaster"] = ds.Tables[0].Rows[0][0].ToString();
                    }
                }
                else
                {
                    TempData["BlockMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }

            }
            catch (Exception ex)
            {
                TempData["BlockMaster"] = ex.Message;
            }
            return RedirectToAction("BlockList", "Master");
        }

        public ActionResult BlockList(Master model)
        {
            List<Master> lst = new List<Master>();

            DataSet ds = model.GetBlockList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.SiteName = r["SiteName"].ToString();
                    obj.SectorID = r["PK_SectorID"].ToString();
                    obj.EncryptKey = Crypto.Encrypt(r["PK_SectorID"].ToString());
                    obj.SiteID = r["PK_SiteID"].ToString();
                    obj.SectorName = r["SectorName"].ToString();
                    obj.BlockID = r["PK_BlockID"].ToString();
                    obj.BlockName = r["BlockName"].ToString();

                    lst.Add(obj);
                }
                model.lstBlock1 = lst;
            }
            return View(model);
        }

        public ActionResult DeleteBlock(string id)
        {
            string FormName = "";
            string Controller = "";
            try
            {
                Master obj = new Master();
                obj.BlockID = id;
                obj.UpdatedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = obj.DeleteBlock();

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["BlockMaster"] = "Block deleted successfully";
                        FormName = "BlockList";
                        Controller = "Master";
                    }
                    else
                    {
                        TempData["BlockMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        FormName = "BlockList";
                        Controller = "Master";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["BlockMaster"] = ex.Message;
                FormName = "BlockList";
                Controller = "Master";
            }
            return RedirectToAction(FormName, Controller);
        }

        #endregion

        public ActionResult NoticeMaster(string PK_NoticeMasterId)
        {
            Master model = new Master();
            if (PK_NoticeMasterId != null)
            {
                model.PK_NoticeMasterId = PK_NoticeMasterId;
                List<Master> lst = new List<Master>();
                DataSet ds = model.ListNoticeMaster();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                    model.News = ds.Tables[0].Rows[0]["News"].ToString();
                    model.PK_NoticeMasterId = ds.Tables[0].Rows[0]["PK_NoticeMasterId"].ToString();
                }
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("NoticeMaster")]
        [OnAction(ButtonName = "btnSave")]
        public ActionResult SaveNoticeMaster(Master obj)
        {
            try
            {

                obj.AddedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = new DataSet();
                ds = obj.SaveNoticeMaster();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["NoticeMaster"] = "Notice saved successfully";
                    }
                    else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        TempData["NoticeMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    TempData["NoticeMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }

            }
            catch (Exception ex)
            {
                TempData["NoticeMaster"] = ex.Message;
            }
            return RedirectToAction("NoticeMaster", "Master");
        }


        public ActionResult NoticeMasterList(Master model)
        {
            List<Master> lst = new List<Master>();
            DataSet ds = model.ListNoticeMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Master obj = new Master();
                    obj.PK_NoticeMasterId = r["PK_NoticeMasterId"].ToString();
                    obj.Title = r["Title"].ToString();
                    obj.AddedBy = r["AddedBy"].ToString();
                    obj.News = r["News"].ToString();
                    lst.Add(obj);
                }
                model.NoticeMasterlist = lst;
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("NoticeMaster")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateNoticeMaster(Master obj)
        {
            try
            {
                obj.UpdatedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = new DataSet();
                ds = obj.UpdateNotice();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["NoticeMasterList"] = "Notice Updated successfully";
                    }
                    else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        TempData["NoticeMaster"] = ds.Tables[0].Rows[0][0].ToString();
                    }
                }
                else
                {
                    TempData["NoticeMaster"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }

            }
            catch (Exception ex)
            {
                TempData["NoticeMaster"] = ex.Message;
            }
            return RedirectToAction("NoticeMasterList", "Master");
        }


        public ActionResult DeleteNotice(string id)
        {
            string FormName = "";
            string Controller = "";
            try
            {
                Master obj = new Master();
                obj.PK_NoticeMasterId = id;
                obj.UpdatedBy = Session["Pk_AdminId"].ToString();
                DataSet ds = obj.DeleteNotice();

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["NoticeMasterList"] = "Notice deleted successfully";
                        FormName = "NoticeMasterList";
                        Controller = "Master";
                    }
                    else
                    {
                        TempData["NoticeMasterList"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        FormName = "NoticeMasterList";
                        Controller = "Master";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["NoticeMasterList"] = ex.Message;
                FormName = "NoticeMasterList";
                Controller = "Master";
            }
            return RedirectToAction(FormName, Controller);
        }

    }
}
