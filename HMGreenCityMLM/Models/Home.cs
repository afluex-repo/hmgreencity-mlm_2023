﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace HMGreenCityMLM.Models
{
    public class ProjectStatusResponse
    {
        public string Response { get; set; }
    }
    public class PlotPin
    {
        public string Fk_AssociateId { get; set; }
        public string Amount { get; set; }
        public string PlotDetails { get; set; }
        public string FK_BookingId { get; set; }
        public string LoginId { get; set; }
        public DataSet GeneratePin()
        {
            SqlParameter[] para ={
                                new SqlParameter ("@Fk_AssociateId",Fk_AssociateId),
                                new SqlParameter("@Amount",Amount),
                                new SqlParameter("@PlotDetails",PlotDetails),
                                new SqlParameter("@FK_BookingId",FK_BookingId),
                                new SqlParameter("@LoginId",LoginId),
            };
            DataSet ds = DBHelper.ExecuteQuery("GenerateEPinForRealestate", para);
            return ds;
        }

    }
    public class Home
    {
        public string Password { get; set; }
        public string LoginId { get; set; }

        public string SubMenuNameItem { get; set; }
        public string MenuNameItem { get; set; }
        [Required(ErrorMessage = "Please Fill SponsorId ")]
        public string SponsorId { get; set; }
        [Required(ErrorMessage = "Please Fill Sponsor Name ")]
        public string SponsorName { get; set; }
        [Required(ErrorMessage = "Please Fill FirstName")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Fill Email Id ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Fill Mobile No ")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Please select HMGreenCityMLM amount")]
        public string Commitment { get; set; }
        [Required(ErrorMessage = "Please select payment method ")]
        public List<Home> lstMenu { get; set; }

        public string PaymentMethod { get; set; }
        public DataSet Login()
        {
            SqlParameter[] para ={new SqlParameter ("@LoginId",LoginId),
                                new SqlParameter("@Password",Password)};
            DataSet ds = DBHelper.ExecuteQuery("Login", para);
            return ds;
        }

        public DataSet FranchiseLogin()
        {
            SqlParameter[] para ={new SqlParameter ("@LoginId",LoginId),
                                new SqlParameter("@Password",Password)};
            DataSet ds = DBHelper.ExecuteQuery("FranchiseLogin", para);
            return ds;
        }

        public DataSet Registration()
        {
            SqlParameter[] para = {

                                   new SqlParameter("@SponsorId",SponsorId),
                                   new SqlParameter("@Email",Email),
                                   new SqlParameter("@MobileNo",MobileNo),
                                   new SqlParameter("@FirstName",FirstName),
                                   new SqlParameter("@LastName",LastName),
                                    new SqlParameter("@PanCard",PanCard),
                                    new SqlParameter("@RegistrationBy",RegistrationBy),
                                     new SqlParameter("@Address",Address),
                                     new SqlParameter("@Gender",Gender),
                                      new SqlParameter("@AdharNo",AdharNo),
                                     new SqlParameter("@PinCode",PinCode),
                                     new SqlParameter("@Leg",Leg),
                                     new SqlParameter("@Password",Password),
                                     new SqlParameter("@AddedBy",AddedBy)

                                   };
            DataSet ds = DBHelper.ExecuteQuery("Registration", para);
            return ds;
        }

        public DataSet GetAdharDetails()
        {
            SqlParameter[] para = {
                new SqlParameter("@AdharNumber", AdharNo)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetAdharDetails", para);
            return ds;
        }

        public DataSet SaveLogMenuClick()
        {
            SqlParameter[] para = {
                new SqlParameter("@SubMenuNameItem", SubMenuNameItem),
                new SqlParameter("@MenuNameItem", MenuNameItem),
                 new SqlParameter("@LoginID", LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("SaveLogMenuClick", para);
            return ds;
        }




        public string RegistrationBy { get; set; }

        public string Response { get; set; }

        public string Gender { get; set; }
        public string PanCard { get; set; }
        public string AdharNo { get; set; }
        public string Result { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string OTP { get; set; }

        public string Leg { get; set; }
        public string AddedBy { get; set; }
        public DataTable PermissionDBSet { get; set; }
        public List<Home> lstsubmenu { get; set; }
        public string Pk_AdminId { get; set; }
        public string UserType { get; set; }
        public string Url { get; set; }
        public string MenuName { get; set; }
        public string MenuId { get; set; }
   public string Icon { get; set; }
        public string SubMenuId { get; set; }
        public string SubMenuName { get; set; }

        public DataSet loadHeaderMenu()
        {
            SqlParameter[] para = {
                                new SqlParameter("@PK_AdminId", Pk_AdminId),
                                 new SqlParameter("@UserType", UserType)
            };

            DataSet ds = DBHelper.ExecuteQuery("GetMenuUserWise", para);
            return ds;
        }
        public static Home GetMenus(string Pk_AdminId, string UserType)
        {
            Home model = new Home();
            
            List<Home> lstmenu = new List<Home>();
            List<Home> lstsubmenu = new List<Home>();

            model.Pk_AdminId = Pk_AdminId;
            model.UserType = UserType;
            DataSet dsHeader = model.loadHeaderMenu();
            if (dsHeader != null && dsHeader.Tables.Count > 0)
            {
                
                if (dsHeader.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in dsHeader.Tables[0].Rows)
                    {
                        Home obj = new Home();

                        obj.MenuId = r["PK_FormTypeId"].ToString();
                        obj.MenuName = r["FormType"].ToString();
                        obj.Icon = r["Icon"].ToString();
                        obj.Url = r["Url"].ToString();
                        lstmenu.Add(obj);
                    }

                    model.lstMenu = lstmenu;
                    foreach (DataRow r in dsHeader.Tables[1].Rows)
                    {
                        Home obj = new Home();
                        obj.Url = r["Url"].ToString();
                        obj.MenuId = r["FK_FormTypeId"].ToString();
                        obj.SubMenuId = r["PK_FormId"].ToString();
                        obj.SubMenuName = r["FormName"].ToString();
                        lstsubmenu.Add(obj);
                    }

                    model.lstsubmenu = lstsubmenu;

                }


            }
            return model;

        }
    }
}