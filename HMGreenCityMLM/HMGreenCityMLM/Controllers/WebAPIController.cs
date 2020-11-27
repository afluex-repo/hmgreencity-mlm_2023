using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMGreenCityMLM.Models;
using System.Web.Mvc;
using System.Data;
using HMGreenCityMLM.Filter;
using BusinessLayer;
using System.IO;

namespace HMGreenCityMLM.Controllers
{
    public class WebAPIController : Controller
    {
        #region Login
        public ActionResult Login(LoginAPI model)
        {


            LoginAPI obj = new LoginAPI();
            if (model.LoginId == "" || model.LoginId == null)
            {
                obj.Status = "1";
                obj.Message = "Please Enter Login Id";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            if (model.Password == "" || model.Password == null)
            {
                obj.Status = "1";
                obj.Message = "Please Enter Password";
            }

            try
            {
                //string Password = model.Password;
                //model.Password = Crypto.Encrypt(Password);
                DataSet dsResult = model.Login();
                {
                    if (dsResult.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        if ((dsResult.Tables[0].Rows[0]["UserType"].ToString() == "Associate"))
                        {
                            if (model.Password == Crypto.Decrypt(dsResult.Tables[0].Rows[0]["Password"].ToString()))
                            {

                                obj.LoginId = dsResult.Tables[0].Rows[0]["LoginId"].ToString();
                                obj.UserId = dsResult.Tables[0].Rows[0]["Pk_userId"].ToString();
                                obj.UserType = dsResult.Tables[0].Rows[0]["UserType"].ToString();
                                obj.FullName = dsResult.Tables[0].Rows[0]["FullName"].ToString();
                                obj.Password = dsResult.Tables[0].Rows[0]["Password"].ToString();
                                //obj.TransPassword = dsResult.Tables[0].Rows[0]["TransPassword"].ToString();
                                obj.Profile = dsResult.Tables[0].Rows[0]["Profile"].ToString();
                                obj.Status = dsResult.Tables[0].Rows[0]["Status"].ToString();
                                obj.Status = "0";
                                obj.Message = "Successfully Logged in";

                                return Json(obj, JsonRequestBehavior.AllowGet);

                            }
                            obj.Status = "1";
                            obj.Message = "Incorrect LoginId Or Password";
                            return Json(obj, JsonRequestBehavior.AllowGet);

                        }
                        else if (dsResult.Tables[0].Rows[0]["UserType"].ToString() == "Admin")
                        {
                            obj.Status = "0";
                            obj.Message = "Successfully Logged in";
                            obj.LoginId = dsResult.Tables[0].Rows[0]["LoginId"].ToString();
                            obj.Pk_adminId = dsResult.Tables[0].Rows[0]["Pk_adminId"].ToString();
                            obj.UserType = dsResult.Tables[0].Rows[0]["UsertypeName"].ToString();
                            obj.FullName = dsResult.Tables[0].Rows[0]["Name"].ToString();

                            if (dsResult.Tables[0].Rows[0]["isFranchiseAdmin"].ToString() == "True")
                            {
                                obj.FranchiseAdminID = dsResult.Tables[0].Rows[0]["Pk_adminId"].ToString();
                            }

                        }
                        else
                        {
                            obj.Status = "1";
                            obj.Message = "Incorrect LoginId Or Password";
                            return Json(obj, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {

                        obj.Status = "1";
                        obj.Message = "Invalid LoginId or Password.";
                        return Json(obj, JsonRequestBehavior.AllowGet);
                    }

                }


                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                obj.Status = "1";
                obj.Message = "Invalid LoginId or Password.";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region ChangePAssword

        public ActionResult ChangePassword(ChangePasswordAPI model)
        {
            ChangePasswordAPI obj = new ChangePasswordAPI();
            if (model.PasswordType == "0" || model.PasswordType == null)
            {
                obj.Status = "1";
                obj.Message = "Please Select Password Type";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            if (model.NewPassword == "" || model.NewPassword == null)
            {
                obj.Status = "1";
                obj.Message = "Please Enter New Password";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            if (model.OldPassword == "" || model.OldPassword == null)
            {
                obj.Status = "1";
                obj.Message = "Please Enter Old Password";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            if (model.UpdatedBy == "" || model.UpdatedBy == null)
            {
                obj.Status = "1";
                obj.Message = "Please Enter Pk_userId";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }

            try
            {
                //  model.UpdatedBy = Session["Pk_userId"].ToString();
                string OldPassword = model.OldPassword;
                model.OldPassword = Crypto.Encrypt(OldPassword);
                string NewPassword = model.NewPassword;
                model.NewPassword = Crypto.Encrypt(model.NewPassword);
                DataSet ds = model.UpdatePassword();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        obj.Status = "0";
                        obj.Message = "Password updated successfully..";
                        return Json(obj, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        obj.Status = "1";
                        obj.Message = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return Json(obj, JsonRequestBehavior.AllowGet);
                    }
                }

                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                obj.Status = "1";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region Registration

        public ActionResult Registration(RegistrationAPI model)
        {
            RegistrationAPI obj = new RegistrationAPI();
            if (model.SponsorId == "" || model.SponsorId == null)
            {
                obj.Status = "1";
                obj.Message = "Please Enter Sponsor Id";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            if (model.FirstName == "" || model.FirstName == null)
            {
                obj.Status = "1";
                obj.Message = "Please Enter First Name";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            if (model.MobileNo == "" || model.MobileNo == null)
            {
                obj.Status = "1";
                obj.Message = "Please Enter Mobile No";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            if (model.Leg == "" || model.Leg == null)
            {
                obj.Status = "1";
                obj.Message = "Please Select Leg";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            model.SponsorId = model.SponsorId;
            try
            {
                string password = Common.GenerateRandom();
                model.Password = Crypto.Encrypt(password);
                model.RegistrationBy = "Mobile";
                DataSet ds = model.Registration();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        obj.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                        obj.FullName = ds.Tables[0].Rows[0]["Name"].ToString();
                        obj.Password = Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString());
                        obj.TransPassword = Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString());
                        obj.MobileNo = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                        obj.Leg = model.Leg;
                        obj.RegistrationBy = model.RegistrationBy;
                        obj.SponsorId = model.SponsorId;
                        obj.Email = model.Email;
                        obj.LastName = model.LastName;
                        obj.Address = model.Address;
                        obj.PinCode = model.PinCode;
                        obj.PanCard = model.PanCard;
                        obj.Gender = model.Gender;

                        try
                        {
                            string str2 = BLSMS.Registration(ds.Tables[0].Rows[0]["Name"].ToString(), ds.Tables[0].Rows[0]["LoginId"].ToString(), Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString()));
                            BLSMS.SendSMSNew(model.MobileNo, str2);
                        }
                        catch { }
                        obj.Status = "0";
                        obj.Message = "Registered Successfully";
                        return Json(obj, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        obj.Status = "1";
                        obj.Message = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return Json(obj, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                obj.Status = "1";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }


        }

        #endregion

        #region TopupList

        public ActionResult TopupList(TopUpAPI model)
        {
            TopUpAPI obj = new TopUpAPI();
            if (model.LoginId == "" || model.LoginId == null)
            {
                obj.Status = "1";
                obj.Message = "Please enter LoginId";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }

            try
            {
                DataSet ds = model.GetTopupReport();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    List<TopUp> lstTopupReport = new List<TopUp>();
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        TopUp obj1 = new TopUp();
                        obj1.FK_InvestmentID = Crypto.Encrypt(r["Pk_InvestmentId"].ToString());
                        obj1.Name = r["Name"].ToString() + " (" + r["LoginId"].ToString() + ")";
                        obj1.SiteName = r["SiteName"].ToString();
                        obj1.SectorName = r["SectorName"].ToString();
                        obj1.UpgradtionDate = r["UpgradtionDate"].ToString();
                        obj1.ProductName = r["Package"].ToString();
                        obj1.Amount = r["Amount"].ToString();

                        lstTopupReport.Add(obj1);
                    }
                    obj.lsttopupreport = lstTopupReport;
                    obj.Message = "TopupList";
                    obj.Status = "0";

                }
                else
                {
                    obj.Status = "1";
                    obj.Message = "No Data Found";
                    return Json(obj, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                obj.Status = "1";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }


            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region PrintTopup

        public ActionResult PrintTopup(PrintTopupAPI model)
        {
            PrintTopupAPI obj = new PrintTopupAPI();
            if (model.invid == "" || model.invid == null)
            {
                obj.Status = "1";
                obj.Message = "Please enter id";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }

            List<PrintTopup> list = new List<PrintTopup>();

            if (model.invid != null)
            {
                model.LoginId = Crypto.Decrypt(model.invid);
                try
                {
                    DataSet ds = model.PrintTopUp();
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in ds.Tables[0].Rows)
                        {
                            PrintTopup obj1 = new PrintTopup();

                            obj1.FK_InvestmentID = r["Pk_InvestmentId"].ToString();
                            //obj.EncryptKey = Crypto.Encrypt(r["Fk_SaleOrderId"].ToString());
                            //obj.ProductID = r["Fk_ProductId"].ToString();
                            obj1.Quantity = r["Quantity"].ToString();
                            obj1.MRP = r["Amount"].ToString();
                            obj1.IGST = r["IGST"].ToString();
                            obj1.CGST = r["CGST"].ToString();
                            obj1.SGST = r["SGST"].ToString();
                            obj1.FinalAmount = r["Amount"].ToString();
                            //obj1bj.TaxableAmount = r["TaxableAmount"].ToString();
                            obj1.ProductName = r["ProductName"].ToString();
                            obj1.HSNCode = r["HSNCode"].ToString();

                            obj1.OrderNo = r["Pk_InvestmentId"].ToString();

                            obj1.TotalFinalAmount = ds.Tables[1].Rows[0]["TotalFinalAmount"].ToString();
                            obj1.TotalFinalAmountWords = ds.Tables[1].Rows[0]["TotalFinalAmountWords"].ToString();
                            obj1.PurchaseDate = ds.Tables[0].Rows[0]["UpgradtionDate"].ToString();
                            obj1.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                            obj1.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                            obj1.AssociateAddress = ds.Tables[0].Rows[0]["Address"].ToString();
                            obj1.ValueBeforeTax = ds.Tables[1].Rows[0]["Taxable"].ToString();
                            obj1.TaxAdded = ds.Tables[1].Rows[0]["TaxAmount"].ToString();

                            obj1.CompanyName = SoftwareDetails.CompanyName;
                            obj1.CompanyAddress = SoftwareDetails.CompanyAddress;
                            obj1.PinCode = SoftwareDetails.Pin1;
                            obj1.State1 = SoftwareDetails.State1;
                            obj1.City1 = SoftwareDetails.City1;
                            obj1.ContactNo = SoftwareDetails.ContactNo;
                            obj1.LandLine = SoftwareDetails.LandLine;
                            obj1.Website = SoftwareDetails.Website;
                            obj1.Email = SoftwareDetails.EmailID;
                            list.Add(obj1);

                        }
                        obj.lsttopupreport = list;
                        obj.Status = "0";
                        obj.invid = model.invid;

                        obj.LoginId = model.LoginId;
                        obj.Message = "Data Fetch Successfully";
                        return Json(obj, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        obj.Status = "1"; obj.invid = model.invid;
                        obj.LoginId = model.LoginId;
                        obj.Message = "No Data Found";
                        return Json(obj, JsonRequestBehavior.AllowGet);

                    }

                }
                catch (Exception ex)
                {
                    obj.Status = "1";
                    obj.Message = "No Data Found";
                    return Json(obj, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        #endregion


        #region PayoutReport


        public ActionResult PayoutReport(PayoutReportAPI payoutDetail)
        {
            List<PayoutReport> lst1 = new List<PayoutReport>();

            payoutDetail.LoginId = payoutDetail.LoginId;
            DataSet ds11 = payoutDetail.GetPayoutReport();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                if (ds11.Tables[0].Rows[0]["Msg"].ToString() == "0")
                {
                    payoutDetail.Status = "1";
                    payoutDetail.Message = ds11.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    return Json(payoutDetail, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    foreach (DataRow r in ds11.Tables[0].Rows)
                    {
                        PayoutReport Obj = new PayoutReport();
                        Obj.EncryptLoginID = Crypto.Encrypt(r["LoginId"].ToString());
                        Obj.EncryptPayoutNo = Crypto.Encrypt(r["PayoutNo"].ToString());

                        Obj.LoginId = r["LoginId"].ToString();
                        Obj.DisplayName = r["FirstName"].ToString();
                        Obj.PayoutNo = r["PayoutNo"].ToString();
                        Obj.ClosingDate = r["ClosingDate"].ToString();
                        Obj.BinaryIncome = r["BinaryIncome"].ToString();
                        Obj.DirectIncome = r["DirectIncome"].ToString();
                        Obj.GrossAmount = r["GrossAmount"].ToString();
                        Obj.TDSAmount = r["TDSAmount"].ToString();
                        Obj.ProcessingFee = r["ProcessingFee"].ToString();
                        Obj.NetAmount = r["NetAmount"].ToString();
                        Obj.LeadershipBonus = r["DirectLeaderShipBonus"].ToString();
                        Obj.ProductWallet = r["ProductWallet"].ToString();
                        lst1.Add(Obj);
                    }
                    payoutDetail.lstPayoutDetail = lst1;
                    payoutDetail.Status = "0";
                    payoutDetail.Message = "Data Fetched";
                    return Json(payoutDetail, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(payoutDetail, JsonRequestBehavior.AllowGet);

        }


        #endregion

        #region PayoutReportSearch

        public ActionResult PayoutReportBy(PayoutReportSearchAPI payoutDetail)
        {
            List<PayoutReportSearch> lst1 = new List<PayoutReportSearch>();
            payoutDetail.FromDate = string.IsNullOrEmpty(payoutDetail.FromDate) ? null : Common.ConvertToSystemDate(payoutDetail.FromDate, "dd/MM/yyyy");
            payoutDetail.ToDate = string.IsNullOrEmpty(payoutDetail.ToDate) ? null : Common.ConvertToSystemDate(payoutDetail.ToDate, "dd/MM/yyyy");
            payoutDetail.LoginId = payoutDetail.LoginId;
            DataSet ds11 = payoutDetail.GetPayoutReport();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                if (ds11.Tables[0].Rows[0]["Msg"].ToString() == "0")
                {
                    payoutDetail.Status = "1";
                    payoutDetail.Message = ds11.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    return Json(payoutDetail, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    foreach (DataRow r in ds11.Tables[0].Rows)
                    {
                        PayoutReportSearch Obj = new PayoutReportSearch();
                        Obj.LoginId = r["LoginId"].ToString();
                        Obj.DisplayName = r["FirstName"].ToString();
                        Obj.PayoutNo = r["PayoutNo"].ToString();
                        Obj.ClosingDate = r["ClosingDate"].ToString();
                        Obj.BinaryIncome = r["BinaryIncome"].ToString();
                        Obj.DirectIncome = r["DirectIncome"].ToString();
                        Obj.GrossAmount = r["GrossAmount"].ToString();
                        Obj.TDSAmount = r["TDSAmount"].ToString();
                        Obj.ProcessingFee = r["ProcessingFee"].ToString();
                        Obj.NetAmount = r["NetAmount"].ToString();
                        Obj.LeadershipBonus = r["DirectLeaderShipBonus"].ToString();
                        Obj.ProductWallet = r["ProductWallet"].ToString();
                        lst1.Add(Obj);
                    }
                    payoutDetail.lstPayoutDetail = lst1;
                    payoutDetail.Status = "0";
                    payoutDetail.Message = "Data Fetched";
                    return Json(payoutDetail, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                payoutDetail.Status = "1";
                payoutDetail.Message = "No Data Found";
                return Json(payoutDetail, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region AssociateDashboard

        public ActionResult AssociateDashBoardTotals(AssociateDashBoardAPI assocdash)
        {
            AssociateDashBoardAPI obj = new AssociateDashBoardAPI();

            try
            {

                DataSet ds = assocdash.GetAssociateDashboard();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Msg"].ToString() != "0")
                {

                    obj.TotalDownline = ds.Tables[0].Rows[0]["TotalDownline"].ToString();
                    obj.TotalDirects = ds.Tables[0].Rows[0]["TotalDirect"].ToString();
                    //ViewBag.ProductWalletBalance = ds.Tables[0].Rows[0]["ProductWalletBalance"].ToString();
                    obj.PayoutWalletBalance = ds.Tables[0].Rows[0]["PayoutWalletBalance"].ToString();
                    obj.TotalPayout = ds.Tables[0].Rows[0]["TotalPayout"].ToString();
                    obj.TotalDeduction = ds.Tables[0].Rows[0]["TotalDeduction"].ToString();
                    obj.TotalAdvance = ds.Tables[0].Rows[0]["TotalAdvance"].ToString();
                    obj.TotalActive = ds.Tables[0].Rows[0]["TotalActive"].ToString();
                    obj.TotalInActive = ds.Tables[0].Rows[0]["TotalInActive"].ToString();
                    obj.UnpaidIncome = ds.Tables[0].Rows[0]["UpdaidIncome"].ToString();
                    obj.SelfBusiness = ds.Tables[0].Rows[0]["TotalTopUp"].ToString();

                    //ViewBag.ProductPaidBusinessLeft = ds.Tables[3].Rows[0]["PaidBusinessLeft"].ToString();
                    //ViewBag.ProductPaidBusinessRight = ds.Tables[3].Rows[0]["PaidBusinessRight"].ToString();
                    //ViewBag.ProductTotalBusinessLeft = ds.Tables[3].Rows[0]["TotalBusinessLeft"].ToString();
                    //ViewBag.ProductTotalBusinessRight = ds.Tables[3].Rows[0]["TotalBusinessRight"].ToString();
                    //ViewBag.ProductCarryLeft = ds.Tables[3].Rows[0]["CarryLeft"].ToString();
                    //ViewBag.ProductCarryRight = ds.Tables[3].Rows[0]["CarryRight"].ToString();

                    obj.Status = "0";
                    obj.Message = "Data Fetched";
                    return Json(obj, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    obj.Status = "1";
                    obj.Message = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    return Json(obj, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception ex)
            {
                obj.Status = "1";
                obj.Message = ex.Message;
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region AssociateDashboardInvestment


        public ActionResult AssociateDashboardInvestment(AssoeDashInvstAPI data)
        {

            try
            {
                List<AssoeDashInvst> lstinvestment = new List<AssoeDashInvst>();
                DataSet ds = data.GetAssociateDashboard();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        data.Status = "1";
                        data.Message = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        foreach (DataRow r in ds.Tables[1].Rows)
                        {
                            AssoeDashInvst Obj = new AssoeDashInvst();
                            Obj.ProductName = r["ProductName"].ToString();
                            Obj.Amount = r["Amount"].ToString();
                            Obj.Status = r["Status"].ToString();

                            lstinvestment.Add(Obj);
                        }
                        data.lstinvestment = lstinvestment;
                        data.Status = "0";
                        data.Message = "Data Fetched";
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }

                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                data.Status = "1";
                data.Message = ex.Message;
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region AssoDashTotalBusiness


        public ActionResult AssoDashTotalBusiness(TotalBusinessAPI data)
        {
            try
            {
                TotalBusiness obj = new TotalBusiness();
                DataSet ds = data.GetAssociateDashboard();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        data.Status = "1";
                        data.Message = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        obj.PaidBusinessLeft = ds.Tables[2].Rows[0]["PaidBusinessLeft"].ToString();
                        obj.PaidBusinessRight = ds.Tables[2].Rows[0]["PaidBusinessRight"].ToString();
                        obj.TotalBusinessLeft = ds.Tables[2].Rows[0]["TotalBusinessLeft"].ToString();
                        obj.TotalBusinessRight = ds.Tables[2].Rows[0]["TotalBusinessRight"].ToString();
                        obj.CarryLeft = ds.Tables[2].Rows[0]["CarryLeft"].ToString();
                        obj.CarryRight = ds.Tables[2].Rows[0]["CarryRight"].ToString();
                        obj.Status = "0";
                        obj.Message = "Data Fetched";
                        return Json(obj, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region ViewProfile

        public ActionResult ViewProfile(ViewProfileAPI data)
        {

            ViewProfile obj = new ViewProfile();
            try
            {

                DataSet ds = data.GetUserProfile();
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
                    obj.Pk_UserId = ds.Tables[0].Rows[0]["Pk_UserId"].ToString();

                    obj.Status = "0";
                    obj.Message = "Data Fetched";

                    return Json(obj, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    data.Status = "1";
                    data.Message = "No Data Fetch for this id";
                    return Json(data, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                data.Status = "1";
                return Json(data, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion

        #region UpdateProfile

        public ActionResult UpdateProfile(HttpPostedFileBase fileProfilePicture, UpdateProfileAPI obj)
        {
            string FormName = "";
            string Controller = "";
            UpdateProfile data = new UpdateProfile();
            try
            {
                //Profile objProfile = new Profile();
                DataSet ds = obj.UpdateProfile();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        data.Message = "Profile updated successfully..";
                        data.Status = "0";
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        data.Message = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        data.Status = "1";
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                data.Status = "1";

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateProfileImage(UpdateProAPI obj)
        {
            UpdateProfile data = new UpdateProfile();
            try
            {
                //Profile objProfile = new Profile();
                DataSet ds = obj.UpdateProfile();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        data.Message = "Image updated successfully..";
                        data.Status = "0";
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        data.Message = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        data.Status = "1";
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                data.Status = "1";

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region PayoutLedger

        public ActionResult PayoutLedger(PayoutLedgerAPI PayoutLedger)
        {
            PayoutLedgerA od = new PayoutLedgerA();
            PayoutLedger obj = new PayoutLedger();
            //   objewallet.Fk_UserId = Session["Pk_UserId"].ToString();
            PayoutLedger.FromDate = string.IsNullOrEmpty(PayoutLedger.FromDate) ? null : Common.ConvertToSystemDate(PayoutLedger.FromDate, "dd/MM/yyyy");
            PayoutLedger.ToDate = string.IsNullOrEmpty(PayoutLedger.ToDate) ? null : Common.ConvertToSystemDate(PayoutLedger.ToDate, "dd/MM/yyyy");
            List<PayoutLedger> lst = new List<PayoutLedger>();
            DataSet ds = PayoutLedger.PayoutLedger();
            if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    PayoutLedger Objload = new PayoutLedger();
                    Objload.Narration = dr["Narration"].ToString();
                    Objload.DrAmount = dr["DrAMount"].ToString();
                    Objload.CrAmount = dr["CrAmount"].ToString();
                    Objload.AddedOn = dr["TransactionDate"].ToString();
                    Objload.PayoutBalance = dr["Balance"].ToString();

                    lst.Add(Objload);
                }
                PayoutLedger.Status = "0";
                PayoutLedger.Message = "Data Fetched";
                PayoutLedger.lstpayoutledger = lst;
                return Json(PayoutLedger, JsonRequestBehavior.AllowGet);
            }
            else
            {
                od.Status = "1";
                od.Message = "No Data for this id";
                return Json(od, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion

        #region SponsporName
        public ActionResult GetSponsorName(SponsorNameAPI sponsorname)
        {
            SponsorNameA obj = new SponsorNameA();
            DataSet ds = sponsorname.GetMemberDetails();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                obj.SponsorName = ds.Tables[0].Rows[0]["FullName"].ToString();

                obj.Status = "0";
                obj.Message = "Sponsor Name Fetched";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            else
            {
                sponsorname.Status = "1";
                sponsorname.Message = "Invalid SponsorId"; return Json(sponsorname, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Tree
        public ActionResult Tree(TreeAPI model)
        {

            UpdateProfile sta = new UpdateProfile();
            TreeAPI obj = new TreeAPI();
            if (model.LoginId == "" || model.LoginId == null)
            {
                model.Status = "1";
                model.Message = "Please enter LoginId";
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            if (model.Fk_headId == "" || model.Fk_headId == null)
            {
                model.Status = "1";
                model.Message = "Please enter headId";
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            try
            {
                DataSet ds = model.GetTree();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    if (ds.Tables[0].Rows[0]["msg"].ToString() == "0")
                    {

                        List<Tree> GetGenelogy = new List<Tree>();
                        foreach (DataRow r in ds.Tables[0].Rows)
                        {
                            Tree obj1 = new Tree();
                            obj1.Fk_UserId = r["Fk_UserId"].ToString();
                            obj1.Fk_ParentId = r["Fk_ParentId"].ToString();
                            obj1.Fk_SponsorId = r["Fk_SponsorId"].ToString();
                            obj1.SponsorId = r["SponsorId"].ToString();
                            obj1.LoginId = r["LoginId"].ToString();
                            obj1.TeamPermanent = r["TeamPermanent"].ToString();
                            obj1.MemberName = r["MemberName"].ToString();
                            obj1.MemberLevel = r["MemberLevel"].ToString();
                            obj1.Leg = r["Leg"].ToString();
                            obj1.Id = r["Id"].ToString();

                            obj1.ActivationDate = r["ActivationDate"].ToString();
                            obj1.ActiveLeft = r["ActiveLeft"].ToString();
                            obj1.ActiveRight = r["ActiveRight"].ToString();
                            obj1.InactiveLeft = r["InactiveLeft"].ToString();
                            obj1.InactiveRight = r["InactiveRight"].ToString();
                            obj1.BusinessLeft = r["BusinessLeft"].ToString();
                            obj1.BusinessRight = r["BusinessRight"].ToString();
                            obj1.ImageURL = r["ImageURL"].ToString();
                            GetGenelogy.Add(obj1);
                        }
                        obj.GetGenelogy = GetGenelogy;
                        obj.Message = "Tree";
                        obj.Status = "0";
                        obj.LoginId = model.LoginId;
                        obj.Fk_headId = model.Fk_headId;

                    }
                    else
                    {
                        sta.Status = "1";
                        sta.Message = "No Data Found";
                        return Json(sta, JsonRequestBehavior.AllowGet);
                    }

                }
                else
                {
                    sta.Status = "1";
                    sta.Message = "No Data Found";
                    return Json(sta, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                sta.Status = "1";
                sta.Message = ex.Message;
                return Json(sta, JsonRequestBehavior.AllowGet);
            }


            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Unpaid Income
        public ActionResult UnPaidIncomes(ReportsAPI objreports)
        {
            UpdateProfile sta = new UpdateProfile();
            if (objreports.LoginId == "" || objreports.LoginId == null)
            {
                sta.Status = "1";
                sta.Message = "Please enter LoginId";
                return Json(sta, JsonRequestBehavior.AllowGet);
            }

            try
            {
                objreports.LoginId = objreports.LoginId;
                DataSet ds = objreports.GetUnPaidIncomes();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    List<Report> lst = new List<Report>();
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Report obj = new Report();
                        obj.FromLoginId = r["FromLoginId"].ToString();
                        obj.FromUserName = r["FromUserName"].ToString();
                        obj.Amount = r["Amount"].ToString();

                        obj.IncomeType = (r["IncomeType"].ToString());
                        obj.Date = (r["CurrentDate"].ToString());


                        lst.Add(obj);
                    }
                    objreports.lstunpaidincomes = lst;
                    objreports.Message = "Unpaid Income";
                    objreports.Status = "0";
                    objreports.LoginId = objreports.LoginId;
                    return Json(objreports, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    sta.Status = "0";
                    sta.Message = "No Data Found ";
                    return Json(sta, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                sta.Status = "1";
                sta.Message = ex.Message;
                return Json(sta, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


        #region BusinessReportBy

        public ActionResult BusinessReportBy(BusinessReportAPI model)
        {
            UpdateProfile sta = new UpdateProfile();
            #region ddlleg
            List<SelectListItem> Leg = Common.Leg();
            ViewBag.Leg = Leg;
            #endregion ddlleg
            BusinessReport obj = new BusinessReport();
            List<BusinessReport> lst1 = new List<BusinessReport>();
            model.Leg = string.IsNullOrEmpty(model.Leg) ? null : model.Leg;
            model.FromDate = string.IsNullOrEmpty(model.FromDate) ? null : Common.ConvertToSystemDate(model.FromDate, "dd/MM/yyyy");
            model.ToDate = string.IsNullOrEmpty(model.ToDate) ? null : Common.ConvertToSystemDate(model.ToDate, "dd/MM/yyyy");
            model.LoginId = model.LoginId;

            // model.IsDownline = Request["Chk_"].ToString(); 
            DataSet ds11 = model.BusinessReport();

            if (ds11 != null && ds11.Tables.Count > 0 && ds11.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds11.Tables[0].Rows)
                {
                    BusinessReport Obj1 = new BusinessReport();
                    Obj1.LoginId = r["LoginId"].ToString();
                    Obj1.DisplayName = r["FirstName"].ToString();
                    Obj1.Leg = r["Leg"].ToString();
                    Obj1.ClosingDate = r["CalculationDate"].ToString();
                    Obj1.NetAmount = r["AMount"].ToString();
                    Obj1.LeadershipBonus = r["BV"].ToString();

                    lst1.Add(Obj1);
                }
                model.lstassociate = lst1;
                model.TotalNetAmount = double.Parse(ds11.Tables[0].Compute("sum(AMount)", "").ToString()).ToString("n2");
                model.TotalBV = double.Parse(ds11.Tables[0].Compute("sum(BV)", "").ToString()).ToString("n2");
                model.Status = "0";
                model.Message = "Buisness Details";
                model.Leg = model.Leg;
                model.IsDownline = model.IsDownline;
                model.FromDate = model.FromDate;
                model.ToDate = model.ToDate;
            }
            else
            {
                sta.Status = "1";
                sta.Message = "No Data Found"; return Json(sta, JsonRequestBehavior.AllowGet);
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Direct

        public ActionResult Direct(DirectAPI direct)
        {
            UpdateProfile objs = new UpdateProfile();
            if (direct.LoginId == "0" || direct.LoginId == null)
            {
                objs.Status = "1";
                objs.Message = "Please Select Login Id";
                return Json(objs, JsonRequestBehavior.AllowGet);
            }


            DirectA od = new DirectA();
            Direct obj = new Direct();
            
            List<Direct> lst = new List<Direct>();
            DataSet ds = direct.GetDirectList();
            if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Direct Objload = new Direct();
                    Objload.Mobile = dr["Mobile"].ToString();
                    Objload.Email = dr["Email"].ToString();
                    Objload.JoiningDate = dr["JoiningDate"].ToString();
                    Objload.Leg = dr["Leg"].ToString();
                    Objload.PermanentDate = (dr["PermanentDate"].ToString());
                    Objload.Status = (dr["Status"].ToString());
                    Objload.SponsorId = (dr["LoginId"].ToString());
                    Objload.SponsorName = (dr["Name"].ToString());
                    Objload.Package = (dr["ProductName"].ToString());

                    lst.Add(Objload);
                }
                direct.Status = "0";
                direct.Message = "Data Fetched";
                direct.lstdirect = lst;
                return Json(direct, JsonRequestBehavior.AllowGet);
            }
            else
            {
                od.Status = "1";
                od.Message = "No Data for this id";
                return Json(od, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult SearchDirect(DirectSearchAPI direct)
        {
            DirectSearchA od = new DirectSearchA();
            DirectSearch obj = new DirectSearch();
            direct.FromDate = string.IsNullOrEmpty(direct.FromDate) ? null : Common.ConvertToSystemDate(direct.FromDate, "dd/MM/yyyy");
            direct.ToDate = string.IsNullOrEmpty(direct.ToDate) ? null : Common.ConvertToSystemDate(direct.ToDate, "dd/MM/yyyy");
            
            List<DirectSearch> lst = new List<DirectSearch>();
            DataSet ds = direct.GetDirectList();
            if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DirectSearch Objload = new DirectSearch();
                    Objload.Mobile = dr["Mobile"].ToString();
                    Objload.Email = dr["Email"].ToString();
                    Objload.JoiningDate = dr["JoiningDate"].ToString();
                    Objload.Leg = dr["Leg"].ToString();
                    Objload.PermanentDate = (dr["PermanentDate"].ToString());
                    Objload.Status = (dr["Status"].ToString());
                    Objload.SponsorId = (dr["LoginId"].ToString());
                    Objload.SponsorName = (dr["Name"].ToString());
                    Objload.Package = (dr["ProductName"].ToString());

                    lst.Add(Objload);
                }
                direct.Status1 = "0";
                direct.Message = "Data Fetched";
                direct.lstdirect = lst;
                return Json(direct, JsonRequestBehavior.AllowGet);
            }
            else
            {
                od.Status = "1";
                od.Message = "No Data for this id";
                return Json(od, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion

        #region Downline


        public ActionResult Downline(DownlineAPI direct)
        {
            UpdateProfile objs = new UpdateProfile();
            if (direct.LoginId == "0" || direct.LoginId == null)
            {
                objs.Status = "1";
                objs.Message = "Please Select Login Id";
                return Json(objs, JsonRequestBehavior.AllowGet);
            }

            DownlineA od = new DownlineA();
            Downline obj = new Downline();

            List<Downline> lst = new List<Downline>();
            DataSet ds = direct.GetDownlineList();
            if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Downline Objload = new Downline();
                    Objload.Name = dr["Name"].ToString();
                    Objload.LoginId = dr["LoginId"].ToString();
                    Objload.JoiningDate = dr["JoiningDate"].ToString();
                    Objload.Leg = dr["Leg"].ToString();
                    Objload.PermanentDate = (dr["PermanentDate"].ToString());
                    Objload.Status = (dr["Status"].ToString());
                    Objload.Mobile = (dr["Mobile"].ToString());
                    Objload.Package = (dr["ProductName"].ToString());

                    lst.Add(Objload);
                }
                direct.Status = "0";
                direct.Message = "Data Fetched";
                direct.lstdirect = lst;
                return Json(direct, JsonRequestBehavior.AllowGet);
            }
            else
            {
                od.Status = "1";
                od.Message = "No Data for this id";
                return Json(od, JsonRequestBehavior.AllowGet);
            }

        }


           public ActionResult SearchDownline(DownlineSearchAPI direct)
        {
            UpdateProfile objs = new UpdateProfile();
            if (direct.LoginId == "0" || direct.LoginId == null)
            {
                objs.Status = "1";
                objs.Message = "Please Select Login Id";
                return Json(objs, JsonRequestBehavior.AllowGet);
            }

            DownlineSearchA od = new DownlineSearchA();
            DownlineSearch obj = new DownlineSearch();

            List<DownlineSearch> lst = new List<DownlineSearch>();
            DataSet ds = direct.GetDownlineList();
            if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DownlineSearch Objload = new DownlineSearch();
                    Objload.Name = dr["Name"].ToString();
                    Objload.LoginId = dr["LoginId"].ToString();
                    Objload.JoiningDate = dr["JoiningDate"].ToString();
                    Objload.Leg = dr["Leg"].ToString();
                    Objload.PermanentDate = (dr["PermanentDate"].ToString());
                    Objload.Status = (dr["Status"].ToString());
                    Objload.Mobile = (dr["Mobile"].ToString());
                    Objload.Package = (dr["ProductName"].ToString());

                    lst.Add(Objload);
                }
                direct.Status = "0";
                direct.Message = "Data Fetched";
                direct.lstdirect = lst;
                return Json(direct, JsonRequestBehavior.AllowGet);
            }
            else
            {
                od.Status = "1";
                od.Message = "No Data for this id";
                return Json(od, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion
    }
}