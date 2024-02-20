using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HMGreenCityMLM.Models
{
    public class DashBoard:Common
    {

        public string PK_NoticeMasterId { get; set; }
        public string Title { get; set; }
        public string News { get; set; }
        public List<DashBoard> NoticeMasterlist { get; set; }

        public string Total { get; set; }

        public string Status { get; set; }
        public string Fk_UserId { get; set; }
        public string AchiverRank { get; set; }
        public string ImageURL { get; set; }

        public string FK_RankId { get; set; }
        public string Achiver { get; set; }


        public string TotalUsers { get; set; }
        public string ActiveUsers { get; set; }
        public string InactiveUsers { get; set; }
        public string BlockedUsers { get; set; }
        public string TotalHolds { get; set; }


        public List<DashBoard> lstachiver { get; set; }

        public DataSet GetDashBoardDetails()
        {

            DataSet ds = DBHelper.ExecuteQuery("GetDashBoardDetails");
            return ds;
        }

        public DataSet GetAssociateDashboard()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_UserId",Fk_UserId ) , };
            DataSet ds = DBHelper.ExecuteQuery("GetDashBoardDetailsForAssociate",para); 
            return ds;
        }

        public DataSet TotalRankAchieverList()
        {
            DataSet ds = DBHelper.ExecuteQuery("TotalRankAchieverList");
            return ds;
        }


        public string LoginId { get; set; }
        public string Name { get; set; }




        public List<DashBoard> lstmessages { get; set; }
        public List<DashBoard> lstyellowlst { get; set; }

        public string Pk_MessageId { get; set; }

        public string MessageTitle { get; set; }

        public string Message { get; set; }

        public DataSet GetAllMessages()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_UserId", Fk_UserId) };
            DataSet ds = DBHelper.ExecuteQuery("GetMessages", para);
            return ds;
        }

        public DataSet ListNoticeMaster()
        {
            SqlParameter[] para ={
                                     new SqlParameter("@PK_NoticeMasterId",PK_NoticeMasterId),
                                 };
            DataSet ds = DBHelper.ExecuteQuery("GetNoticeMaster", para);
            return ds;
        }


        public string cssclass { get; set; }

        public string MessageBy { get; set; }

        public DataSet SaveMessage()
        {
            SqlParameter[] para = { 
                                      new SqlParameter("@Message", Message),
                                      new SqlParameter("@AddedBy", AddedBy),
                                      new SqlParameter("@MessageBy", MessageBy),
                                      new SqlParameter("@Fk_UserId", Fk_UserId)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("InsertMessage", para);
            return ds;
        }

        public string ProfilePic { get; set; }

        public string MemberName { get; set; }

        public List<DashBoard> lstinvestment { get; set; }

        public string Amount { get; set; }

        public string ProductName { get; set; }

        public string Month { get; set; }
    }
}