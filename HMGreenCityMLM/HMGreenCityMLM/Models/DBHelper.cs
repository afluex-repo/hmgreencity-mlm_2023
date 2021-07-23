﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMGreenCityMLM.Models
{
    public class DBHelper
    {
        public static string connectionString = string.Empty;

        static DBHelper()
        {
            try
            {
                //connectionString = "Data Source=103.48.51.111,1232;Initial Catalog=hmgreendb;User Id=hmgreenuser; Password=W1ttl1&9; Integrated Security=false;";
                connectionString = "Data Source=164.52.211.92,1232;Initial Catalog=hmgreendb;User Id=hmgreenusernew; Password=W1ttl1&9; Integrated Security=false;";
                //connectionString = "Data Source=DESKTOP-KPDI8EN\\AFLUEX;Initial Catalog=HMGreenCityMLM;User Id=sa;Password=123;Integrated Security=false;";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ExecuteNonQuery(string commandText, params SqlParameter[] commandParameters)
        {
            int k = 0;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(commandParameters);
                    connection.Open();
                    k = command.ExecuteNonQuery();
                }
                return k;
            }
            catch
            {
                return k;
            }
        }

        public static DataSet ExecuteQuery(string commandText, params SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(ds);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Msg");
                dt.Columns.Add("ErrorMessage");

                DataRow dr = dt.NewRow();
                dr["Msg"] = "0";
                dr["ErrorMessage"] = ex.Message;
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);

            }
            return ds;
        }
    }
}



