using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMGreenCityMLM.Models
{
    public class Common
    {
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ReferBy { get; set; }
        public string Result { get; set; }
        public string Msg { get; set; }
        public string DisplayName { get; set; }
        public string AddedOn { get; set; }
        public string SectorID { get; set; }
        public string BlockID { get; set; }
        public string PlotNumber { get; set; }
        //public string SiteID { get; set; }
        public string Fk_SiteId { get; set; }
        public string Fk_UserId { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Amount { get; set; }

        public string ReceiptNo { get; set; }


        public string PK_InvestmentID { get; set; }
        public string PlotID { get; set; }

        public static string GenerateRandom()
        {
            Random r = new Random();
            string s = "";
            for (int i = 0; i < 6; i++)
            {
                s = string.Concat(s, r.Next(10).ToString());
            }
            return s;
        }

        public static string ConvertToSystemDateTime(string InputDate, string InputFormat)
        {
            if (string.IsNullOrWhiteSpace(InputDate))
                throw new Exception("Input date is null or empty");

            DateTime parsedDate;

            // List of acceptable formats
            string[] formats = new[]
            {
        "dd/MM/yyyy HH:mm:ss",
        "dd/MM/yyyy HH:mm",
        "MM/dd/yyyy HH:mm:ss",
        "MM/dd/yyyy HH:mm",
        "yyyy-MM-ddTHH:mm:ss",
        "yyyy-MM-ddTHH:mm"
    };

            try
            {
                // Try parsing the date using all formats
                parsedDate = DateTime.ParseExact(InputDate, formats,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None);
            }
            catch (FormatException)
            {
                throw new Exception("Invalid Date or Time format");
            }

            // Return date/time in standard SQL-friendly format: MM/dd/yyyy HH:mm:ss
            return parsedDate.ToString("dd/MM/yyyy HH:mm:ss");
        }



        public static string ConvertToSystemDate(string InputDate, string InputFormat)
        {
            string DateString = "";
            DateTime Dt;

            string[] DatePart = (InputDate).Split(new string[] { "-", @"/" }, StringSplitOptions.None);

            if (InputFormat == "dd-MMM-yyyy" || InputFormat == "dd/MMM/yyyy" || InputFormat == "dd/MM/yyyy" || InputFormat == "dd-MM-yyyy" || InputFormat == "DD/MM/YYYY" || InputFormat == "dd/mm/yyyy")
            {
                string Day = DatePart[0];
                string Month = DatePart[1];
                string Year = DatePart[2];

                if (Month.Length > 2)
                    DateString = InputDate;
                else
                    DateString = Month + "/" + Day + "/" + Year;
            }
            else if (InputFormat == "MM/dd/yyyy" || InputFormat == "MM-dd-yyyy")
            {
                DateString = InputDate;
            }
            else
            {
                throw new Exception("Invalid Date");
            }

            try
            {
                //Dt = DateTime.Parse(DateString);
                //return Dt.ToString("MM/dd/yyyy");
                return DateString;
            }
            catch
            {
                throw new Exception("Invalid Date");
            }

        }
        public DataSet BindUserTypeForRegistration()
        {

            DataSet ds = DBHelper.ExecuteQuery("GetUserTypeForRegistration");

            return ds;

        }
        public DataSet BindFormMaster()
        {
            SqlParameter[] para = { new SqlParameter("@Parameter", 4) };
            DataSet ds = DBHelper.ExecuteQuery("FormMasterManage", para);

            return ds;

        }
        public DataSet BindFormTypeMaster()
        {
            SqlParameter[] para = { new SqlParameter("@Parameter", 4) };
            DataSet ds = DBHelper.ExecuteQuery("FormTypeMasterManage", para);

            return ds;

        }
        #region Form Permissions By User
        public DataSet FormPermissions(string FormName, string AdminId)
        {
            try
            {
                SqlParameter[] para = {
                                          new SqlParameter("@FormName", FormName) ,
                                          new SqlParameter("@AdminId", AdminId)
                                      };

                DataSet ds = DBHelper.ExecuteQuery("PermissionsOfForm", para);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        public DataSet GetMemberDetails()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", ReferBy),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetMemberName", para);

            return ds;
        }

        public DataSet GetMemberDetailsForTopup()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", ReferBy),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetMemberNameForTopUp", para);

            return ds;
        }
        public DataSet GetSite()
        {
            DataSet ds = DBHelper.ExecuteQuery("GetSiteName");

            return ds;
        }

        public DataSet GetMemberDetailsForIncome()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LoginId", ReferBy),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetMemberNameForHourlyIncome", para);

            return ds;
        }

        public DataSet GetSiteNameFromCrm()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@PK_SiteID",Fk_SiteId)
            };

            DataSet ds = DBHelper.ExecuteQuery("GetSiteNameFromCrm", para);
            return ds;
        }


        public DataSet GetSiteNameFromCrmForRetopup()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@PK_SiteID",Fk_SiteId)
            };

            DataSet ds = DBHelper.ExecuteQuery("GetSiteNameFromCrm", para);
            return ds;
        }


        public DataSet GetMemberDetailsForSale()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", ReferBy), };
            DataSet ds = DBHelper.ExecuteQuery("GetMemberNameForSale", para);
            return ds;
        }
        public DataSet GetMemberDetailsForFranchiseSale()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", ReferBy), };
            DataSet ds = DBHelper.ExecuteQuery("GetMemberDetailsForFranchiseSale", para);
            return ds;
        }
        public DataSet BindProduct()
        {
            DataSet ds = DBHelper.ExecuteQuery("GetProductList");
            return ds;
        }

        public DataSet BindProductForFranchisee()
        {
            DataSet ds = DBHelper.ExecuteQuery("GetProductListForFranchisee");
            return ds;
        }
        public DataSet BindFranchiseType()
        {
            DataSet ds = DBHelper.ExecuteQuery("GetFranchiseType");
            return ds;
        }
        public static List<SelectListItem> BindPaymentMode()
        {
            List<SelectListItem> PaymentMode = new List<SelectListItem>();
            PaymentMode.Add(new SelectListItem { Text = "Select Payment Mode", Value = "0" });
            PaymentMode.Add(new SelectListItem { Text = "Cash", Value = "Cash" });
            PaymentMode.Add(new SelectListItem { Text = "Cheque", Value = "Cheque" });
            PaymentMode.Add(new SelectListItem { Text = "NEFT", Value = "NEFT" });
            PaymentMode.Add(new SelectListItem { Text = "RTGS", Value = "RTGS" });
            PaymentMode.Add(new SelectListItem { Text = "Demand Draft", Value = "DD" });
            PaymentMode.Add(new SelectListItem { Text = "IMPS", Value = "IMPS" });
            PaymentMode.Add(new SelectListItem { Text = "UPI", Value = "UPI" });
            return PaymentMode;
        }
        public static List<SelectListItem> BindPaymentModeForList()
        {
            List<SelectListItem> PaymentMode = new List<SelectListItem>();
            PaymentMode.Add(new SelectListItem { Text = "All", Value = null });
            PaymentMode.Add(new SelectListItem { Text = "Cash", Value = "Cash" });
            PaymentMode.Add(new SelectListItem { Text = "Supplier", Value = "Supplier" });


            return PaymentMode;
        }

        public static List<SelectListItem> BindGender()
        {
            List<SelectListItem> Gender = new List<SelectListItem>();
            Gender.Add(new SelectListItem { Text = "Male", Value = "M" });
            Gender.Add(new SelectListItem { Text = "Female", Value = "F" });

            return Gender;
        }
        public static List<SelectListItem> BindPasswordType()
        {
            List<SelectListItem> PasswordType = new List<SelectListItem>();
            PasswordType.Add(new SelectListItem { Text = "Select", Value = "0" });
            PasswordType.Add(new SelectListItem { Text = "Profile Password", Value = "P" });
            PasswordType.Add(new SelectListItem { Text = "Transaction Password", Value = "T" });

            return PasswordType;
        }
        public static List<SelectListItem> TransactionType()
        {
            List<SelectListItem> TransactionType = new List<SelectListItem>();
            TransactionType.Add(new SelectListItem { Text = "Select", Value = "0" });
            TransactionType.Add(new SelectListItem { Text = "Credit", Value = "Credit" });
            TransactionType.Add(new SelectListItem { Text = "Debit", Value = "Debit" });

            return TransactionType;
        }
        public static List<SelectListItem> BindKYCStatus()
        {
            List<SelectListItem> PasswordType = new List<SelectListItem>();
            PasswordType.Add(new SelectListItem { Text = "Select", Value = "0" });
            PasswordType.Add(new SelectListItem { Text = "Not Uploaded", Value = "N" });
            PasswordType.Add(new SelectListItem { Text = "Pending", Value = "P" });
            PasswordType.Add(new SelectListItem { Text = "Approved", Value = "A" });

            return PasswordType;
        }
        public static List<SelectListItem> AssociateStatus()
        {
            List<SelectListItem> AssociateStatus = new List<SelectListItem>();
            AssociateStatus.Add(new SelectListItem { Text = "All", Value = null });
            AssociateStatus.Add(new SelectListItem { Text = "Active", Value = "P" });
            AssociateStatus.Add(new SelectListItem { Text = "Inactive", Value = "T" });
            AssociateStatus.Add(new SelectListItem { Text = "Blocked", Value = "B" });
            AssociateStatus.Add(new SelectListItem { Text = "Yellow", Value = "H" });
            return AssociateStatus;
        }
        public static List<SelectListItem> Leg()
        {
            List<SelectListItem> Leg = new List<SelectListItem>();
            Leg.Add(new SelectListItem { Text = "All", Value = null });
            Leg.Add(new SelectListItem { Text = "Left", Value = "L" });
            Leg.Add(new SelectListItem { Text = "Right", Value = "R" });

            return Leg;
        }


        public static List<SelectListItem> BindTopupStatus()
        {
            List<SelectListItem> IncomeStatus = new List<SelectListItem>();
            IncomeStatus.Add(new SelectListItem { Text = "All", Value = null });
            IncomeStatus.Add(new SelectListItem { Text = "Calculated", Value = "1" });
            IncomeStatus.Add(new SelectListItem { Text = "Pending", Value = "0" });

            return IncomeStatus;
        }

        public static List<SelectListItem> RankIncome()
        {
            List<SelectListItem> RankIncome = new List<SelectListItem>();
            RankIncome.Add(new SelectListItem { Text = "All", Value = null });
            RankIncome.Add(new SelectListItem { Text = "Star (25000/-)", Value = "1" });
            RankIncome.Add(new SelectListItem { Text = "Silver (50000/-)", Value = "2" });
            RankIncome.Add(new SelectListItem { Text = "Gold (150000/-)", Value = "3" });

            return RankIncome;
        }

        public static List<SelectListItem> BindRealation()
        {
            List<SelectListItem> PaymentMode = new List<SelectListItem>();
            PaymentMode.Add(new SelectListItem { Text = "S/O", Value = "S/O" });
            PaymentMode.Add(new SelectListItem { Text = "D/O", Value = "D/O" });
            PaymentMode.Add(new SelectListItem { Text = "W/O", Value = "W/O" });

            return PaymentMode;
        }
        public static List<SelectListItem> PaidStatus()
        {
            List<SelectListItem> PaidStatus = new List<SelectListItem>();
            PaidStatus.Add(new SelectListItem { Text = "All", Value = "null" });
            PaidStatus.Add(new SelectListItem { Text = "Paid", Value = "1" });
            PaidStatus.Add(new SelectListItem { Text = "Unpaid", Value = "0" });

            return PaidStatus;
        }


        public DataSet GetStateCity()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@PinCode", PinCode),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("GetStateCity", para);

            return ds;
        }
        public int GenerateRandomNo()
        {
            int _min = 0000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        public DataSet CheckReceiptNo()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@ReceiptNo", ReceiptNo),

                                  };
            DataSet ds = DBHelper.ExecuteQuery("CheckReceiptNo", para);

            return ds;
        }
    }

    public class SMSCredential
    {
        public static string UserName = "";
        public static string Password = "";
        public static string SenderId = "";
    }

    public class SoftwareDetails
    {
        public static string CompanyName = "HM GROUP OF COMPANY";
        public static string CompanyAddress = "H.O. : 8/883/2, Vikas Nagar, khurram Nagar Road, Opp, Fatimi Masjid, Lucknow";
        public static string Pin1 = "";
        public static string State1 = "UP";
        public static string City1 = "Lucknow";
        public static string ContactNo = "";
        public static string LandLine = "0522 430 1189";
        public static string Website = "";
        public static string EmailID = "hmcity7374@gmail.com";
    }

}