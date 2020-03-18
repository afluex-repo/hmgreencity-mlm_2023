using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMGreenCityMLM.Models;

namespace HMGreenCityMLM.Controllers
{
    public class AccountsController : AdminBaseController
    {
        public ActionResult Topup()
        {
            Common obj = new Common();
            #region GetSite
            List<SelectListItem> ddlsite = new List<SelectListItem>();
            List<SelectListItem> ddlsector = new List<SelectListItem>();
            List<SelectListItem> ddlblock = new List<SelectListItem>();
            DataSet ds = obj.GetSite();
            ddlsite.Add(new SelectListItem { Text = "Select Site", Value = "0" });
            ddlsector.Add(new SelectListItem { Text = "Select Sector", Value = "0" });
            ddlblock.Add(new SelectListItem { Text = "Select Block", Value = "0" });
            if (ds!=null && ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                { ddlsite.Add(new SelectListItem { Text = r["SiteName"].ToString(), Value = r["PK_SiteID"].ToString() }); }
            }
            ViewBag.ddlsite = ddlsite;
            ViewBag.ddlsector = ddlsector;
            ViewBag.ddlblock = ddlblock;
            #endregion GetSite
            return View();
        }
        public ActionResult FillAmount(string ProductId)
        {
            Wallet obj = new Wallet();
            obj.Package = ProductId;
            DataSet ds = obj.BindPriceByProduct();
            if (ds.Tables != null && ds.Tables[2].Rows.Count > 0)
            {
                obj.Amount = ds.Tables[2].Rows[0]["ProductPrice"].ToString();
            }
            else { }
            return Json(obj, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetMemberName(string LoginId)
        {
            Common obj = new Common();
            obj.ReferBy = LoginId;
            DataSet ds = obj.GetMemberDetails();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {


                obj.DisplayName = ds.Tables[0].Rows[0]["FullName"].ToString();

                obj.Result = "Yes";

            }
            else { obj.Result = "No"; }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TopUpByAdmin(Wallet obj)
        {
            try
            {
                obj.TopUpDate = Common.ConvertToSystemDate(obj.TopUpDate, "dd/MM/yyyy");
                obj.AddedBy = Session["Pk_AdminId"].ToString();

                DataSet ds = obj.TopUpIdByAdmin();
                if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["Topup"] = "TopUp Done successfully";
                    }
                    else
                    {
                        TempData["Topup"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else { }
            }
            catch (Exception ex)
            {
                TempData["Topup"] = ex.Message;
            }
            return RedirectToAction("Topup", "Accounts");
        }

        #region ApprovePayoutRequest
        public ActionResult ApprovepayoutRequest()
        {
            Wallet objewallet = new Wallet();


            List<Wallet> lst = new List<Wallet>();
            DataSet ds = objewallet.GetPayoutRequest();
            if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Wallet Objload = new Wallet();
                    Objload.Amount = dr["Amount"].ToString();
                    Objload.LoginId = dr["LoginId"].ToString();
                    Objload.DisplayName = dr["Name"].ToString();
                    Objload.Status = dr["Status"].ToString();
                    Objload.Pk_RequestId = dr["Pk_RequestId"].ToString();
                    Objload.AddedOn = dr["RequestedDate"].ToString();
                    lst.Add(Objload);
                }
                objewallet.lstPayoutrequest = lst;
            }
            return View(objewallet);
        }
        public ActionResult ApproveRequest(string Id)
        {
            try
            {
                Wallet obj = new Wallet();
                obj.AddedBy = Session["Pk_AdminId"].ToString();
                obj.Pk_RequestId = Id;
                obj.Status = "Approved";
                DataSet ds = obj.ApprovePayputRequest();
                if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["ApproveRequest"] = "Payout Approved Successfully";
                    }
                    else
                    {
                        TempData["ApproveRequest"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }

                }
                else { }

            }
            catch(Exception ex)
            {
                TempData["ApproveRequest"] = ex.Message;
            }
            return RedirectToAction("ApprovepayoutRequest", "Accounts");
        }
        public ActionResult DeclineRequest(string Id)
        {
            try
            {
                Wallet obj = new Wallet();
                obj.AddedBy = Session["Pk_AdminId"].ToString();
                obj.Pk_RequestId = Id;
                obj.Status = "Declined";
                DataSet ds = obj.ApprovePayputRequest();
                if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["ApproveRequest"] = "Payout Declined Successfully";
                    }
                    else
                    {
                        TempData["ApproveRequest"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }

                }
                else { }

            }
            catch (Exception ex)
            {
                TempData["ApproveRequest"] = ex.Message;
            }
            return RedirectToAction("ApprovepayoutRequest", "Accounts");
        }
        #endregion ApprovePayoutRequest

