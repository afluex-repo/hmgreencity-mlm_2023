using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HMGreenCityMLM.Models
{
    public class KYCDocuments
    {
        public string Status { get; set; }
        public string PKUserID { get; set; }
        public string AdharNumber { get; set; }
        public string AdharImage { get; set; }
        public string AdharBacksideImage { get; set; }
        public string AdharStatus { get; set; }
        public string PanNumber { get; set; }
        public string PanImage { get; set; }
        public string PanStatus { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentImage { get; set; }
        public string DocumentStatus { get; set; }

        public string IFSCCode { get; set; }
        public string AccountHolderName { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }


        

        public DataSet UploadKYCDocuments()
        {
            SqlParameter[] para = { new SqlParameter("@FK_UserID",PKUserID ) ,
                                      new SqlParameter("@AdharNumber", AdharNumber) ,
                                      new SqlParameter("@AdharImage", AdharImage) ,
                                      new SqlParameter("@AdharBacksideImage",AdharBacksideImage),
                                      new SqlParameter("@PanNumber", PanNumber),
                                      new SqlParameter("@PanImage", PanImage) ,
                                      new SqlParameter("@DocumentNumber", DocumentNumber) ,
                                      new SqlParameter("@DocumentImage", DocumentImage),

                                      new SqlParameter("@BankHolderName", AccountHolderName),
                                      new SqlParameter("@MemberBankName", BankName) ,
                                      new SqlParameter("@MemberBranch", BankBranch) ,
                                      new SqlParameter("@IFSCCode", IFSCCode)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("UploadKYC", para);
            return ds;
        }

        public DataSet GetKYCDocuments()
        {
            SqlParameter[] para = { new SqlParameter("@FK_UserID",PKUserID )};
            DataSet ds = DBHelper.ExecuteQuery("GetKYCDocuments", para);
            return ds;
        }

    }
}