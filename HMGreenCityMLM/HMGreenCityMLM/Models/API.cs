using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HMGreenCityMLM.Models
{
    public class API
    {
        public string Leg { get; set; }
        public string PinCode { get; set; }
        public string Gender { get; set; }
        public string RegistrationBy { get; set; }
        public string Address { get; set; }
        public string PanCard { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SponsorId { get; set; }
        public string UpdatedBy { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public string PasswordType { get; set; }
        public string FranchiseAdminID { get; set; }
        public string Name { get; set; }
        public string UsertypeName { get; set; }
        public string Pk_adminId { get; set; }
        public string TransPassword { get; set; }
        public string FullName { get; set; }
        public string UserType { get; set; }
        public string Profile { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string LoginId { get; set; }

        public string UserId { get; set; }
        public string Password { get; set; }

        public DataSet Login()
        {
            SqlParameter[] para ={new SqlParameter ("@LoginId",LoginId),
                                new SqlParameter("@Password",Password)};
            DataSet ds = DBHelper.ExecuteQuery("Login", para);
            return ds;
        }

        public DataSet UpdatePassword()
        {
            SqlParameter[] para = { new SqlParameter("@PasswordType",PasswordType ) ,
                                      new SqlParameter("@OldPassword", OldPassword) ,
                                      new SqlParameter("@NewPassword", NewPassword) ,
                                      new SqlParameter("@UpdatedBy", UpdatedBy)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("ChangePassword", para);
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
                                     new SqlParameter("@PinCode",PinCode),
                                     new SqlParameter("@Leg",Leg),
                                     new SqlParameter("@Password",Password)

                                   };
            DataSet ds = DBHelper.ExecuteQuery("Registration", para);
            return ds;
        }
    }
}