        #region ApproveEwalletRequest
        public ActionResult ApproveEwalletRequest()
        {
            Wallet objewallet = new Wallet();


            List<Wallet> lst = new List<Wallet>();
            DataSet ds = objewallet.GetEWalletRequest();
            if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Wallet Objload = new Wallet();
                    Objload.Pk_RequestId = dr["Pk_RequestId"].ToString();
                    Objload.LoginId = dr["LoginId"].ToString();
                    Objload.DisplayName = dr["Name"].ToString();
                    Objload.Amount = dr["Amount"].ToString();
                    Objload.RequestCode = dr["RequestCode"].ToString();
                    Objload.PaymentMode = dr["PaymentMode"].ToString();
                    Objload.Status = dr["Status"].ToString();
                    Objload.DocumentImg = dr["ImageURL"].ToString();
                    Objload.BankName = dr["BankName"].ToString();
                    Objload.BankBranch = dr["BankBranch"].ToString();
                    Objload.DDChequeNo = dr["ChequeDDNo"].ToString();
                    Objload.DDChequeDate = dr["ChequeDDDate"].ToString();
                    Objload.AddedOn = dr["CreatedDate"].ToString();
                    lst.Add(Objload);
                }
                objewallet.WalletRequestList = lst;
            }
            return View(objewallet);
        }
        public ActionResult ApproveEwallet(string Id)
        {
            try
            {
                Wallet obj = new Wallet();
                obj.AddedBy = Session["Pk_AdminId"].ToString();
                obj.Pk_RequestId = Id;
                obj.Status = "Approved";
                DataSet ds = obj.ApproveEwalletRequest();
                if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["EApproveRequest"] = "Ewallet Approved Successfully";
                    }
                    else
                    {
                        TempData["EApproveRequest"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }

                }
                else { }

            }
            catch (Exception ex)
            {
                TempData["EApproveRequest"] = ex.Message;
            }
            return RedirectToAction("ApproveEwalletRequest", "Accounts");
        }
        public ActionResult DeclineEwwalletRequest(string Id)
        {
            try
            {
                Wallet obj = new Wallet();
                obj.AddedBy = Session["Pk_AdminId"].ToString();
                obj.Pk_RequestId = Id;
                obj.Status = "Declined";
                DataSet ds = obj.ApproveEwalletRequest();
                if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["EApproveRequest"] = "Ewallet Request Declined Successfully";
                    }
                    else
                    {
                        TempData["EApproveRequest"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }

                }
                else { }

            }
            catch (Exception ex)
            {
                TempData["EApproveRequest"] = ex.Message;
            }
            return RedirectToAction("ApproveEwalletRequest", "Accounts");
        }
        #endregion ApproveEwalletRequest

        #region ReTopUp

        public ActionResult RetopUp()
        {
            Common obj = new Common();
            #region GetSite
            List<SelectListItem> ddlsite = new List<SelectListItem>();
            List<SelectListItem> ddlsector = new List<SelectListItem>();
            List<SelectListItem> ddlblock = new List<SelectListItem>();
            DataSet ds = obj.GetSite();
            ddlsite.Add(new SelectListItem { Text = "Select Site", Value = "0" });
            ddlsector.Add(new SelectListItem { Text = "Select Sector", Value = "0" });
            ddlblock.Add(new SelectListItem { Text = "Select Block", Value = "0" });
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                { ddlsite.Add(new SelectListItem { Text = r["SiteName"].ToString(), Value = r["PK_SiteID"].ToString() }); }
            }
            ViewBag.ddlsite = ddlsite;
            ViewBag.ddlsector = ddlsector;
            ViewBag.ddlblock = ddlblock;
            #endregion GetSite
          
            return View();
        }

        public ActionResult RetopUpAction(Wallet obj)
        {
            try
            {
                obj.TopUpDate = Common.ConvertToSystemDate(obj.TopUpDate, "dd/MM/yyyy");
                obj.AddedBy = Session["Pk_AdminId"].ToString();
                obj.Package = "4";

                DataSet ds = obj.ReTopup();
                if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["Class"] = "alert alert-success";
                        TempData["Topup"] = "Re-TopUp Done successfully";
                    }
                    else
                    {
                        TempData["Class"] = "alert alert-danger";
                        TempData["Topup"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else { }
            }
            catch (Exception ex)
            {
                TempData["Class"] = "alert alert-danger";
                TempData["Topup"] = ex.Message;
            }
            return RedirectToAction("RetopUp", "Accounts");
        }
        #endregion

        #region ProductTopUp
        public ActionResult ProductTopUp()
        {
            #region Product Bind
            Common objcomm = new Common();
            List<SelectListItem> ddlProduct = new List<SelectListItem>();
            DataSet ds1 = objcomm.BindProduct();
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[2].Rows.Count > 0)
            {
                int count = 0;
                foreach (DataRow r in ds1.Tables[2].Rows)
                {
                    if (count == 0)
                    {
                        ddlProduct.Add(new SelectListItem { Text = "Select", Value = "0" });
                    }
                    ddlProduct.Add(new SelectListItem { Text = r["ProductName"].ToString(), Value = r["Pk_ProductId"].ToString() });
                    count++;
                }
            }

            ViewBag.ddlProduct = ddlProduct;

            #endregion
            return View();
        }

        public ActionResult TopUpByAdminProduct(Wallet obj)
        {
            try
            {
                obj.TopUpDate = Common.ConvertToSystemDate(obj.TopUpDate, "dd/MM/yyyy");
                obj.AddedBy = Session["Pk_AdminId"].ToString();

                DataSet ds = obj.TopUpIdByAdminProduct();
                if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["ProductTopup"] = "TopUp Done successfully";
                    }
                    else
                    {
                        TempData["ProductTopup"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else { }
            }
            catch (Exception ex)
            {
                TempData["ProductTopup"] = ex.Message;
            }
            return RedirectToAction("ProductTopUp", "Accounts");
        }



        #endregion ProductTopUp

        public ActionResult GetSectorName(string Fk_SiteId)
        {
            try
            {
                Wallet model = new Wallet();
                model.Fk_SiteId = Fk_SiteId;

               
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
                model.ddlSector = ddlSector;
                #endregion
               

                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


        public ActionResult GetBlockName(string Fk_SiteId,string FK_SectorId)
        {
            try
            {
                Wallet model = new Wallet();
                model.Fk_SiteId = Fk_SiteId;
                model.FK_SectorId = FK_SectorId;

                #region GetBlock
                List<SelectListItem> ddlblock = new List<SelectListItem>();
                DataSet dsBlock = model.GetBlockList();

                if (dsBlock != null && dsBlock.Tables.Count > 0)
                {
                    foreach (DataRow r in dsBlock.Tables[0].Rows)
                    {
                        ddlblock.Add(new SelectListItem { Text = r["BlockName"].ToString(), Value = r["PK_BlockID"].ToString() });

                    }
                }
                model.ddlblock = ddlblock;
                #endregion


                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}
