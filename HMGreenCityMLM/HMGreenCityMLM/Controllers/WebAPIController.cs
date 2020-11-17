using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMGreenCityMLM.Models;
using System.Web.Mvc;
using System.Data;
using BusinessLayer;

namespace HMGreenCityMLM.Controllers
{
    public class WebAPIController : Controller
    {
        #region Login
        public ActionResult Login(API model)
        {


            API obj = new API();
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
                string Password = model.Password;
                model.Password = Crypto.Encrypt(Password);
                DataSet dsResult = model.Login();
                {
                    if (dsResult.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        if ((dsResult.Tables[0].Rows[0]["UserType"].ToString() == "Associate"))
                        {
                            
                                obj.Status = "0";
                                obj.Message = "Successfully Logged in";
                                obj.LoginId = dsResult.Tables[0].Rows[0]["LoginId"].ToString();
                                obj.UserId = dsResult.Tables[0].Rows[0]["Pk_userId"].ToString();
                                obj.UserType = dsResult.Tables[0].Rows[0]["UserType"].ToString();
                                obj.FullName = dsResult.Tables[0].Rows[0]["FullName"].ToString();
                                obj.Password = dsResult.Tables[0].Rows[0]["Password"].ToString();
                                obj.TransPassword = dsResult.Tables[0].Rows[0]["TransPassword"].ToString();
                                obj.Profile = dsResult.Tables[0].Rows[0]["Profile"].ToString();
                                obj.Status = dsResult.Tables[0].Rows[0]["Status"].ToString();

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
                        }
                    }
                    else
                    {

                        obj.Status = "1";
                        obj.Message = "Invalid LoginId and Password.";
                    }

                }


                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                obj.Status = "1";
                obj.Message = ex.Message;
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region ChangePAssword

        public ActionResult ChangePassword(API model)
        {
            API obj = new API();
            if(model.PasswordType=="0" || model.PasswordType == null)
            {
                obj.Status = "1";
                obj.Message = "Please Select Password Type";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            if(model.NewPassword=="" || model.NewPassword == null)
            {
                obj.Status = "1";
                obj.Message = "Please Enter New Password";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            if (model.OldPassword == "" || model.OldPassword == null)
            {
                obj.Status ="1";
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
                    }
                    else
                    {
                        obj.Status = "1";
                        obj.Message = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }

                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                obj.Status = "1";
                obj.Message = ex.Message;
                return Json(obj, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region Registration

        public ActionResult Registration(API model)
        {
            API obj = new API();
            if(model.SponsorId == "" || model.SponsorId == null)
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
                        try
                        {
                            string str2 = BLSMS.Registration(ds.Tables[0].Rows[0]["Name"].ToString(), ds.Tables[0].Rows[0]["LoginId"].ToString(), Crypto.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString()));
                            BLSMS.SendSMSNew(model.MobileNo, str2);
                        }
                        catch { }
                        obj.Status = "0";
                        obj.Message = "Registered Successfully";

                    }
                    else
                    {
                        obj.Status = "1";
                        obj.Message = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                obj.Status = "1";
                obj.Message = ex.Message;
                return Json(obj, JsonRequestBehavior.AllowGet);
            }


        }

        #endregion

        #region TopupList

        public ActionResult TopupList(API model)
        {
            API obj = new API();
            if(model.LoginId =="" || model.LoginId == null)
            {
                obj.Status = "1";
                obj.Message = "Please enter LoginId";
                return Json(obj, JsonRequestBehavior.AllowGet);
            }

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}