using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HMGreenCityMLM.Models
{
    public class Permisssions
    {
        public string Fk_UserTypeId { get; set; }
        public string Fk_UserId { get; set; }
        public string Fk_FormTypeId { get; set; }
        public string Fk_FormId { get; set; }
        public string FormView { get; set; }
        public string FormSave { get; set; }
        public string FormUpdate { get; set; }
        public string FormDelete { get; set; }
        public string FormName { get; set; }
        public string LoginId { get; set; }
        public string ToLoginID { get; set; }
        public string EmployeeLoginId { get; set; }
        public string SevenDayView { get; set; }

        
        public bool IsSaveValue { get; set; }
        public bool IsUpdateValue { get; set; }
        public bool IsSelectValue { get; set; }
        public bool IsDeleteValue { get; set; }
        public bool IsSevenDayView { get; set; }
        
        public string SelectedValue { get; set; }
        public string CreatedBy { get; set; }
        public DataTable UserTypeFormPermisssion { get; set; }
        public string EmployeeId { get; set; }

        public List<SetMain> LstSetMain { get; set; }

        public List<Permisssions> lstpermission = new List<Permisssions>();

        public DataSet GetFormPermission()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@fk_userid", Fk_UserId),
                                      new SqlParameter("@Pk_FormTypeId", Fk_FormTypeId) };
            DataSet ds = DBHelper.ExecuteQuery("GetPemissionData", para);
            return ds;
        }
        public DataSet SavePermisssion()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@UserTypeFormPermisssion", UserTypeFormPermisssion),
                                      new SqlParameter("@CreatedBy", CreatedBy),
                                      new SqlParameter("@Fk_UserId", Fk_UserId),
                                      new SqlParameter("@Fk_FormTypeId", Fk_FormTypeId)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("SetFormPermission", para);
            return ds;
        }
        public DataSet SetMainid()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_EmployeeId", EmployeeId),
                                      new SqlParameter("@UserLoginId", ToLoginID),
                                      new SqlParameter("@AddedBy", CreatedBy)
                                  };
            DataSet ds = DBHelper.ExecuteQuery("SetMainid", para);
            return ds;
        }

        public DataSet GetEmployeeAssociateSettings()
        {
            //SqlParameter[] para = { };
            DataSet ds = DBHelper.ExecuteQuery("GetEmployeeAssociateSettings");
            return ds;
        }
        public DataSet GetMainId()
        {
            SqlParameter[] para = {
             new SqlParameter("@Fk_EmployeeId", EmployeeId)};
            DataSet ds = DBHelper.ExecuteQuery("GetMainId", para);
            return ds;
        }
    }

    public class SetMain
    {
        public int Pk_MainId { get; set; }
        public int Fk_UserId { get; set; }
        public int Fk_EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string LoginId { get; set; }
        public string UserName { get; set; }
    }
}