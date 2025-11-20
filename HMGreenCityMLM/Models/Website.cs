using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HMGreenCityMLM.Models
{
    public class Website : Common
    {


        public DataSet UpdateRankforJob()
        {
            DataSet ds = DBHelper.ExecuteQuery("UpdateRank");
            return ds;
        }

        public DataSet UpdateHoldStatusforJob()
        {
            DataSet ds = DBHelper.ExecuteQuery("UpdateHoldIdStatus");
            return ds;
        }

        public DataSet UpdateCounterHoldActiveforJob()
        {
            DataSet ds = DBHelper.ExecuteQuery("UpdateCounterHoldActive");
            return ds;
        }

        public DataSet RankwiseHourlyIncome()
        {
            DataSet ds = DBHelper.ExecuteQuery("CheckUserRankDuration");
            return ds;
        }
    }
}