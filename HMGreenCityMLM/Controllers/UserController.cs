﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMGreenCityMLM.Models;
using HMGreenCityMLM.Filter;
using System.IO;
using BusinessLayer;

namespace HMGreenCityMLM.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult AssociateDashBoard()
        {
            DashBoard obj = new DashBoard();
            List<DashBoard> lstNotice = new List<DashBoard>();

            List<DashBoard> lstinvestment = new List<DashBoard>();
            obj.Fk_UserId = Session["Pk_UserId"].ToString();
            DataSet ds = obj.GetAssociateDashboard();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ViewBag.TotalDownline = ds.Tables[0].Rows[0]["TotalDownline"].ToString();
                ViewBag.TotalDirects = ds.Tables[0].Rows[0]["TotalDirect"].ToString();
                //ViewBag.ProductWalletBalance = ds.Tables[0].Rows[0]["ProductWalletBalance"].ToString();
                ViewBag.PayoutWalletBalance = ds.Tables[0].Rows[0]["PayoutWalletBalance"].ToString();
                ViewBag.TotalPayout = ds.Tables[0].Rows[0]["TotalPayout"].ToString();
                ViewBag.TotalDeduction = ds.Tables[0].Rows[0]["TotalDeduction"].ToString();
                ViewBag.TotalAdvance = ds.Tables[0].Rows[0]["TotalAdvance"].ToString();
                ViewBag.TotalActive = ds.Tables[0].Rows[0]["TotalActive"].ToString();
                ViewBag.TotalInActive = ds.Tables[0].Rows[0]["TotalInActive"].ToString();
                ViewBag.TotalHold = ds.Tables[0].Rows[0]["TotalHold"].ToString();


                ViewBag.PaidBusinessLeft = ds.Tables[2].Rows[0]["PaidBusinessLeft"].ToString();
                ViewBag.PaidBusinessRight = ds.Tables[2].Rows[0]["PaidBusinessRight"].ToString();
                ViewBag.TotalBusinessLeft = ds.Tables[2].Rows[0]["TotalBusinessLeft"].ToString();
                ViewBag.TotalBusinessRight = ds.Tables[2].Rows[0]["TotalBusinessRight"].ToString();
                ViewBag.CarryLeft = ds.Tables[2].Rows[0]["CarryLeft"].ToString();
                ViewBag.CarryRight = ds.Tables[2].Rows[0]["CarryRight"].ToString();

                //ViewBag.TeamBusiness = ds.Tables[3].Rows[0]["TeamBusiness"].ToString();
                //ViewBag.DirectBusiness = ds.Tables[4].Rows[0]["DirectBusiness"].ToString();

                //ViewBag.ProductPaidBusinessLeft = ds.Tables[3].Rows[0]["PaidBusinessLeft"].ToString();
                //ViewBag.ProductPaidBusinessRight = ds.Tables[3].Rows[0]["PaidBusinessRight"].ToString();
                //ViewBag.ProductTotalBusinessLeft = ds.Tables[3].Rows[0]["TotalBusinessLeft"].ToString();
                //ViewBag.ProductTotalBusinessRight = ds.Tables[3].Rows[0]["TotalBusinessRight"].ToString();
                //ViewBag.ProductCarryLeft = ds.Tables[3].Rows[0]["CarryLeft"].ToString();
                //ViewBag.ProductCarryRight = ds.Tables[3].Rows[0]["CarryRight"].ToString();
                
                ViewBag.UpdaidIncome = ds.Tables[0].Rows[0]["UpdaidIncome"].ToString();
                ViewBag.SelfBusiness = ds.Tables[0].Rows[0]["TotalTopUp"].ToString();
                
            }
            DashBoard model = new DashBoard();
            #region Messages

            model.Fk_UserId = Session["Pk_UserId"].ToString();

            List<DashBoard> lst1 = new List<DashBoard>();

            DataSet ds11 = model.GetAllMessages();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    DashBoard Obj = new DashBoard();
                    Obj.Pk_MessageId = r["Pk_MessageId"].ToString();
                    Obj.Fk_UserId = r["Fk_UserId"].ToString();
                    Obj.MemberName = r["Name"].ToString();
                    Obj.MessageTitle = r["MessageTitle"].ToString();
                    Obj.AddedOn = r["AddedOn"].ToString();
                    Obj.Message = r["Message"].ToString();
                    Obj.cssclass = r["cssclass"].ToString();
                    Obj.ProfilePic = r["ProfilePic"].ToString();
                    lst1.Add(Obj);
                }
                model.lstmessages = lst1;
            }
            #endregion Messages
            #region Investment
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[1].Rows)
                {
                    DashBoard Obj = new DashBoard();
                    Obj.ProductName = r["ProductName"].ToString();
                    Obj.Amount = r["Amount"].ToString();
                    Obj.Status = r["Status"].ToString();

                    lstinvestment.Add(Obj);
                }
                model.lstinvestment = lstinvestment;
            }
            #endregion Investment


            #region Notice
            DataSet ds12 = model.ListNoticeMaster();
            if (ds12 != null && ds12.Tables.Count > 0 && ds12.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds12.Tables[0].Rows)
                {
                    DashBoard Obj = new DashBoard();
                    Obj.Title = r["Title"].ToString();
                    Obj.News = r["News"].ToString();

                    lstNotice.Add(Obj);
                }
                model.NoticeMasterlist = lstNotice;
            }
            #endregion Investment

            #region Achiver Rank


            DataSet dss = obj.GetAssociateDashboard();
            if (dss != null && dss.Tables[4].Rows.Count > 0)
            {
                model.ImageURL = dss.Tables[4].Rows[0]["ImageURL"].ToString();
                model.AchiverRank = dss.Tables[4].Rows[0]["AchiverRank"].ToString();
                ViewBag.ImageURL = dss.Tables[4].Rows[0]["ImageURL"].ToString();
                ViewBag.AchiverRank = dss.Tables[4].Rows[0]["AchiverRank"].ToString();
            }
            #endregion

            #region Total Rank AchieverList
            List<DashBoard> lst2 = new List<DashBoard>();
            DataSet dss1 = model.TotalRankAchieverList();

            if (dss1 != null && dss1.Tables.Count > 0 && dss1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in dss1.Tables[0].Rows)
                {
                    DashBoard Obj = new DashBoard();
                    Obj.FK_RankId = r["PK_RankId"].ToString();
                    Obj.AchiverRank = r["RankName"].ToString();
                    Obj.ImageURL = r["ImgUrl"].ToString();
                    Obj.Achiver = r["TotalRank"].ToString();
                    lst2.Add(Obj);
                }
                model.lstachiver = lst2;
            }
            #endregion 
            return View(model);
        }

        public ActionResult ViewProfile()
        {
            Profile objprofile = new Profile();

            List<Profile> lstprofile = new List<Profile>();
            objprofile.LoginId = Session["LoginId"].ToString();
            Profile obj = new Profile();
            DataSet ds = objprofile.GetUserProfile();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                obj.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                obj.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                obj.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                obj.JoiningDate = ds.Tables[0].Rows[0]["JoiningDate"].ToString();
                obj.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                obj.EmailId = ds.Tables[0].Rows[0]["Email"].ToString();
                obj.SponsorId = ds.Tables[0].Rows[0]["SponsorId"].ToString();
                obj.SponsorName = ds.Tables[0].Rows[0]["SponsorName"].ToString();
                obj.AccountNumber = ds.Tables[0].Rows[0]["AccountNo"].ToString();
                obj.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                obj.BankBranch = ds.Tables[0].Rows[0]["BankBranch"].ToString();
                obj.IFSC = ds.Tables[0].Rows[0]["IFSC"].ToString();
                obj.ProfilePicture = ds.Tables[0].Rows[0]["ProfilePic"].ToString();
            }
            return View(obj);
        }

        [HttpPost]
        [ActionName("ViewProfile")]
        [OnAction(ButtonName = "btnUpdate")]
        public ActionResult UpdateProfile(HttpPostedFileBase fileProfilePicture, Profile obj)
        {
            string FormName = "";
            string Controller = "";
            try
            {
                if (fileProfilePicture != null)
                {
                    obj.ProfilePicture = "/images/ProfilePicture/" + Guid.NewGuid() + Path.GetExtension(fileProfilePicture.FileName);
                    fileProfilePicture.SaveAs(Path.Combine(Server.MapPath(obj.ProfilePicture)));
                }

                //Profile objProfile = new Profile();
                obj.PK_UserID = Session["Pk_userId"].ToString();
                DataSet ds = obj.UpdateProfile();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        TempData["UpdateProfile"] = "Profile updated successfully..";
                        FormName = "ViewProfile";
                        Controller = "User";
                        //return View();
                    }
                    else
                    {
                        TempData["UpdateProfile"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        FormName = "ViewProfile";
                        Controller = "User";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["UpdateProfile"] = ex.Message;
                FormName = "ViewProfile";
                Controller = "User";
            }
            return RedirectToAction(FormName, Controller);
        }

        public ActionResult SaveMessages(string Message, string MessageBy)
        {
            DashBoard obj = new DashBoard();
            try
            {
                obj.Message = Message;
                obj.MessageBy = MessageBy;
                obj.Fk_UserId = Session["Pk_UserId"].ToString();
                obj.AddedBy = Session["Pk_UserId"].ToString();
                DataSet ds = obj.SaveMessage();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        obj.Result = "1";
                    }
                    else
                    {
                        obj.Result = "Message Not Send";
                    }
                }
                else
                {
                    obj.Result = "Message Not Send";
                }
            }
            catch (Exception ex)
            {
                obj.Result = ex.Message;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BinaryTree()
        {
            ViewBag.Fk_UserId = Session["Pk_UserId"].ToString();
            return View();
        }

        public ActionResult Registration(string Pid, string lg)
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

            obj.SponsorId = Session["LoginId"].ToString();
            obj.SponsorName = Session["FullName"].ToString();
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
                        Session["Name"] = ds.Tables[0].Rows[0]["Name"].ToString();
                        Session["PassWord"] = Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString());

                        Session["MobileNo"] = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                        //try
                        //{
                        //    string str2 = BLSMS.Registration(ds.Tables[0].Rows[0]["Name"].ToString(), ds.Tables[0].Rows[0]["LoginId"].ToString(), Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString()));
                        //    BLSMS.SendSMS(MobileNo, str2);
                        //}
                        //catch { }
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
                obj.Result = "yes";
            }
            else
            {
                obj.Result = "Invalid PinCode";
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OTP(string FirstName, string MobileNo, string SponsorId)
        {
            Home obj = new Home();
            Common objcom = new Common();
            int OTP = objcom.GenerateRandomNo();
            Session["OTP"] = OTP.ToString();
            string str2 = BLSMS.OTP(FirstName, OTP.ToString());
            if (Session["LoginId"].ToString() == "utsav")
            {
                MobileNo = "8299051766";
            }

            string str = BLSMS.SendSMS2(SMSCredential.UserName, SMSCredential.Password, SMSCredential.SenderId, MobileNo, str2);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Opportunity()
        {
            return View();
        }

        //public ActionResult Registration()
        //{
        //    Home model = new Home();
        //    model.SponsorId = Session["LoginId"].ToString();
        //    model.SponsorName = Session["FullName"].ToString();

        //    return View(model);
        //}

        public ActionResult DailyIncomeReport1(Reports model)
        {
            List<Reports> lst1 = new List<Reports>();
            model.Fk_UserId = Session["Pk_UserId"].ToString();
            DataSet ds11 = model.DailyIncomeReport();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    Reports Obj = new Reports();
                    Obj.Fk_UserId = r["Fk_ToId"].ToString();
                    Obj.DisplayName = r["FirstName"].ToString();
                    Obj.ClosingDate = r["CurrentDate"].ToString();
                    Obj.BinaryIncome = r["BinaryIncome"].ToString();
                    Obj.DirectIncome = r["Direct"].ToString();
                    Obj.LeadershipBonus = r["DirectLeaderShipBonus"].ToString();
                    lst1.Add(Obj);
                }
                model.lsttopupreport = lst1;
            }
            return View(model);
        }
        [HttpPost]
        [ActionName("DailyIncomeReport")]
        [OnAction(ButtonName = "Search")]
        public ActionResult DailyIncomeReportBy(Reports model)
        {
            List<Reports> lst1 = new List<Reports>();
            model.Fk_UserId = Session["Pk_UserId"].ToString();
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            DataSet ds11 = model.DailyIncomeReport();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    Reports Obj = new Reports();
                    Obj.Fk_UserId = r["Fk_ToId"].ToString();
                    Obj.DisplayName = r["FirstName"].ToString();
                    Obj.ClosingDate = r["CurrentDate"].ToString();
                    Obj.BinaryIncome = r["BinaryIncome"].ToString();
                    Obj.DirectIncome = r["Direct"].ToString();
                    Obj.LeadershipBonus = r["DirectLeaderShipBonus"].ToString();
                    lst1.Add(Obj);
                }
                model.lsttopupreport = lst1;
            }
            return View(model);
        }

        public ActionResult UserReward(Reports model)
        {

            model.Fk_UserId = Session["Pk_UserId"].ToString();
            model.RewardID = "1";

            List<Reports> lst = new List<Reports>();

            DataSet ds = model.RewardList();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Reports obj = new Reports();

                    obj.Status = r["Status"].ToString();
                    obj.QualifyDate = r["QualifyDate"].ToString();
                    obj.RewardImage = r["RewardImage"].ToString();
                    obj.RewardName = r["RewardName"].ToString();
                    obj.Contact = r["BackColor"].ToString();
                    obj.PK_RewardItemId = r["PK_RewardItemId"].ToString();
                    lst.Add(obj);
                }
                model.lsttopupreport = lst;
            }

            return View(model);
        }

        public ActionResult ClaimReward(string id)
        {
            Reports obj = new Reports();
            try
            {
                obj.PK_RewardItemId = id;
                obj.Status = "Claim";
                obj.Fk_UserId = Session["Pk_UserId"].ToString();
                DataSet ds = obj.ClaimReward();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["Rewardmsg"] = "Reward Claimed";
                    }
                    else
                    {
                        TempData["Rewardmsg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Rewardmsg"] = ex.Message;
            }
            return RedirectToAction("UserReward");
        }
        public ActionResult SkipReward(string id)
        {
            Reports obj = new Reports();
            try
            {
                obj.PK_RewardItemId = id;
                obj.Status = "Skip";
                obj.Fk_UserId = Session["Pk_UserId"].ToString();
                DataSet ds = obj.ClaimReward();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["Rewardmsg"] = "Reward Skipped";
                    }
                    else
                    {
                        TempData["Rewardmsg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Rewardmsg"] = ex.Message;
            }
            return RedirectToAction("UserReward");
        }

        public ActionResult AdvancePaymentReport()
        {
            Reports model = new Reports();
            try
            {
                model.LoginId = Session["LoginID"].ToString();
                model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
                model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
                DataSet ds = model.AdvancePaymentReport();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    List<Reports> lstReport = new List<Reports>();
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Reports obj = new Reports();
                        obj.LoginId = r["LoginID"].ToString();
                        obj.DisplayName = r["FirstName"].ToString();
                        obj.Amount = r["Amount"].ToString();
                        obj.PaymentDate = r["PaymentDate"].ToString();
                        obj.PaymentMode = r["PaymentMode"].ToString();
                        obj.TransactionNo = r["PayMode"].ToString();
                        obj.Description = r["Description"].ToString();
                        lstReport.Add(obj);
                    }
                    model.lstAdvancePaymentReport = lstReport;
                }
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }

        public ActionResult TopupList()
        {
            Reports model = new Reports();
            try
            {
                model.LoginId = Session["LoginID"].ToString();
                DataSet ds = model.GetTopupReport();

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    List<Reports> lstTopupReport = new List<Reports>();
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Reports obj = new Reports();
                        obj.FK_InvestmentID = Crypto.Encrypt(r["Pk_InvestmentId"].ToString());
                        obj.Name = r["Name"].ToString() + " (" + r["LoginId"].ToString() + ")";
                        obj.SiteName = r["SiteName"].ToString();
                        obj.SectorName = r["SectorName"].ToString();

                        obj.UpgradtionDate = r["UpgradtionDate"].ToString();
                        obj.ProductName = r["Package"].ToString();
                        obj.Amount = r["Amount"].ToString();
                        lstTopupReport.Add(obj);
                    }
                    model.lsttopupreport = lstTopupReport;
                }
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }
        
        [HttpPost]
        [ActionName("TopupList")]
        [OnAction(ButtonName = "topupSearch")]
        public ActionResult TopupListSearch(Reports model)
        {
            try
            {
                model.LoginId = Session["LoginID"].ToString();
                model.FromDatenew = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
                model.ToDatenew = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
                DataSet ds = model.GetTopupReport();

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    List<Reports> lstTopupReport = new List<Reports>();
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Reports obj = new Reports();
                        obj.FK_InvestmentID = Crypto.Encrypt(r["Pk_InvestmentId"].ToString());
                        obj.Name = r["Name"].ToString() + " (" + r["LoginId"].ToString() + ")";
                        obj.SiteName = r["SiteName"].ToString();
                        obj.SectorName = r["SectorName"].ToString();

                        obj.UpgradtionDate = r["UpgradtionDate"].ToString();
                        obj.ProductName = r["Package"].ToString();
                        obj.Amount = r["Amount"].ToString();
                        lstTopupReport.Add(obj);
                    }
                    model.lsttopupreport = lstTopupReport;
                }
                else
                {
                    TempData["ErrorMessage"] = ds.Tables[0].Rows[0].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View(model);
        }


        public ActionResult PrintTopup(string invid)
        {
            List<Reports> list = new List<Reports>();
            Reports model = new Reports();
            if (invid != null)
            {
                model.ToLoginID = Crypto.Decrypt(invid);
                try
                {
                    DataSet ds = model.PrintTopUp();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in ds.Tables[0].Rows)
                        {
                            Reports obj = new Reports();

                            obj.FK_InvestmentID = r["Pk_InvestmentId"].ToString();
                            //obj.EncryptKey = Crypto.Encrypt(r["Fk_SaleOrderId"].ToString());
                            //obj.ProductID = r["Fk_ProductId"].ToString();
                            obj.Quantity = r["Quantity"].ToString();
                            obj.MRP = r["Amount"].ToString();
                            obj.IGST = r["IGST"].ToString();
                            obj.CGST = r["CGST"].ToString();
                            obj.SGST = r["SGST"].ToString();
                            obj.FinalAmount = r["Amount"].ToString();
                            //obj.TaxableAmount = r["TaxableAmount"].ToString();
                            obj.ProductName = r["ProductName"].ToString();
                            obj.HSNCode = r["HSNCode"].ToString();

                            ViewBag.OrderNo = r["Pk_InvestmentId"].ToString();

                            ViewBag.TotalFinalAmount = ds.Tables[1].Rows[0]["TotalFinalAmount"].ToString();
                            ViewBag.TotalFinalAmountWords = ds.Tables[1].Rows[0]["TotalFinalAmountWords"].ToString();
                            ViewBag.PurchaseDate = ds.Tables[0].Rows[0]["UpgradtionDate"].ToString();
                            ViewBag.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                            ViewBag.Loginid = ds.Tables[0].Rows[0]["LoginId"].ToString();
                            ViewBag.AssociateAddress = ds.Tables[0].Rows[0]["Address"].ToString();
                            ViewBag.ValueBeforeTax = ds.Tables[1].Rows[0]["Taxable"].ToString();
                            ViewBag.TaxAdded = ds.Tables[1].Rows[0]["TaxAmount"].ToString();

                            ViewBag.CompanyName = SoftwareDetails.CompanyName;
                            ViewBag.CompanyAddress = SoftwareDetails.CompanyAddress;
                            ViewBag.Pin1 = SoftwareDetails.Pin1;
                            ViewBag.State1 = SoftwareDetails.State1;
                            ViewBag.City1 = SoftwareDetails.City1;
                            ViewBag.ContactNo = SoftwareDetails.ContactNo;
                            ViewBag.LandLine = SoftwareDetails.LandLine;
                            ViewBag.Website = SoftwareDetails.Website;
                            ViewBag.EmailID = SoftwareDetails.EmailID;
                            list.Add(obj);

                        }
                        model.lsttopupreport = list;
                    }

                }
                catch (Exception ex)
                {
                }
            }
            return View(model);
        }

        public ActionResult ProductTopupList()
        {
            Reports model = new Reports();
            try
            {
                model.LoginId = Session["LoginID"].ToString();
                DataSet ds = model.GetTopupreportProduct();

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    List<Reports> lstTopupReport = new List<Reports>();
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Reports obj = new Reports();
                        obj.FK_InvestmentID = Crypto.Encrypt(r["Pk_ProductInvestmentId"].ToString());
                        obj.Name = r["Name"].ToString() + " (" + r["LoginId"].ToString() + ")";
                        obj.UpgradtionDate = r["UpgradtionDate"].ToString();
                        obj.ProductName = r["Package"].ToString();
                        obj.Amount = r["Amount"].ToString();
                        lstTopupReport.Add(obj);
                    }
                    model.lsttopupreport = lstTopupReport;
                }
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }

        #region ProductReward

        public ActionResult UserProductReward(Reports model)
        {

            model.Fk_UserId = Session["Pk_UserId"].ToString();
            model.RewardID = "1";

            List<Reports> lst = new List<Reports>();

            DataSet ds = model.UserProductReward();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Reports obj = new Reports();

                    obj.Status = r["Status"].ToString();
                    obj.QualifyDate = r["QualifyDate"].ToString();
                    obj.RewardImage = r["RewardImage"].ToString();
                    obj.RewardName = r["RewardName"].ToString();
                    obj.Contact = r["BackColor"].ToString();
                    obj.PK_RewardItemId = r["PK_RewardItemId"].ToString();
                    obj.Remarks = r["Pair"].ToString();
                    lst.Add(obj);
                }
                model.lsttopupreport = lst;
            }

            return View(model);
        }

        public ActionResult ClaimProductReward(string id)
        {
            Reports obj = new Reports();
            try
            {
                obj.PK_RewardItemId = id;
                obj.Status = "Claim";
                obj.Fk_UserId = Session["Pk_UserId"].ToString();
                DataSet ds = obj.ClaimProductReward();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["Rewardmsg"] = "Reward Claimed";
                    }
                    else
                    {
                        TempData["Rewardmsg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Rewardmsg"] = ex.Message;
            }
            return RedirectToAction("UserProductReward");
        }
        public ActionResult SkipProductReward(string id)
        {
            Reports obj = new Reports();
            try
            {
                obj.PK_RewardItemId = id;
                obj.Status = "Skip";
                obj.Fk_UserId = Session["Pk_UserId"].ToString();
                DataSet ds = obj.ClaimProductReward();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        TempData["Rewardmsg"] = "Reward Skipped";
                    }
                    else
                    {
                        TempData["Rewardmsg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Rewardmsg"] = ex.Message;
            }
            return RedirectToAction("UserProductReward");
        }
        #endregion

        //public ActionResult GetUserList()
        //{
        //    Reports obj = new Reports();
        //    List<Reports> lst = new List<Reports>();
        //    obj.LoginId = Session["LoginId"].ToString();
        //    DataSet ds = obj.GettingUserProfile();
        //    if (ds != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            Reports objList = new Reports();
        //            objList.UserName = dr["Fullname"].ToString();
        //            objList.LoginIDD = dr["LoginId"].ToString();
        //            lst.Add(objList);
        //        }
        //    }
        //    return Json(lst, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult GetUserList()
        {
            Profile obj = new Profile();
            List<Profile> lst = new List<Profile>();
            obj.LoginId = Session["LoginId"].ToString();
            DataSet ds = obj.GettingUserProfile();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Profile objList = new Profile();
                    objList.UserName = dr["Fullname"].ToString();
                    objList.LoginIDD = dr["LoginId"].ToString();
                    lst.Add(objList);
                }
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }


        public ActionResult TopupListNew()
        {
            Reports model = new Reports();
            try
            {
                model.LoginId = Session["LoginID"].ToString();
                DataSet ds = model.GetTopupReportNew();

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    List<Reports> lstTopupReport = new List<Reports>();
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Reports obj = new Reports();
                        obj.FK_InvestmentID = Crypto.Encrypt(r["Pk_InvestmentId"].ToString());
                        obj.Name = r["Name"].ToString() + " (" + r["LoginId"].ToString() + ")";
                        obj.SiteName = r["SiteName"].ToString();
                        obj.SectorName = r["SectorName"].ToString();

                        obj.UpgradtionDate = r["UpgradtionDate"].ToString();
                        obj.ProductName = r["Package"].ToString();
                        obj.Amount = r["Amount"].ToString();
                        lstTopupReport.Add(obj);
                    }
                    model.lsttopupreport = lstTopupReport;
                }
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }

        [HttpPost]
        [ActionName("TopupListNew")]
        [OnAction(ButtonName = "lstnewSearch")]
        public ActionResult TopupListNewSearch(Reports model)
        {
            try
            {
                model.LoginId = Session["LoginID"].ToString();
                model.FromDatenew = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
                model.ToDatenew = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
                DataSet ds = model.GetTopupReportNew();

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    List<Reports> lstTopupReport = new List<Reports>();
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Reports obj = new Reports();
                        obj.FK_InvestmentID = Crypto.Encrypt(r["Pk_InvestmentId"].ToString());
                        obj.Name = r["Name"].ToString() + " (" + r["LoginId"].ToString() + ")";
                        obj.SiteName = r["SiteName"].ToString();
                        obj.SectorName = r["SectorName"].ToString();

                        obj.UpgradtionDate = r["UpgradtionDate"].ToString();
                        obj.ProductName = r["Package"].ToString();
                        obj.Amount = r["Amount"].ToString();
                        lstTopupReport.Add(obj);
                    }
                    model.lsttopupreport = lstTopupReport;
                }
                else
                {
                    TempData["ErrorMessage"] = ds.Tables[0].Rows[0].ToString();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View(model);
        }


        public ActionResult GetSponsorName(string ReferBy)
        {
            Reports obj = new Reports();
            obj.ReferBy = ReferBy;
            DataSet ds = obj.GetDownMemberDetails();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                obj.DisplayName = ds.Tables[0].Rows[0]["FullName"].ToString();
                obj.Result = "Yes";
            }
            else { obj.Result = "Invalid SponsorId"; }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DownlineRegistration(string Pid, string lg)
        {
            Reports obj = new Reports();
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
            return View(obj);
        }



     
        public ActionResult DownlineRegistrationAction(string SponsorId, string FirstName, string LastName, string Email, string MobileNo, string PanCard, string AdharNo, string Address, string Gender, string PinCode, string Leg)
        {
            Reports obj = new Reports();
            try
            {
                obj.SponsorId = SponsorId;
                obj.FirstName = FirstName;
                obj.LastName = LastName;
                obj.Email = Email;
                obj.MobileNo = MobileNo;
                obj.PanCard = PanCard;
                obj.AdharNo = AdharNo;
                obj.Address = Address;
                obj.RegistrationBy = "Web";
                obj.Gender = Gender;
                obj.PinCode = PinCode;
                obj.Leg = Leg;
                obj.AddedBy = Session["Pk_userId"].ToString();
                string password = Common.GenerateRandom();
                obj.Password = Crypto.Encrypt(password);
                DataSet ds = obj.SaveDownlineRegistration();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        Session["LoginId"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                        Session["DisplayName"] = ds.Tables[0].Rows[0]["Name"].ToString();
                        Session["PassWord"] = Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString());
                        Session["Transpassword"] = ds.Tables[0].Rows[0]["Password"].ToString();
                        Session["MobileNo"] = ds.Tables[0].Rows[0]["MobileNo"].ToString();

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

        public ActionResult GetAdharDetails(string AdharNumber)
        {
            try
            {
                Reports model = new Reports();
                model.AdharNo = AdharNumber;
                #region GetAdharDetails
                DataSet dsadhardetails = model.GetAdharDetail();
                if (dsadhardetails != null && dsadhardetails.Tables[0].Rows.Count > 0)
                {
                    if (dsadhardetails.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        model.Result = "yes";
                    }
                    else if (dsadhardetails.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        model.Result = "no";
                    }
                }
                else
                {
                    model.Result = "no";

                }
                #endregion
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult GetUserListForAutoSearch()
        {
            Profile obj = new Profile();
            List<Profile> lst = new List<Profile>();
            obj.LoginId = Session["LoginId"].ToString();
            DataSet ds = obj.GetUserListForAutoSearch();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Profile objList = new Profile();
                    objList.UserName = dr["Fullname"].ToString();
                    objList.LoginIDD = dr["LoginId"].ToString();
                    lst.Add(objList);
                }
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ConfirmRegistrationForDown()
        {
            return View();
        }


        public ActionResult DownlineRankAchieverReports()
        {
            Reports model = new Reports();
            try
            {
                model.Fk_UserId = Session["Pk_userId"].ToString();
                DataSet ds = model.GetDownlineRankAchiever();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    List<Reports> lstdownlineAchieverreport = new List<Reports>();
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Reports obj = new Reports();
                        obj.FK_RankId = r["PK_RankId"].ToString();
                        obj.RankName = r["RankName"].ToString();
                        obj.RewardImage = r["ImgUrl"].ToString();
                        obj.TotalAchieverLeft = r["TotalAchieverLeft"].ToString();
                        obj.TotalAchieverRight = r["TotalAchieverRight"].ToString();
                        lstdownlineAchieverreport.Add(obj);
                    }
                    model.lstdownlineAchieverreport = lstdownlineAchieverreport;
                }
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }

        public ActionResult DownlineRankAchieverAssociateReports(string RankId,string Leg)
        {
            Reports model = new Reports();
            model.FK_RankId = RankId;
            model.Leg = Leg;
            if (model.FK_RankId != null) { 
                model.Fk_UserId = Session["Pk_userId"].ToString();
                DataSet ds = model.DownlineRankAchieverAssociateReports();
                if (ds != null && ds.Tables[0].Rows.Count > 0){
                List<Reports> lstdownAchieverAssoreport = new List<Reports>();
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Reports obj = new Reports();
                    obj.Fk_UserId = r["Pk_UserId"].ToString();
                    obj.LoginId = r["LoginId"].ToString();
                    obj.Name = r["Name"].ToString();
                    lstdownAchieverAssoreport.Add(obj);
                }
                model.lstdownAchieverAssoreport = lstdownAchieverAssoreport;
             }
        }

            return View(model);
        }
    }
}
