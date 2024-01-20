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
    public class DownlineController : BaseController
    {
        //
        // GET: /Downline/

        public ActionResult DirectList()
        {
            List<SelectListItem> AssociateStatus = Common.AssociateStatus();
            ViewBag.ddlStatus = AssociateStatus;
            List<SelectListItem> Leg = Common.Leg();
            ViewBag.ddlleg = Leg;

            Reports model = new Reports();
            List<Reports> lst = new List<Reports>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds = model.GetDirectList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Reports obj = new Reports();
                    obj.Mobile = r["Mobile"].ToString();
                    obj.Email = r["Email"].ToString();
                    obj.JoiningDate = r["JoiningDate"].ToString();
                    obj.Leg = r["Leg"].ToString();
                    obj.PermanentDate = (r["PermanentDate"].ToString());
                    obj.Status = (r["Status"].ToString());
                    obj.SponsorId = (r["LoginId"].ToString());
                    obj.SponsorName = (r["Name"].ToString());
                    obj.Package = (r["ProductName"].ToString());
                    lst.Add(obj);
                }
                model.lstassociate = lst;

            }
            return View(model);
        }

        [HttpPost]
        [ActionName("DirectList")]
        [OnAction(ButtonName = "Search")]
        public ActionResult DirectListBy(Reports model)
        {

            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            List<Reports> lst = new List<Reports>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds = model.GetDirectList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Reports obj = new Reports();
                    obj.Mobile = r["Mobile"].ToString();
                    obj.Email = r["Email"].ToString();
                    obj.Leg = r["Leg"].ToString();
                    obj.JoiningDate = r["JoiningDate"].ToString();
                    obj.PermanentDate = (r["PermanentDate"].ToString());
                    obj.Status = (r["Status"].ToString());
                    obj.SponsorId = (r["LoginId"].ToString());
                    obj.SponsorName = (r["Name"].ToString());
                    obj.Package = (r["ProductName"].ToString());
                    lst.Add(obj);
                }
                model.lstassociate = lst;

            }
            List<SelectListItem> AssociateStatus = Common.AssociateStatus();
            ViewBag.ddlStatus = AssociateStatus;
            List<SelectListItem> Leg = Common.Leg();
            ViewBag.ddlleg = Leg;
            return View(model);
        }


        public ActionResult DownLineList()
        {
            List<SelectListItem> AssociateStatus = Common.AssociateStatus();
            ViewBag.ddlStatus = AssociateStatus;
            List<SelectListItem> Leg = Common.Leg();
            ViewBag.ddlleg = Leg;

            Reports model = new Reports();
            List<Reports> lst = new List<Reports>();
            model.LoginId = Session["LoginId"].ToString();
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            DataSet ds = model.GetDownlineList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Reports obj = new Reports();
                    obj.Pk_UserId = Crypto.Encrypt(r["Pk_UserId"].ToString());
                    obj.Name = r["Name"].ToString();
                    obj.LoginId = r["LoginId"].ToString();
                    obj.JoiningDate = r["JoiningDate"].ToString();
                    obj.Leg = r["Leg"].ToString();
                    obj.PermanentDate = (r["PermanentDate"].ToString());
                    obj.Status = (r["Status"].ToString());
                    obj.Mobile = (r["Mobile"].ToString());
                    obj.Package = (r["ProductName"].ToString());
                    lst.Add(obj);
                }
                model.lstassociate = lst;


            }
            return View(model);
        }
        [HttpPost]
        [ActionName("DownLineList")]
        [OnAction(ButtonName = "btnSearch")]
        public ActionResult DownLineListBy(Reports model)
        {

            List<Reports> lst = new List<Reports>();
            model.LoginId = Session["LoginId"].ToString();
            DataSet ds = model.GetDownlineList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Reports obj = new Reports();
                    obj.Pk_UserId = Crypto.Encrypt(r["Pk_UserId"].ToString());
                    obj.Name = r["Name"].ToString();
                    obj.LoginId = r["LoginId"].ToString();
                    obj.JoiningDate = r["JoiningDate"].ToString();
                    obj.Leg = r["Leg"].ToString();
                    obj.PermanentDate = (r["PermanentDate"].ToString());
                    obj.Status = (r["Status"].ToString());
                    obj.Mobile = (r["Mobile"].ToString());
                    obj.Package = (r["ProductName"].ToString());
                    lst.Add(obj);
                }
                model.lstassociate = lst;
            }
            List<SelectListItem> AssociateStatus = Common.AssociateStatus();
            ViewBag.ddlStatus = AssociateStatus;
            List<SelectListItem> Leg = Common.Leg();
            ViewBag.ddlleg = Leg;
            return View(model);
        }

        public ActionResult UpdateProfile(string UserId)
        {
            Reports obj = new Reports();
            List<Reports> lst1 = new List<Reports>();
            #region ForQueryString
            if (Request.QueryString["Pid"] != null)
            {
                obj.SponsorId = Request.QueryString["Pid"].ToString();
            }
            if (Request.QueryString["lg"] != null)
            {
                obj.Leg = Request.QueryString["lg"].ToString();
                if (obj.Leg == "Right")
                {
                    ViewBag.RightChecked = "checked";
                    ViewBag.LeftChecked = "";
                    ViewBag.Disabled = "Disabled";
                }
                else
                {
                    ViewBag.RightChecked = "";
                    ViewBag.LeftChecked = "checked";
                    ViewBag.Disabled = "Disabled";
                }
            }
            if (Request.QueryString["Pid"] != null)
            {
                Reports objcomm = new Reports();
                objcomm.ReferBy = obj.SponsorId;
                DataSet ds = objcomm.GetDownMemberDetails();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    obj.SponsorName = ds.Tables[0].Rows[0]["FullName"].ToString();



                }
            }
            else
            {
                ViewBag.RightChecked = "";
                ViewBag.LeftChecked = "checked";
            }
            #endregion ForQueryString


            #region ddlgender
            List<SelectListItem> ddlgender = Common.BindGender();
            ViewBag.ddlgender = ddlgender;
            #endregion ddlgender



            List<SelectListItem> AssociateStatus = Common.AssociateStatus();
            ViewBag.ddlStatus = AssociateStatus;

            if (UserId != null)
            {
                obj.Pk_UserId = Crypto.Decrypt(UserId);
                DataSet ds = obj.GetDownlineListforUpdateProfile();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    obj.Pk_UserId = ds.Tables[0].Rows[0]["Pk_UserId"].ToString();
                    obj.SponsorId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                    obj.LoginIDD = ds.Tables[0].Rows[0]["LoginId"].ToString();
                    obj.SponsorName = ds.Tables[0].Rows[0]["Name"].ToString();
                    obj.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    obj.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                    obj.JoiningDate = ds.Tables[0].Rows[0]["JoiningDate"].ToString();
                    //obj.Leg = ds.Tables[0].Rows[0]["Leg"].ToString();
                    obj.PermanentDate = ds.Tables[0].Rows[0]["PermanentDate"].ToString();
                    obj.MobileNo = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    obj.Package = ds.Tables[0].Rows[0]["ProductName"].ToString();
                    obj.Status = ds.Tables[0].Rows[0]["Status"].ToString();
                    obj.FromActivationDate = ds.Tables[0].Rows[0]["PermanentDate"].ToString();
                    obj.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    obj.Gender = ds.Tables[0].Rows[0]["Sex"].ToString();
                    obj.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    obj.PinCode = ds.Tables[0].Rows[0]["PinCode"].ToString();
                    obj.AdharNo = ds.Tables[0].Rows[0]["AdharNumber"].ToString();
                    obj.PanCard = ds.Tables[0].Rows[0]["PanNumber"].ToString();
                    obj.State = ds.Tables[0].Rows[0]["State"].ToString();
                    obj.City = ds.Tables[0].Rows[0]["City"].ToString();
                    lst1.Add(obj);
                }

            }
            return View(obj);
        }

        


        public ActionResult UpdateProfileAction(Reports model, string UserId,string SponsorId,string LoginIDD,string FirstName, string LastName,string JoiningDate, string Package,string MobileNo,string Status, string Leg, string Email, string Gender, string Address, string PinCode, string AdharNo, string PanCard, string State, string City)
        {
            try
            {
                model.UserID = UserId;
                model.SponsorId = SponsorId;
                model.LoginIDD = LoginIDD;
                model.FirstName = FirstName;
                model.LastName = LastName;
                model.JoiningDate = JoiningDate;
                model.Package = Package;
                //model.FromActivationDate = FromActivationDate;
                model.MobileNo = MobileNo;
                model.Status = Status;
                model.Leg = Leg;
                model.Email = Email;
                model.Gender = Gender;
                model.Address = Address;
                model.PinCode = PinCode;
                model.AdharNo = AdharNo;
                model.PanCard = PanCard;
                model.State = State;
                model.City = City;

                //model.JoiningDate = string.IsNullOrEmpty(model.JoiningDate) ? null : Common.ConvertToSystemDate(model.JoiningDate, "dd-MM-yyyy");
                //model.FromActivationDate = string.IsNullOrEmpty(model.FromActivationDate) ? null : Common.ConvertToSystemDate(model.FromActivationDate, "dd-MM-yyyy");
                model.UpdatedBy = Session["Pk_userId"].ToString(); 
                DataSet ds = model.UpdateProfile();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["MSG"].ToString() == "1")
                    {
                        model.Response = "1";
                        //TempData["Registration"] = "Profile Updated successfully !!";
                    }                   
                    else
                    {
                        model.Response = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex) {
                model.Response = ex.Message;
            }
            return Json(model,JsonRequestBehavior.AllowGet);
        }

    }
}
