using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using HMGreenCityMLM.Models;
using HMGreenCityMLM.Filter;
using System.Net;
using System.Xml;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace HMGreenCityMLM.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(Reports obj)
        {
            if (Session["Count"] == null)
            {
                DataSet ds = obj.RewardListForWebsite();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    Session["Count"] = "1";
                    return RedirectToAction("RewardData");
                }
                else
                {
                    Session["Count"] = null;
                    return View();
                }
            }
            else
            {
                Session["Count"] = null;
                return View();
            }
            
        }
        public ActionResult RewardData(Reports obj)
        {
            List<Reports> lsttop4 = new List<Reports>();
            List<Reports> lst = new List<Reports>();
            DataSet ds = obj.RewardListForWebsite();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ViewBag.TotalCount = ds.Tables[1].Rows.Count;
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Reports obj1 = new Reports();

                    obj1.RewardImage = r["RewardImage"].ToString();
                    obj1.RewardName = r["RewardName"].ToString();
                   
                    lsttop4.Add(obj1);
                }
                obj.lstassociate = lsttop4;

                foreach (DataRow r in ds.Tables[1].Rows)
                {
                    Reports obj1 = new Reports();

                    obj1.PK_RewardItemId = r["PK_UserProdRewardID"].ToString();
                    obj1.RewardID = r["FK_RewardId"].ToString();
                    obj1.Status = r["Status"].ToString();
                    obj1.QualifyDate = r["QualifyDate"].ToString();
                    obj1.LoginId = r["LoginId"].ToString();
                    obj1.RewardName = r["RewardName"].ToString();
                    obj1.Name = r["FirstName"].ToString();
                    obj1.RewardImage = r["RewardImage"].ToString();

                    lst.Add(obj1);
                }
                obj.lsttopupreport = lst;
            }
            
            return View(obj);
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }
        public static HttpWebRequest LoginURL()
        {

            HttpWebRequest webRequest =
            (HttpWebRequest)WebRequest.Create(@"http://projectstatus.afluex.com/ProjectStatus/ProjectStatus");
            webRequest.ContentType = "application/json";
            webRequest.Method = "POST";
            return webRequest;
        }
        public ActionResult LoginAction(Home obj)
        {
            string FormName = "";
            string Controller = "";
            ProjectStatusResponse datalist = null;
            #region CheckProjectStatus
            string soapResult = "";
            HttpWebRequest request = LoginURL();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            string json1 = "{\"ProjectId\": \"" + 15 + "\"}";
            byte[] postBytes = Encoding.UTF8.GetBytes(json1);
            Stream requestStream = request.GetRequestStream();
            // now send it
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();

                }

                datalist = JsonConvert.DeserializeObject<ProjectStatusResponse>(soapResult);
            }
            if (datalist.Response == "0")
            {
                return RedirectToAction("Login");
            }
            #endregion CheckProjectStatus
            try
            {
                Home Modal = new Home();
                DataSet ds = obj.Login();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0]["UserType"].ToString() == "Associate"))
                    {
                        if (obj.Password == Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString()))
                        {
                            Session["LoginId"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                            Session["Pk_userId"] = ds.Tables[0].Rows[0]["Pk_userId"].ToString();
                            Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                            Session["FullName"] = ds.Tables[0].Rows[0]["FullName"].ToString();
                            Session["Password"] = ds.Tables[0].Rows[0]["Password"].ToString();
                            Session["TransPassword"] = ds.Tables[0].Rows[0]["TransPassword"].ToString();
                            Session["Profile"] = ds.Tables[0].Rows[0]["Profile"].ToString();
                            FormName = "AssociateDashBoard";
                            Controller = "User";
                        }
                        else
                        {
                            TempData["Login"] = "Incorrect Password";
                            FormName = "Login";
                            Controller = "Home";

                        }
                    }
                    else if (ds.Tables[0].Rows[0]["UserType"].ToString() == "Admin")
                    {
                        Session["LoginId"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                        Session["Pk_AdminId"] = ds.Tables[0].Rows[0]["Pk_adminId"].ToString();
                        Session["UsertypeName"] = ds.Tables[0].Rows[0]["UsertypeName"].ToString();
                        Session["Name"] = ds.Tables[0].Rows[0]["Name"].ToString();

                        if (ds.Tables[0].Rows[0]["isFranchiseAdmin"].ToString() == "True")
                        {
                            Session["FranchiseAdminID"] = ds.Tables[0].Rows[0]["Pk_adminId"].ToString();
                            FormName = "Registration";
                            Controller = "FranchiseAdmin";
                        }
                        else
                        {
                            FormName = "AdminDashBoard";
                            Controller = "Admin";
                        }
                    }
                    else
                    {
                        TempData["Login"] = "Incorrect LoginId Or Password";
                        FormName = "Login";
                        Controller = "Home";
                    }

                }

                else
                {
                    TempData["Login"] = "Incorrect LoginId Or Password";
                    FormName = "Login";
                    Controller = "Home";

                }
            }
            catch (Exception ex)
            {
                TempData["Login"] = ex.Message;
                FormName = "Login";
                Controller = "Home";
            }

            return RedirectToAction(FormName, Controller);



        }

        public ActionResult Registration()
        {
            Home obj = new Home();
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
                }
                else
                {
                    ViewBag.RightChecked = "";
                    ViewBag.LeftChecked = "checked";
                }
            }
            if (Request.QueryString["Pid"] != null)
            {
                Common objcomm = new Common();
                objcomm.ReferBy = obj.SponsorId;
                DataSet ds = objcomm.GetMemberDetails();
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
            return View(obj);
        }

        public ActionResult GetSponserDetails(string ReferBy)
        {
            Common obj = new Common();
            obj.ReferBy = ReferBy;
            DataSet ds = obj.GetMemberDetails();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                obj.DisplayName = ds.Tables[0].Rows[0]["FullName"].ToString();

                obj.Result = "Yes";

            }
            else { obj.Result = "Invalid SponsorId"; }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RegistrationAction(string SponsorId, string FirstName, string LastName, string Email, string MobileNo, string PanCard, string Address, string Gender, string OTP, string PinCode, string Leg)

        {
            Home obj = new Home();

            try
            {
                obj.SponsorId = SponsorId;
                obj.FirstName = FirstName;
                obj.LastName = LastName;
                obj.Email = Email;
                obj.MobileNo = MobileNo;
                obj.PanCard = PanCard;
                obj.Address = Address;
                obj.RegistrationBy = "Web";
                obj.Gender = Gender;
                obj.PinCode = PinCode;
                obj.Leg = Leg;
                string password = Common.GenerateRandom();
                obj.Password = Crypto.Encrypt(password);
                DataSet ds = obj.Registration();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        Session["LoginId"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                        Session["DisplayName"] = ds.Tables[0].Rows[0]["Name"].ToString();
                        Session["PassWord"] = Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString());
                        Session["Transpassword"] = Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString());
                        Session["MobileNo"] = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                        try
                        {
                            string str2 = BLSMS.Registration(ds.Tables[0].Rows[0]["Name"].ToString(), ds.Tables[0].Rows[0]["LoginId"].ToString(), Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString()));
                            BLSMS.SendSMSNew(MobileNo, str2);
                        }
                        catch { }
                        obj.Response = "1";

                    }
                    else
                    {
                        obj.Response = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                obj.Response = ex.Message;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ConfirmRegistration()
        {
            return View();
        }

        public ActionResult GetStateCity(string PinCode)
        {
            Common obj = new Common();
            obj.PinCode = PinCode;
            DataSet ds = obj.GetStateCity();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                obj.State = ds.Tables[0].Rows[0]["State"].ToString();
                obj.City = ds.Tables[0].Rows[0]["City"].ToString();
                obj.Result = "1";
            }
            else
            {
                obj.Result = "Invalid PinCode";
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Decrypt()
        {
            return View();
        }

        //[HttpPost]
        //[ActionName("Decrypt")]
        //[OnAction(ButtonName = "btndecript")]
        //public ActionResult GetPassword(Home obj)
        //{
        //    obj.DecriptPass = Crypto.Decrypt(obj.Password);
        //    return View(obj);
        //}

        public ActionResult GetName(Common obj)
        {
            DataSet ds = obj.GetMemberDetails();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                obj.DisplayName = ds.Tables[0].Rows[0]["FullName"].ToString();

                obj.Result = "Yes";

            }
            else { obj.Result = "Invalid LoginId"; }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GeneratePlotPin(PlotPin obj)
        {
            DataSet ds = obj.GeneratePin();

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult Menu()
        {
            Home Menu = null;

            if (Session["_Menu"] != null)
            {
                Menu = (Home)Session["_Menu"];
            }
            else
            {

                Menu = Home.GetMenus(Session["Pk_AdminId"].ToString(), Session["UserTypeName"].ToString()); // pass employee id here
                Session["_Menu"] = Menu;
            }
            return PartialView("_Menu", Menu);
        }

        #region FranchiseLogin
        public ActionResult FranchiseLogin()
        {
            return View();
        }
        public ActionResult FranchiseLoginAction(Home obj)
        {
            string FormName = "";
            string Controller = "";
            try
            {
                Home Modal = new Home();
                DataSet ds = obj.FranchiseLogin();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0]["FranchiseAdmin"].ToString() == "True"))
                    {
                        if (obj.Password == Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString()))
                        {
                            Session["LoginID"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                            Session["FranchiseAdminID"] = ds.Tables[0].Rows[0]["PK_FranchsieID"].ToString();
                            Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                            Session["FullName"] = ds.Tables[0].Rows[0]["FranchiseName"].ToString();
                            Session["Password"] = ds.Tables[0].Rows[0]["Password"].ToString();
                            Session["UserTypeName"] = "Franchise";
                            FormName = "DashBoard";
                            Controller = "FranchiseAdmin";
                        }
                        else
                        {
                            TempData["Login"] = "Incorrect Password";
                            FormName = "FranchiseLogin";
                            Controller = "Home";
                        }
                    }
                    else if (ds.Tables[0].Rows[0]["FranchiseAdmin"].ToString() == "False")
                    {
                        Session["LoginID"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                        Session["FranchiseID"] = ds.Tables[0].Rows[0]["PK_FranchsieID"].ToString();
                        Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                        Session["FK_FranchiseTypeId"] = ds.Tables[0].Rows[0]["FK_FranchiseTypeId"].ToString();
                        Session["Name"] = ds.Tables[0].Rows[0]["FranchiseName"].ToString();

                        FormName = "DashBoard";
                        Controller = "Franchise";
                    }
                    else
                    {
                        TempData["Login"] = "Incorrect LoginId Or Password";
                        FormName = "FranchiseLogin";
                        Controller = "Home";
                    }
                }
                else
                {
                    TempData["Login"] = "Incorrect LoginId Or Password";
                    FormName = "FranchiseLogin";
                    Controller = "Home";

                }
            }
            catch (Exception ex)
            {
                TempData["Login"] = ex.Message;
                FormName = "FranchiseLogin";
                Controller = "Home";
            }
            return RedirectToAction(FormName, Controller);
        }
        #endregion
        #region Website
        public ActionResult LandingPage()
        {
            return View();
        }
        public ActionResult Website()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Vission()
        {
            return View();
        }
        public ActionResult CompanyDesk()
        {
            return View();
        }
        public ActionResult legal()
        {
            return View();
        }
        public ActionResult ProductList()
        {
            return View();
        }
        public ActionResult ProductCategories()
        {
            return View();
        }
        public ActionResult Packages()
        {
            return View();
        }
        public ActionResult Brochure()
        {
            return View();
        }
        public ActionResult OnePager()
        {
            return View();
        }
        public ActionResult Events()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult Ventures()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        #endregion Website
    }
}
