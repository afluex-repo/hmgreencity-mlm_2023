﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HMGreenCityMLM.Models
{
    public class Reports : Common
    {
        public string SiteId { get; set; }
        public string Total { get; set; }
        public string ReceiptNo { get; set; }
        public string DirectBusiness { get; set; }
        public string TotalBusiness { get; set; }
        public string RightBusiness { get; set; }
        public string LeftBusiness { get; set; }
        public List<Reports> lstDateWiseBusiness { get; set; }
        public List<Reports> lstassociatenew { get; set; }
        public string PK_LoginLogId { get; set; }
        public string IP { get; set; }
        public string LoginDateTime { get; set; }
        public string UserType { get; set; }
        public List<Reports> lstAssociateLoginLog { get; set; }
        public string SectorName { get; set; }
        public string SiteName { get; set; }
        public string BlockName { get; set; }
        public string LoginIDD { get; set; }
        public string UserName { get; set; }
        public string EncryptPayoutNo { get; set; }
        public string BatchNo { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public string IGST { get; set; }
        public string MRP { get; set; }
        public string TaxableAmount { get; set; }
        public string FinalAmount { get; set; }
        public string FK_InvestmentID { get; set; }
        public string MemberAccNo { get; set; }
        public string IFSCCode { get; set; }
        public string BankName { get; set; }
        public string AccountHolderName { get; set; }
        public string MaturityDate { get; set; }
        public string Description { get; set; }
        public string Pk_PaidBoosterId { get; set; }
        public string TransactionNo { get; set; }
        public string EncryptName { get; set; }
        public string AchievementDate { get; set; }
        public bool IsDownline { get; set; }
        public string FromActivationDate { get; set; }
        public string EPinNo { get; set; }
        public string TransferDate { get; set; }
        public string ToActivationDate { get; set; }
        public string PAN { get; set; }
        public string Leg { get; set; }
        public bool IsInclude { get; set; }
        public string Reward { get; set; }

        public string AdminLoginId { get; set; }
        public string LoginId { get; set; }
        public string TeamLoginId { get; set; }
        public string PayoutLoginId { get; set; }
        public string Fk_CompanyId { get; set; }

        public string Name { get; set; }

        public string NewRank { get; set; }
        public string OldRank { get; set; }
        public string Pk_UserId { get; set; }

        public string JoiningDate { get; set; }

        public DateTime JoiningDates { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }
        public string CssClass { get; set; }
        public string SponsorId { get; set; }
        public string PayoutNo { get; set; }
        public string SponsorName { get; set; }
        public List<Reports> lstassociate { get; set; }
        public List<Reports> lstBusinessStatus { get; set; }

        public string PermanentDate { get; set; }
        public string ActivationDate { get; set; }

        public string Status { get; set; }
        public string Rank { get; set; }

        public string StatusColor { get; set; }
        public string GreenDate { get; set; }
        public string YellowDate { get; set; }

        public string UploadDate { get; set; }

        
        public string FromLoginId { get; set; }

        public string FromUserName { get; set; }

        public string IncomeType { get; set; }

        public string Date { get; set; }
        public string RankUpdateDate { get; set; }

        public List<Reports> lstunpaidincomes { get; set; }

        public string TransactionDate { get; set; }
        public string BankBranch { get; set; }

        public string FromName { get; set; }

        public string ToName { get; set; }

        public string ToLoginID { get; set; }

        public string ToTeamLoginId { get; set; }

        public string ClosingDate { get; set; }

        public string BinaryIncome { get; set; }

        public string GrossAmount { get; set; }

        public string TDSAmount { get; set; }

        public string ProcessingFee { get; set; }

        public string NetAmount { get; set; }
        public string Password { get; set; }

        public string isBlocked { get; set; }

        public string PK_DocumentID { get; set; }

        public string DocumentNumber { get; set; }

        public string DocumentType { get; set; }

        public string DocumentImage { get; set; }
        public string AdharBacksideImage { get; set; }

        

        public List<Reports> lstuser { get; set; }
        public List<Reports> lsttopupreport { get; set; }
        public List<Reports> lsttopupreportnew { get; set; }
        public List<Reports> lstRewardList { get; set; }
        public List<Reports> lstAdvancePaymentReport { get; set; }

        public List<Reports> lstdownlineAchieverreport { get; set; }
        public List<Reports> lstdownAchieverAssoreport { get; set; }

        public string UpgradtionDate { get; set; }

        public string Package { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentMode { get; set; }
        public string Quantity { get; set; }
        public string Amount { get; set; }
        public decimal Amount1 { get; set; }
        public decimal TDSAmount1 { get; set; }
        public decimal GrossAmount1 { get; set; }
        public string TopupBy { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public List<Reports> lstpermission { get; set; }
        public string FormName { get; set; }
        public string FormType { get; set; }

        public string FromDatenew { get; set; }
        public string ToDatenew { get; set; }
        public string NFromDate { get; set; }
        public string NToDate { get; set; }

        public string LastTopUpAmount { get; set; }
        public bool IsNewBusiness { get; set; }
        public string LastTopUpDate { get; set; }
        public string BusinessType { get; set; }
        //public bool IsInclude { get; set; }
        //public string Reward { get; set; }
        
        public string UserID { get; set; }
        public string PanNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FatherName { get; set; }
        //public string NomineeRelation { get; set; }
        //public string NomineeAge { get; set; }
        //public string Nominee { get; set; }
        public string FK_SponsorId { get; set; }
        public string EncryptKey { get; set; }
        public string AssociateName { get; set; }
        public string AssociateID { get; set; }

        public List<Reports> ListCust { get; set; }
        public string MobileNo { get; set; }
        public string AdharNo { get; set; }
        public string PanCard { get; set; }
        public string Gender { get; set; }
        public string Response { get; set; }
        public string RegistrationBy { get; set; }

        public string RankName { get; set; }
        public string FK_RankId { get; set; }
        public string TotalAchieverRight { get; set; }
        public string TotalAchieverLeft { get; set; }
        public List<Reports> lstdownlineAchieverreportforadmin { get; set; }
        public List<Reports> lstdownAchieverAdminreport { get; set; }

       
        public List<Reports> lstDefaultAssociateList { get; set; }
        public List<Reports> lstRankAchievementReports { get; set; }


        public string UserTypeName { get; set; }

        public string Pk_AdminId { get; set; }
        public bool SevenDayView { get; set; }

        public string Pk_PayoutPaidId { get; set; }

        public decimal  AmountNew { get; set; }




        public DataSet GetPayoutReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginID", ToLoginID),
                                    new SqlParameter("@PayoutNo", PayoutNo),
                                    new SqlParameter("@Name", Name),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
                                    new SqlParameter("@IsDownline", IsDownline),
                                    new SqlParameter("@Leg", Leg) };


            DataSet ds = DBHelper.ExecuteQuery("PayoutReportForMember", para);
            return ds;
        }

        public DataSet AssociateLoginLogList()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                new SqlParameter("@Name", Name)
            };
            DataSet ds = DBHelper.ExecuteQuery("AssociateLoginLogList", para);
            return ds;
        }
        public DataSet GetProductPayoutReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@PayoutNo", PayoutNo),
                                    new SqlParameter("@Name", Name),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
                                    new SqlParameter("@IsDownline", IsDownline),
                                    new SqlParameter("@Leg", Leg) };
            DataSet ds = DBHelper.ExecuteQuery("GetProductPayoutReport", para);
            return ds;
        }
        public DataSet GetIncomeReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@ToLoginId", ToLoginID),
                                    new SqlParameter("@FromName", FromName),
                                    new SqlParameter("@ToName", ToName),
                                    new SqlParameter("@IncomeType", IncomeType),
                                    new SqlParameter("@Status", Status),
                                    new SqlParameter("@FromDate", NFromDate),
                                    new SqlParameter("@ToDate", NToDate),
                                 new SqlParameter("@IsDownline", IsDownline)
            };
            DataSet ds = DBHelper.ExecuteQuery("IncomeReport", para);
            return ds;
        }



        public DataSet GetIncomeReportNew()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@ToLoginId", ToLoginID),
                                    new SqlParameter("@FromName", FromName),
                                    new SqlParameter("@ToName", ToName),
                                    new SqlParameter("@IncomeType", IncomeType),
                                    new SqlParameter("@Status", Status),
                                    new SqlParameter("@FromDate", NFromDate),
                                    new SqlParameter("@ToDate", NToDate),
                                 new SqlParameter("@IsDownline", IsDownline)
            };
            DataSet ds = DBHelper.ExecuteQuery("IncomeReportNew", para);
            return ds;
        }


        public DataSet GetProductIncomeReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@ToLoginId", ToLoginID),
                                    new SqlParameter("@FromName", FromName),
                                    new SqlParameter("@ToName", ToName),
                                    new SqlParameter("@IncomeType", IncomeType),
                                    new SqlParameter("@Status", Status),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
            };
            DataSet ds = DBHelper.ExecuteQuery("ProductIncomeReport", para);
            return ds;
        }

        public DataSet GetDatebusinessdetails()
        {
            SqlParameter[] para = {
                                    new SqlParameter("@LoginId", ToLoginID),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
                                       new SqlParameter("@IsDownline", IsDownline)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetBusinessDetails", para);
            return ds;
        }
        public DataSet GetAssociateList()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@Name", Name),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
                                    new SqlParameter("@SponsorID", SponsorId),
                                    new SqlParameter("@SponsorName", SponsorName),
                                    new SqlParameter("@Status", Status),
                                    new SqlParameter("@IsDownline", IsDownline),
                                    new SqlParameter("@Leg", Leg),
                                       new SqlParameter("@AdharNumber", AdharNo)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetAssociateList", para);
            return ds;
        }
        public DataSet AssociateListForKYC()
        {
            SqlParameter[] para = {
                new SqlParameter("@LoginId", LoginId),
                 new SqlParameter("@Status", Status),
                  new SqlParameter("@FromDate", FromDate),
                   new SqlParameter("@ToDate", ToDate)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetAgentListForKYC", para);
            return ds;
        }

        public DataSet GetDirectList()
        {

            SqlParameter[] para = {
                           new SqlParameter("@LoginId", LoginId),
                           new SqlParameter("@Name", Name),
                           new SqlParameter("@FromDate", FromDate),
                           new SqlParameter("@ToDate", ToDate),
                           new SqlParameter("@FromActivationDate", FromActivationDate),
                           new SqlParameter("@ToActivationDate", ToActivationDate),
                           new SqlParameter("@Leg", Leg),
                           new SqlParameter("@Status", Status),
                           };
            DataSet ds = DBHelper.ExecuteQuery("GetDirectList", para);
            return ds;
        }

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
        public DataSet ApproveKYC()
        {
            SqlParameter[] para = { new SqlParameter("@LoginID", LoginId),
                                      new SqlParameter("@PK_DocumentID", PK_DocumentID),
                                      new SqlParameter("@DocumentType", DocumentType),
                                      new SqlParameter("@Status", Status),
                                      new SqlParameter("@UpdatedBy", AddedBy)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("ApproveKYC", para);
            return ds;
        }
        public DataSet RejectKYC()
        {
            SqlParameter[] para = { new SqlParameter("@LoginID", LoginId),
                                      new SqlParameter("@PK_DocumentID", PK_DocumentID),
                                      new SqlParameter("@DocumentType", DocumentType),
                                      new SqlParameter("@Status", Status),
                                      new SqlParameter("@UpdatedBy", AddedBy)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("RejectKYC", para);
            return ds;
        }
        public DataSet DeletedKYC()
        {
            SqlParameter[] para = { new SqlParameter("@LoginID", LoginId),
                                      new SqlParameter("@PK_DocumentID", PK_DocumentID),
                                      new SqlParameter("@DocumentType", DocumentType),
                                      new SqlParameter("@Status", Status),
                                      new SqlParameter("@UpdatedBy", AddedBy)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("DeleteKYC", para);
            return ds;
        }

        public DataSet GetTopupReport()
        {
            SqlParameter[] para = {   new SqlParameter("@LoginID", LoginId),
                                      new SqlParameter("@Name", Name),
                                      //new SqlParameter("@FromDate", FromDate),
                                      //new SqlParameter("@ToDate", ToDate),
                                      new SqlParameter("@FromDate", FromDatenew),
                                      new SqlParameter("@ToDate", ToDatenew),
                                      new SqlParameter("@Package", Package),
                                      new SqlParameter("@SiteId", SiteId),
                                      new SqlParameter("@ClaculationStatus", Status),
                                      new SqlParameter("@Fk_BusinessId", BusinessType)
                                  };

            DataSet ds = DBHelper.ExecuteQuery("GetTopupreport", para);
            return ds;
        }
        public DataSet GetTopupreportProduct()
        {
            SqlParameter[] para = {   new SqlParameter("@LoginID", LoginId),
                                      new SqlParameter("@Name", Name),
                                      new SqlParameter("@FromDate", FromDate),
                                      new SqlParameter("@ToDate", ToDate),
                                      new SqlParameter("@Package", Package),
                                      new SqlParameter("@ClaculationStatus", Status),
                                  };

            DataSet ds = DBHelper.ExecuteQuery("GetTopupreportProduct", para);
            return ds;
        }
        public DataSet GetTopupReportByKit()
        {
            SqlParameter[] para = {   new SqlParameter("@LoginID", LoginId),
                                      new SqlParameter("@Name", Name),
                                      new SqlParameter("@FromDate", FromDate),
                                      new SqlParameter("@ToDate", ToDate),
                                      new SqlParameter("@Package", Package),
                                      new SqlParameter("@ClaculationStatus", Status),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetTopupreportByKit", para);
            return ds;
        }

        public List<Reports> lsttransactionlog { get; set; }
        public List<Reports> lstVoucherLedger { get; set; }
        public string Action { get; set; }

        public string Remarks { get; set; }

        public DataSet GetTransactionLog()
        {
            SqlParameter[] para = {     new SqlParameter("@Action", Action),
                                        new SqlParameter("@FromDate", FromDate),
                                        new SqlParameter("@ToDate", ToDate),
                                        new SqlParameter("@AdminLoginId",AdminLoginId),
                                        new SqlParameter("@LoginId",LoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetTransactionLog", para);
            return ds;
        }

        public DataSet GetUnPaidIncomes()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId) };
            DataSet ds = DBHelper.ExecuteQuery("GetUnPaidIncomes", para);
            return ds;
        }
        public DataSet GetUnPaidProductIncomes()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId) };
            DataSet ds = DBHelper.ExecuteQuery("GetUnPaidProductIncomes", para);
            return ds;
        }
        public DataSet GetBoosterLedger()
        {
            SqlParameter[] para = { new SqlParameter("@FK_UserID", Fk_UserId) };
            DataSet ds = DBHelper.ExecuteQuery("BoosterLedger", para);
            return ds;
        }
        public DataSet GetBoosterAchieverForAssociate()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                   new SqlParameter("@FromDate", FromDate),
                                  new SqlParameter("@ToDate", ToDate),};
            DataSet ds = DBHelper.ExecuteQuery("GetBoosterAchieverForAssociate", para);
            return ds;
        }
        public DataSet GetPrintData()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                   new SqlParameter("@PrintingDate", PrintingDate)};
            DataSet ds = DBHelper.ExecuteQuery("GetPrintData", para);
            return ds;
        }

        public string PrintingDate { get; set; }
        //public string PlotNumber { get; set; }

        public string ProductName { get; set; }
        public string HSNCode { get; set; }
        public string Fk_FormId { get; set; }
        public string Fk_FormTypeId { get; set; }

        public DataSet GetBoosterAchieverCurrent()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),};
            DataSet ds = DBHelper.ExecuteQuery("GetBoosterAchieverCurrent", para);
            return ds;
        }
        public DataSet GetPayBoosterAchieverCurrent()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate ),
                                    new SqlParameter("@IsDownline", IsDownline),
                                    new SqlParameter("@Leg", Leg),};
            DataSet ds = DBHelper.ExecuteQuery("GetPayBoosterAchieverCurrent", para);
            return ds;
        }

        public DataSet PayBooster()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Pk_PaidBoosterId", Pk_PaidBoosterId) ,
                                      new SqlParameter("@TransactionNo", TransactionNo),
                                      new SqlParameter("@TransactionDate", TransactionDate) ,
                                      new SqlParameter("@Description", Description) ,
                                      new SqlParameter("@AddedBy", AddedBy)

                                  };
            DataSet ds = DBHelper.ExecuteQuery("PayBoosterAchiever", para);
            return ds;
        }
        #region IncomeStatement
        public DataSet FetchNextDate()
        {
            DataSet ds = DBHelper.ExecuteQuery("SelectDateForDailyIncomeNew");
            return ds;
        }
        public DataSet GenerateDailyIncomeNew()
        {
            SqlParameter[] para = { new SqlParameter("@Date", ClosingDate) };
            DataSet ds = DBHelper.ExecuteQuery("_AutoGenerateIncomeDateWise", para);
            return ds;
        }

        public string DirectIncome { get; set; }
        public DataSet GetDailyIncomeNewReport()
        {
            //SqlParameter[] para = { new SqlParameter("@Date", ClosingDate) };
            DataSet ds = DBHelper.ExecuteQuery("GetDailyIncomeReportNew");
            return ds;
        }
        public DataSet PublishDailyIncome()
        {
            SqlParameter[] para = { new SqlParameter("@PublishDate", ClosingDate),
                                      new SqlParameter("@PublishBy", Fk_UserId) };
            DataSet ds = DBHelper.ExecuteQuery("PublishDailyIncome", para);
            return ds;
        }
        public DataSet GetDailyIncomeReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId) ,
                                  new SqlParameter("@FromDate", FromDate),
                                  new SqlParameter("@ToDate", ToDate)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetDailyIncome", para);
            return ds;
        }
        #endregion
        public DataSet DailyIncomeReport()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_ToId", Fk_UserId) ,
                                    new SqlParameter("@FromDate", FromDate) ,
                                    new SqlParameter("@ToDate", ToDate) ,

                                  };
            DataSet ds = DBHelper.ExecuteQuery("DailyIncomeReportForAssociate", para);
            return ds;
        }
        public string ProductWallet { get; set; }
        public string LeadershipBonus { get; set; }
        public string RewardID { get; set; }
        public string QualifyDate { get; set; }
        public string RewardImage { get; set; }
        public string RewardName { get; set; }
        public string Contact { get; set; }
        public string PK_RewardItemId { get; set; }
        public DataSet GettingUserProfile()
        {
            SqlParameter[] para = {
                                        new SqlParameter("@LoginId", LoginId)};
            DataSet ds = DBHelper.ExecuteQuery("GetUserProfile", para);
            return ds;
        }

        public DataSet RewardList()
        {
            SqlParameter[] para = {
                                        new SqlParameter("@Fk_RewardId", RewardID),
                                        new SqlParameter("@FK_UserId", Fk_UserId)};
            DataSet ds = DBHelper.ExecuteQuery("_GetRewardData", para);
            return ds;
        }
        public DataSet ClaimReward()
        {
            SqlParameter[] para = {
                                        new SqlParameter("@Fk_RewardItemId", PK_RewardItemId),
                                        new SqlParameter("@FK_UserId", Fk_UserId),
                                        new SqlParameter("@Status", Status),
            };
            DataSet ds = DBHelper.ExecuteQuery("ClaimReward", para);
            return ds;
        }

        public DataSet GetTDSReport()
        {
            SqlParameter[] para = { new SqlParameter("@PanNumber", PAN) ,
                                  new SqlParameter("@FromDate", FromDate),
                                  new SqlParameter("@ToDate", ToDate)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetTDSReport", para);
            return ds;
        }

        public DataSet GetTDSReportByLoginID()
        {
            SqlParameter[] para = { new SqlParameter("@PanNumber", PAN) ,
                                  new SqlParameter("@FromDate", FromDate),
                                  new SqlParameter("@ToDate", ToDate),
                                  new SqlParameter("@LoginID", ToLoginID)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetTDSReportByLoginID", para);
            return ds;
        }
        public DataSet GetTransferReport()
        {
            SqlParameter[] para = { new SqlParameter("@FromLoginId", FromLoginId),
                                    new SqlParameter("@ToLoginId", ToLoginID) };
            DataSet ds = DBHelper.ExecuteQuery("GetPinTransferReport", para);
            return ds;
        }

        #region PayPayout
        public DataSet GetPayPayout()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@IsDownline", IsDownline),
                                    new SqlParameter("@Leg", Leg), };
            DataSet ds = DBHelper.ExecuteQuery("GetBalancePayoutforPayment", para);
            return ds;
        }

        public DataSet SavePayPayout()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_UserId", Fk_UserId),
                                    new SqlParameter("@TransactionNo", TransactionNo),
                                    new SqlParameter("@TransactionDate", TransactionDate),
                                    new SqlParameter("@Amount", Amount),
                                    new SqlParameter("@AddedBy", AddedBy),
                                    new SqlParameter("@BankName", BankName),
                                    new SqlParameter("@BankBranch", BankBranch),
                                    new SqlParameter("@PaymentMode", PaymentMode),
                                    new SqlParameter("@Remarks", Remarks),
            };
            DataSet ds = DBHelper.ExecuteQuery("PayPayout", para);
            return ds;
        }
        #endregion
        public DataSet PrintTopUp()
        {
            SqlParameter[] para = { new SqlParameter("@Pk_InvestmentId", ToLoginID), };
            DataSet ds = DBHelper.ExecuteQuery("PrintTopUpReport", para);
            return ds;
        }

        public DataSet AdvancePaymentReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate), };
            DataSet ds = DBHelper.ExecuteQuery("AdvancePaymentReport", para);
            return ds;
        }
        public DataSet BusinessReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
                                     new SqlParameter("@Leg", Leg),
                                    new SqlParameter("@IsDownline", IsDownline)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetBusiness", para);
            return ds;
        }
        public DataSet ProductBusinessReport()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),

                                     new SqlParameter("@Leg", Leg),
                                    new SqlParameter("@IsDownline", IsDownline),

            };
            DataSet ds = DBHelper.ExecuteQuery("GetProductBusiness", para);
            return ds;
        }
        public DataSet UserProductReward()
        {
            SqlParameter[] para = {

                                        new SqlParameter("@FK_UserId", Fk_UserId)};
            DataSet ds = DBHelper.ExecuteQuery("_GetProductRewardData", para);
            return ds;
        }
        public DataSet ClaimProductReward()
        {
            SqlParameter[] para = {
                                        new SqlParameter("@Fk_RewardItemId", PK_RewardItemId),
                                        new SqlParameter("@FK_UserId", Fk_UserId),
                                        new SqlParameter("@Status", Status),
            };
            DataSet ds = DBHelper.ExecuteQuery("ClaimProductReward", para);
            return ds;
        }

        #region productbooster
        public DataSet ProductBoosterAchieverDetails()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),};
            DataSet ds = DBHelper.ExecuteQuery("GetProductBoosterAchiever", para);
            return ds;
        }

        public DataSet GetPayProductBoosterAchiever()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate ),
                                    new SqlParameter("@IsDownline", IsDownline),
                                    new SqlParameter("@Leg", Leg),};
            DataSet ds = DBHelper.ExecuteQuery("GetPayProductBoosterAchiever", para);
            return ds;
        }
        #endregion
        public DataSet ProductRewardList()
        {

            DataSet ds = DBHelper.ExecuteQuery("RewardList");
            return ds;
        }
        public DataSet RewardListForWebsite()
        {

            DataSet ds = DBHelper.ExecuteQuery("RewardListForWebsite");
            return ds;
        }
        public DataSet RewardListForAchiever()
        {
            SqlParameter[] para = { new SqlParameter("@LoginID", LoginId),
                                    new SqlParameter("@FK_RewardId", RewardID), }
                                    ;
            DataSet ds = DBHelper.ExecuteQuery("RewardListForAchiever", para);
            return ds;
        }
        public DataSet ApprovePayment()
        {
            SqlParameter[] para = { new SqlParameter("@PKID", PK_RewardItemId),
                                    new SqlParameter("@TxnNo", TransactionNo),
                                    new SqlParameter("@TxnDate", TransactionDate),
                                    new SqlParameter("@PaidDate", PaymentDate),
                                    new SqlParameter("@AddedBy", AddedBy),


            }
                                    ;
            DataSet ds = DBHelper.ExecuteQuery("ApproveReward", para);
            return ds;
        }

        public DataSet GettingUserDetails()
        {

            DataSet ds = DBHelper.ExecuteQuery("GetEmployeeDetails");
            return ds;
        }

        public DataSet GettingUserFormPermission()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@FK_UserId", Fk_UserId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetUserFormPermission", para);
            return ds;
        }
        public DataSet GetpayoutByAmount()
        {
            SqlParameter[] para = { new SqlParameter("@LoginID", PayoutLoginId)
            };
            DataSet ds = DBHelper.ExecuteQuery("PayoutReportForAmount", para);
            return ds;
        }




        public DataSet GetDefaulterList()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", LoginId),
                                       new SqlParameter("@Status",Status),
                                        new SqlParameter("@IsDownline", IsDownline),
                                          new SqlParameter("@FromDate", FromDate),
                                      new SqlParameter("@ToDate", ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetdefaulterList", para);
            return ds;
        }


        public DataSet GetBusinessStatus()
        {
            SqlParameter[] para = {   new SqlParameter("@LoginID", LoginId),
                                      new SqlParameter("@Name", Name),
                                      new SqlParameter("@FromDate", FromDate),
                                      new SqlParameter("@ToDate", ToDate),
                                      new SqlParameter("@Package", Package),
                                      new SqlParameter("@SiteId", SiteId),
                                      new SqlParameter("@ClaculationStatus", Status),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetTopupreportForUpdateBusinessStatus", para);
            return ds;
        }
        public DataSet UpdateBusinessStatus()
        {
            SqlParameter[] para = { new SqlParameter("@PK_InvestmentId", ToLoginID),
                                    //new SqlParameter("@IsNewBusiness", IsNewBusiness),
                                    new SqlParameter("@IsInclude", IsInclude),
                                    new SqlParameter("@AddedBy", AddedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("UpdateBusinessStatus", para);
            return ds;
        }
        
        public DataSet GetRewardIncludedDetails()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
                                     new SqlParameter("@IsReward", Reward),
                                    new SqlParameter("@IsDownline", IsDownline)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetRewardIncludedDetails", para);
            return ds;
        }




        public DataSet UpdatePlotDetails()
        {
            SqlParameter[] para = {   new SqlParameter("@LoginID", LoginId),
                                      //new SqlParameter("@ToLoginId", ToLoginID),
                                      new SqlParameter("@Name", Name),
                                      new SqlParameter("@FromDate", FromDate),
                                      new SqlParameter("@ToDate", ToDate),
                                      new SqlParameter("@Package", Package),
                                      new SqlParameter("@SiteId", SiteId),
                                      new SqlParameter("@ClaculationStatus", Status),
                                      new SqlParameter("@Fk_BusinessId", BusinessType),
                                      new SqlParameter("@IsDownline", IsDownline),
                                      new SqlParameter("@Leg", Leg),
                                      new SqlParameter("@ToLoginId", TeamLoginId),
                                  };

            DataSet ds = DBHelper.ExecuteQuery("UpdatePlotDetails", para);
            return ds;
        }

        public DataSet GetBlockList()
        {
            SqlParameter[] para ={ new SqlParameter("@SiteID",SiteId),
                                     new SqlParameter("@SectorID",SectorID),
                                     new SqlParameter("@BlockID",BlockID),
                                 };
            DataSet ds = DBHelper.ExecuteQuery("GetBlockList", para);
            return ds;
        }


        public DataSet GetSiteNameFromCrmForUpdateplotDetails()
        {
            //SqlParameter[] para =
            //{
            //    new SqlParameter("@PK_SiteID",Fk_SiteId)
            //};

            //DataSet ds = DBHelper.ExecuteQuery("GetSiteNameFromCrm", para);
            DataSet ds = DBHelper.ExecuteQuery("GetSiteNameFromCrm");
            return ds;
        }



        public DataSet GetTopupReportNew()
        {
            SqlParameter[] para = {   new SqlParameter("@LoginID", LoginId),
                                      new SqlParameter("@Name", Name),
                                      //new SqlParameter("@FromDate", FromDate),
                                      //new SqlParameter("@ToDate", ToDate),
                                      new SqlParameter("@FromDate", FromDatenew),
                                      new SqlParameter("@ToDate", ToDatenew),
                                      new SqlParameter("@Package", Package),
                                      new SqlParameter("@SiteId", SiteId),
                                      new SqlParameter("@ClaculationStatus", Status),
                                      new SqlParameter("@Fk_BusinessId", BusinessType),
                                      new SqlParameter("@Fk_CompanyId", Fk_CompanyId),
                                      new SqlParameter("@IsDownline", IsDownline),
                                      new SqlParameter("@Leg", Leg),
                                      new SqlParameter("@Fk_EmployeeId", Fk_UserId)
                                  };

            DataSet ds = DBHelper.ExecuteQuery("GetTopupreportNew", para);
            return ds;
        }

        public DataSet UpdatePlotDetailsToMLM()
        {
            SqlParameter[] para =
                            {
                                new SqlParameter("@Pk_InvestmentId",PK_InvestmentID),
                                new SqlParameter("@Fk_SiteId",Fk_SiteId),
                                new SqlParameter("@Fk_SectorId",SectorID),
                                new SqlParameter("@Fk_BlockId",BlockID),
                                new SqlParameter("@PlotNumber",PlotNumber),
                                new SqlParameter("@Fk_PlotId",PlotID),
                                new SqlParameter("@UpdatedBy",UpdatedBy)
                            };
            DataSet ds = DBHelper.ExecuteQuery("UpdatePlotDetailsToMLM", para);
            return ds;
        }


        public DataSet GetRewardIncludedDetailsNew()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
                                     new SqlParameter("@IsReward", Reward),
                                    new SqlParameter("@IsDownline", IsDownline)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetRewardIncludedDetailsNew", para);
            return ds;
        }

        public DataSet BusinessReportNew()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
                                    new SqlParameter("@FromDate", FromDate),
                                    new SqlParameter("@ToDate", ToDate),
                                     new SqlParameter("@Leg", Leg),
                                    new SqlParameter("@IsDownline", IsDownline),
                                    new SqlParameter("@Fk_CompanyId", Fk_CompanyId)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetBusinessNew", para);
            return ds;
        }

        public DataSet GetCompanyList()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@FK_CompanyID", Fk_CompanyId)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetCompanyList", para);
            return ds;
        }

        public DataSet GetRankList()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@FK_RankID", FK_RankId)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetRankList", para);
            return ds;
        }

        public DataSet GetSponsorName()
        {
            SqlParameter[] para = { new SqlParameter("@LoginID", LoginId) };
            DataSet ds = DBHelper.ExecuteQuery("GetSponsorForDownlineRegistraton", para);
            return ds;
        }

      

        public DataSet SaveDownlineRegistration()
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
            DataSet ds = DBHelper.ExecuteQuery("SaveDownlineRegistration", para);
            return ds;
        }

        public DataSet GetList()
        {
            SqlParameter[] para = { new SqlParameter("@PK_UserId", UserID),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("SelectAssociate", para);
            return ds;
        }

        public DataSet GetDownMemberDetails()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", ReferBy),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetDownMemberName", para);

            return ds;
        }

        public DataSet GetAdharDetail()
        {
            SqlParameter[] para = {
                new SqlParameter("@AdharNumber", AdharNo)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetAdhar", para);
            return ds;
        }


        public DataSet GetDownlineRankAchiever()
        {
            SqlParameter[] para = {   new SqlParameter("@FK_UserId", Fk_UserId),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("DownlineRankAchieverReports", para);
            return ds;
        }


        public DataSet DownlineRankAchieverAssociateReports()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@FK_UserId", Fk_UserId),
                                      new SqlParameter("@FK_RankId", FK_RankId),
                                      new SqlParameter("@Leg", Leg),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("DownlineRankAchieverAssociateReports", para);
            return ds;
        }


        public DataSet GetDownlineListforUpdateProfile()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_UserId", Pk_UserId) };
            DataSet ds = DBHelper.ExecuteQuery("DownlineListforUpdateProfile", para);
            return ds;
        }


        public DataSet UpdateProfile()
        {

            SqlParameter[] para = {new SqlParameter("@UserId", UserID),
                                    new SqlParameter("@SponsorId", SponsorId),
                                    new SqlParameter("@LoginId", LoginIDD),
                                    new SqlParameter("@FirstName", FirstName),
                                    new SqlParameter("@LastName", LastName),
                                    //new SqlParameter("@JoiningDate", JoiningDate),
                                    new SqlParameter("@FK_ProductId", Package),
                                    //new SqlParameter("@PermanentDate", FromActivationDate),
                                    new SqlParameter("@Mobile", MobileNo),
                                    new SqlParameter("@Leg", Leg),
                                    new SqlParameter("@Status", Status),
                                    new SqlParameter("@UpdatedBy", UpdatedBy),
                                    new SqlParameter("@Email", Email),
                                    new SqlParameter("@Sex", Gender),
                                    new SqlParameter("@Address", Address),
                                    new SqlParameter("@PinCode", PinCode),
                                    new SqlParameter("@AdharNumber", AdharNo),
                                    new SqlParameter("@PanNumber", PanCard),
                                    new SqlParameter("@State", State),
                                    new SqlParameter("@City", City)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("UpdateDownlineProfile", para);
            return ds;
        }



        public DataSet GetDownlineRankAchieverForAdmin()
        {
            SqlParameter[] para = {   new SqlParameter("@LoginId", LoginId),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("DownlineRankAchieverReportsForAdmin", para);
            return ds;
        }

        public DataSet DownlineRankAchieverAdminReports()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@FK_UserId", Fk_UserId),
                                      new SqlParameter("@FK_RankId", FK_RankId),
                                      new SqlParameter("@Leg", Leg),
                                  };
            DataSet ds = DBHelper.ExecuteQuery("DownlineRankAchieverAdminReports", para);
            return ds;
        }

        public DataSet GetUser()
        {
            DataSet ds = DBHelper.ExecuteQuery("GetUserForAdmin");
            return ds;
        }



        public DataSet GetRankAchievementReports()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", LoginId),
                                       new SqlParameter("@Rank",Rank),
                                        new SqlParameter("@IsDownline", IsDownline),
                                          new SqlParameter("@FromDate", FromDate),
                                      new SqlParameter("@ToDate", ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetRankAchievementReports", para);
            return ds;
        }
    }
}

