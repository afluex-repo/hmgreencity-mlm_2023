using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HMGreenCityMLM.Models
{
    public class API : Common
    {
        public string Website { get; set; }
        public string LandLine { get; set; }
        public string ContactNo { get; set; }
        public string City1 { get; set; }
        public string State1 { get; set; }
        public string Pin1 { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyName { get; set; }
        public string TaxAdded { get; set; }
        public string ValueBeforeTax { get; set; }
        public string AssociateAddress { get; set; }
        public string PurchaseDate { get; set; }
        public string TotalFinalAmountWords { get; set; }
        public string TotalFinalAmount { get; set; }
        public string OrderNo { get; set; }
        public string invid { get; set; }
        public string HSNCode { get; set; }
        public string FinalAmount { get; set; }
        public string SGST { get; set; }
        public string CGST { get; set; }
        public string IGST { get; set; }
        public string MRP { get; set; }
        public string Quantity { get; set; }
        public List<API> lsttopupreport { get; set; }
        public string Amount { get; set; }
        public string ProductName { get; set; }
        public string UpgradtionDate { get; set; }
        public string SectorName { get; set; }
        public string SiteName { get; set; }
        public string FK_InvestmentID { get; set; }
        public string Package { get; set; }
        public string ToDate { get; set; }
        public string FromDate { get; set; }
        public string Leg { get; set; }
        public string Gender { get; set; }
        public string RegistrationBy { get; set; }
        public string PanCard { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SponsorId { get; set; }
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





    }
    public class LoginAPI
    {
        public string LoginId { get; set; }

        public string UserId { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string UserType { get; set; }
        public string FullName { get; set; }
        public string Pk_adminId { get; set; }
        public string FranchiseAdminID { get; set; }
        public string Profile { get; set; }
        public DataSet Login()
        {
            SqlParameter[] para ={new SqlParameter ("@LoginId",LoginId),
                                new SqlParameter("@Password",Password)};
            DataSet ds = DBHelper.ExecuteQuery("Login", para);
            return ds;
        }
    }
    public class FetchLeg
    {
        public string LegId;
        public string LegName { get; set; }
    }

    public class Downl
    {
        public List<FetchLeg> items { get; set; }
        public string Leg { get; set; }
    }

    public class FetchState
    {
        public string StatusId ;
        public string StatusName;
        
        
    }

    public class State
    {
        public List<FetchState> items { get; set; }
        public string Status { get; set; }
        
    }

    public class ChangePasswordAPI
    {
        public string PasswordType { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public string UpdatedBy { get; set; }

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
    }


    public class RegistrationAPI
    {

        public string Status { get; set; }
        public string Message { get; set; }
        public string Leg { get; set; }

        public string Password { get; set; }
        public string RegistrationBy { get; set; }
        public string SponsorId { get; set; }
        public string MobileNo { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string LoginId { get; set; }

        public string TransPassword { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public string PanCard { get; set; }
        public string Gender { get; set; }

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

    public class TopUpAPI
    {
        public List<TopUp> lsttopupreport { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string LoginId { get; set; }
        public DataSet GetTopupReport()
        {
            SqlParameter[] para = {   new SqlParameter("@LoginID", LoginId)
                                  };

            DataSet ds = DBHelper.ExecuteQuery("GetTopupreport", para);
            return ds;
        }
    }
    public class TopUp
    {
    public string PlotNumber { get; set; }
    public string Name { get; set; }
    public string FromDate { get; set; }
    public string ToDate { get; set; }
    public string Package { get; set; }
    public string UpgradtionDate { get; set; }
    public string ProductName { get; set; }
    public string Amount { get; set; }
    public string PlotNumber { get; set; }
    public string SiteName { get; set; }
    public string FK_InvestmentID { get; set; }
    public string SectorName { get; set; }

       
    }

    public class PrintTopupAPI
    {
        public List<PrintTopup> lsttopupreport { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string invid { get; set; }
        public string LoginId { get; set; }

        public DataSet PrintTopUp()
        {
            SqlParameter[] para = { new SqlParameter("@Pk_InvestmentId", LoginId), };
            DataSet ds = DBHelper.ExecuteQuery("PrintTopUpReport", para);
            return ds;
        }
    }


    public class PrintTopup
    {
       
        public string LoginId { get; set; }
        public string FK_InvestmentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string LandLine { get; set; }
        public string ContactNo { get; set; }
        public string City1 { get; set; }
        public string State1 { get; set; }
        public string PinCode { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyName { get; set; }
        public string TaxAdded { get; set; }
        public string ValueBeforeTax { get; set; }
        public string AssociateAddress { get; set; }
        public string PurchaseDate { get; set; }
        public string TotalFinalAmountWords { get; set; }
        public string TotalFinalAmount { get; set; }
        public string Quantity { get; set; }
        public string MRP { get; set; }
        public string IGST { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public string FinalAmount { get; set; }
        public string HSNCode { get; set; }
        public string ProductName { get; set; }

        
        public string OrderNo { get; set; }



    }

    public class PayoutReportAPI
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string LoginId { get; set; }
       
        public List<PayoutReport> lstPayoutDetail { get; set; }

        public DataSet GetPayoutReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("PayoutReportForMember", para);
            return ds;
        }
    }

    public class PayoutReport
    {
        public string LoginId { get; set; }
        public string DisplayName { get; set; }
        public string PayoutNo { get; set; }
        public string ClosingDate { get; set; }
        public string BinaryIncome { get; set; }
        public string GrossAmount { get; set; }
        public string DirectIncome { get; set; }
        
        public string ProcessingFee { get; set; }

        public string LeadershipBonus { get; set; }
        public string TDSAmount { get; set; }
        public string NetAmount { get; set; }
        public string ProductWallet { get; set; }
        public string EncryptLoginID { get; set; }
        public string EncryptPayoutNo { get; set; }
    }

    public class PayoutReportSearchAPI
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string LoginId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string PayoutNo { get; set; }
        public List<PayoutReportSearch> lstPayoutDetail { get; set; }

        public DataSet GetPayoutReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                      new SqlParameter("@PayoutNo", PayoutNo),

                                         new SqlParameter("@FromDate", FromDate),
                                         new SqlParameter("@ToDate", ToDate),

            };
            DataSet ds = DBHelper.ExecuteQuery("PayoutReportForMember", para);
            return ds;
        }
    }

    public class PayoutReportSearch
    {
        
        public string LoginId { get; set; }
        public string DisplayName { get; set; }
        public string PayoutNo { get; set; }
        public string ClosingDate { get; set; }
        public string BinaryIncome { get; set; }
        public string GrossAmount { get; set; }
        public string DirectIncome { get; set; }
        
        public string ProcessingFee { get; set; }

        public string LeadershipBonus { get; set; }
        public string TDSAmount { get; set; }
        public string NetAmount { get; set; }
        public string ProductWallet { get; set; }

    }

    public class AssociateDashBoardAPI
    {
        public List<AssoeDashInvst> lstinvestment { get; set; }
        public string SelfBusiness { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string TotalDownline { get; set; }
        public string TotalDirects { get; set; }
        public string PayoutWalletBalance { get; set; }
        public string TotalPayout { get; set; }
        public string TotalDeduction { get; set; }
        public string TotalAdvance { get; set; }
        public string TotalActive { get; set; }
        public string TotalInActive { get; set; }
        public string UnpaidIncome { get; set; }
        public string PaidBusinessLeft { get; set; }
        public string PaidBusinessRight { get; set; }
        public string TotalBusinessLeft { get; set; }
        public string TotalBusinessRight { get; set; }
        public string CarryLeft { get; set; }
///public string TeamBusiness { get; set; }
        public string CarryRight { get; set; }

   //     public string DirectBusiness { get; set; }
        public string Fk_UserId { get; set; }


        public DataSet GetAssociateDashboard()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_UserId", Fk_UserId), };
            DataSet ds = DBHelper.ExecuteQuery("GetDashBoardDetailsForAssociate", para);
            return ds;
        }

    }
    public class Response
    {
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
    public class UploadKYC
    {
        public string Fk_UserId { get; set; }
        public string ImageURL { get; set; }
        public string AdharNumber { get; set; }
        public string AdharImage { get; set; }
        public string PanImage { get; set; }
        public string PanNumber { get; set; }
        public string DocNumber { get; set; }
        public string DocImage { get; set; }

        public DataSet UpdateImage()
        {
            SqlParameter[] para = { new SqlParameter("@PK_UserID",Fk_UserId ) ,
                                      new SqlParameter("@ProfilePic", ImageURL),
                                   //   new SqlParameter("@ProfilePic", ProfilePicture)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("UpdateImage", para);
            return ds;
        }

        public DataSet UploadKYCDocuments()
        {
            SqlParameter[] para = { new SqlParameter("@FK_UserID",Fk_UserId ) ,
                                      new SqlParameter("@AdharNumber", AdharNumber) ,
                                       new SqlParameter("@AdharImage", AdharImage),
                                         new SqlParameter("@PanNumber", PanNumber) ,
                                       new SqlParameter("@PanImage", PanImage),
                                        new SqlParameter("@DocumentNumber", DocNumber) ,
                                       new SqlParameter("@DocumentImage", DocImage),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("UploadKYC", para);
            return ds;
        }

    }
    public class Upload
    {
        public string Fk_UserId { get; set; }
        public string ImageURL { get; set; }

        public DataSet UpdateImage()
        {
            SqlParameter[] para = { new SqlParameter("@PK_UserID",Fk_UserId ) ,
                                      new SqlParameter("@ProfilePic", ImageURL),
                                   //   new SqlParameter("@ProfilePic", ProfilePicture)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("UpdateImage", para);
            return ds;
        }

    }


    public class UploadPan
    {
        public string Fk_UserId { get; set; }
        public string ImageURL { get; set; }
        public string PanNumber { get; set; }
        
        public DataSet UploadPanDocuments()
        {
            SqlParameter[] para = { new SqlParameter("@FK_UserID",Fk_UserId ) ,
                                      new SqlParameter("@PanNumber", PanNumber) ,
                                       new SqlParameter("@PanImage", ImageURL),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("UploadKYC", para);
            return ds;
        }

    }

    public class AssoeDashInvstAPI
    {

        public string Status { get; set; }
        public string Message { get; set; }
        public string Fk_UserId { get; set; }
        public List<AssoeDashInvst> lstinvestment { get; set; }

        public DataSet GetAssociateDashboard()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_UserId", Fk_UserId), };
            DataSet ds = DBHelper.ExecuteQuery("GetDashBoardDetailsForAssociate", para);
            return ds;
        }
    }
    public class AssoeDashInvst
    {
        public string ProductName { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }

    }

    public class TotalBusinessAPI
    {
        public string Fk_UserId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        public DataSet GetAssociateDashboard()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_UserId", Fk_UserId), };
            DataSet ds = DBHelper.ExecuteQuery("GetDashBoardDetailsForAssociate", para);
            return ds;
        }
    }


    public class TotalBusiness
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public string PaidBusinessLeft { get; set; }
        public string PaidBusinessRight { get; set; }
        public string TotalBusinessLeft { get; set; }
        public string TotalBusinessRight { get; set; }
        public string CarryLeft { get; set; }
        public string TeamBusiness { get; set; }
        public string CarryRight { get; set; }
    }

    public class ViewProfileAPI
    {
        public string LoginId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        public DataSet GetUserProfile()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId) };
            DataSet ds = DBHelper.ExecuteQuery("UserProfile", para);
            return ds;
        }
    }

    public class ViewProfile
    {
        public string Pk_UserId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string LoginId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JoiningDate { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string SponsorId { get; set; }
        public string SponsorName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string IFSC { get; set; }
        public string ProfilePicture { get; set; }
    }

    public class UpdateProfileAPI
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string LoginId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string IFSC { get; set; }
     
        public string BankBranch { get; set; }
        public string PK_UserID { get; set; }


        public DataSet UpdateProfile()
        {
            SqlParameter[] para = { new SqlParameter("@PK_UserID",PK_UserID ) ,
                                      new SqlParameter("@FirstName", FirstName) ,
                                      new SqlParameter("@LastName", LastName) ,
                                      new SqlParameter("@Mobile", Mobile) ,
                                      new SqlParameter("@Email", EmailId) ,
                                      new SqlParameter("@AccountNo", AccountNumber) ,
                                      new SqlParameter("@BankName", BankName) ,
                                      new SqlParameter("@BankBranch", BankBranch) ,
                                      new SqlParameter("@IFSC", IFSC),
                                   //   new SqlParameter("@ProfilePic", ProfilePicture)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("UpdateProfile", para);
            return ds;
        }
    }

    public class UpdateProAPI
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string PK_UserID { get; set; }
       public string ProfilePicture { get; set; }

        public DataSet UpdateProfile()
        {
            SqlParameter[] para = { new SqlParameter("@PK_UserID",PK_UserID ) ,
                                      new SqlParameter("@ProfilePic", ProfilePicture)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("UpdateProfile", para);
            return ds;
        }
    }

    public class UpdateProfile
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public class PayoutLedgerAPI
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Fk_UserId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public List<PayoutLedger> lstpayoutledger { get; set; }

        public DataSet PayoutLedger()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_UserId", Fk_UserId),
                                       new SqlParameter("@FromDate", FromDate),
                                        new SqlParameter("@ToDate", ToDate),

                                     };
            DataSet ds = DBHelper.ExecuteQuery("GetPayoutLedger", para);
            return ds;
        }

    }

    public class PayoutLedgerA
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public class PayoutLedger
    {
      
      
        public string Narration { get; set; }
        public string DrAmount { get; set; }
        public string CrAmount { get; set; }
        public string AddedOn { get; set; }
        public string PayoutBalance { get; set; }
    }


    public class DirectSearchAPI
    {
        public string Status1 { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public string FromDate { get; set; }
        public string LoginId { get; set; }
        public string ToDate { get; set; }
        //public string FromActivationDate { get; set; }
       // public string ToActivationDate { get; set; }
        public string Leg { get; set; }
        public List<DirectSearch> lstdirect { get; set; }
        public DataSet GetDirectList()
        {

            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@Name", Name),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
                                   // new SqlParameter("@FromActivationDate", FromActivationDate),
                                   // new SqlParameter("@ToActivationDate", ToActivationDate),
                                    new SqlParameter("@Leg", Leg),
                                    new SqlParameter("@Status", Status),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetDirectList", para);
            return ds;
        }
    }
    public class DirectSearch
    {
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string JoiningDate { get; set; }
        public string Leg { get; set; }
        public string PermanentDate { get; set; }
        public string Status { get; set; }
        public string SponsorId { get; set; }
        public string SponsorName { get; set; }
        public string Package { get; set; }
    }
    public class DirectSearchA
    {
        public string Status1 { get; set; }
        public string Message { get; set; }
    }
    public class SponsorNameAPI
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string sponsorId { get; set; }
      

        public DataSet GetMemberDetails()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", sponsorId),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetMemberName", para);

            return ds;
        }
    }

    public class SponsorNameA
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string SponsorName { get; set; }

    }

    public class TreeAPI
    {
        public List<Tree> GetGenelogy { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string LoginId { get; set; }
        public string Fk_headId { get; set; }
        public DataSet GetTree()
        {
            SqlParameter[] para = {   new SqlParameter("@LoginId", LoginId),
                 new SqlParameter("@Fk_headId", Fk_headId)
                                  };

            DataSet ds = DBHelper.ExecuteQuery("GetTree", para);
            return ds;
        }
    }

    public class Tree
    {
        public string Fk_UserId { get; set; }
        public string SponsorId { get; set; }
        public string Fk_ParentId { get; set; }
        public string TeamPermanent { get; set; }
        public string LoginId { get; set; }
        public string Fk_SponsorId { get; set; }
        public string MemberName { get; set; }
        public string MemberLevel { get; set; }

        public string Id { get; set; }
        public string Leg { get; set; }

        public string ActivationDate { get; set; }
        public string ActiveLeft { get; set; }
        public string ActiveRight { get; set; }
        public string InactiveLeft { get; set; }
        public string InactiveRight { get; set; }
        public string BusinessLeft { get; set; }
        public string BusinessRight { get; set; }
        public string ImageURL { get; set; }
    }

    public class ReportsAPI
    {
        public List<Report> lstunpaidincomes { get; set; }
        public string LoginId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public DataSet GetUnPaidIncomes()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId) };
            DataSet ds = DBHelper.ExecuteQuery("GetUnPaidIncomes", para);
            return ds;
        }
    }

    public class Report
    {
      
        public string FromLoginId { get; set; }
        public string FromUserName { get; set; }
        public string Amount { get; set; }
        public string IncomeType { get; set; }
        public string Date { get; set; }
    }


    public class BusinessReportAPI
    {
        public List<BusinessReport> lstassociate { get; set; }
        public string Leg { get; set; }
        public string ToDate { get; set; }
        public string FromDate { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string LoginId { get; set; }
        public string TotalNetAmount { get; set; }
        public string TotalBV { get; set; }
        public string IsDownline { get; set; }
        public DataSet BusinessReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),

                                     new SqlParameter("@Leg", Leg),
                                    new SqlParameter("@IsDownline", IsDownline),

            };
            DataSet ds = DBHelper.ExecuteQuery("GetBusiness", para);
            return ds;
        }
    }

    public class BusinessAPI
    {
        public List<Business> lstassociate { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string LoginId { get; set; }
        public DataSet BusinessReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId)

            };
            DataSet ds = DBHelper.ExecuteQuery("GetBusiness", para);
            return ds;
        }
    }

    public class BusinessReport
    {
        public string Leg { get; set; }
        public string ClosingDate { get; set; }
        public string DisplayName { get; set; }
        public string LoginId { get; set; }
        public string NetAmount { get; set; }
        public string LeadershipBonus { get; set; }

    }
    public class Business
    {
        public string Leg { get; set; }
        public string ClosingDate { get; set; }
        public string DisplayName { get; set; }
        public string LoginId { get; set; }
        public string NetAmount { get; set; }
        public string LeadershipBonus { get; set; }

    }

    public class DirectAPI
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string LoginId { get; set; }
        public List<Direct> lstdirect { get; set; }
        public DataSet GetDirectList()
        {

            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetDirectList", para);
            return ds;
        }
    }
    public class Direct
    {
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string JoiningDate { get; set; }
        public string Leg { get; set; }
        public string PermanentDate { get; set; }
        public string Status { get; set; }
        public string SponsorId { get; set; }
        public string SponsorName { get; set; }
        public string Package { get; set; }
    }
    public class DirectA
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }


     public class DownlineAPI
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string LoginId { get; set; }
        public List<Downline> lstdirect { get; set; }
        public DataSet GetDownlineList()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("DownlineList", para);
            return ds;
        }
    }
    public class Downline
    {
        public string Name { get; set; }
        public string LoginId { get; set; }
        public string JoiningDate { get; set; }
        public string Leg { get; set; }
        public string PermanentDate { get; set; }
        public string Status { get; set; }
        public string Mobile { get; set; }
        public string Package { get; set; }
    }
    public class DownlineA
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }




    public class DownlineSearchAPI
    {
        public string Status { get; set; }
        public string Status1 { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public string FromDate { get; set; }
        public string LoginId { get; set; }
        public string ToDate { get; set; }
        //public string FromActivationDate { get; set; }
        // public string ToActivationDate { get; set; }
        public string Leg { get; set; }
        public List<DownlineSearch> lstdirect { get; set; }
        public DataSet GetDownlineList()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@Name", Name),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
                                    new SqlParameter("@Leg", Leg),
                                    new SqlParameter("@Status", Status), };
            DataSet ds = DBHelper.ExecuteQuery("DownlineList", para);
            return ds;
        }
    }
    public class DownlineSearch
    {
        public string Name { get; set; }
        public string LoginId { get; set; }
        public string JoiningDate { get; set; }
        public string Leg { get; set; }
        public string PermanentDate { get; set; }
        public string Status { get; set; }
        public string Mobile { get; set; }
        public string Package { get; set; }
    }
    public class DownlineSearchA
    {
        public string Status1 { get; set; }
        public string Message { get; set; }
    }
}