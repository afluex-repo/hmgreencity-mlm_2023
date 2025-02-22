using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace HMGreenCityMLM.Models
{
    public class Master : Common
    {
        public string PK_NoticeMasterId { get; set; }
        public string Title { get; set; }
        public string News { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string IGST { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public string BinaryPercent { get; set; }
        public string DirectPercent { get; set; }
        public string ROIPercent { get; set; }
        public List<Master> lstproduct { get; set; }
        public string UserType { get; set; }
        public string Url { get; set; }

        public string NewsID { get; set; }
        public string NewsHeading { get; set; }
        public string NewsBody { get; set; }
        public string NewsDate { get; set; }
        public string BV { get; set; }
        public List<Master> lstNews { get; set; }

        public string SiteName { get; set; }
        public string SiteTypeID { get; set; }
        public string Rate { get; set; }
        public string UnitID { get; set; }
        public string Location { get; set; }
        public string PLCName { get; set; }
        public string PLCCharge { get; set; }
        public string PLCID { get; set; }
        public string DevelopmentCharge { get; set; }
        public string SiteID { get; set; }
        public string EncryptKey { get; set; }
        public string UnitName { get; set; }
        public string SiteTypeName { get; set; }
        public DataTable dtPLCCharge { get; set; }

        public List<Master> lstPLC { get; set; }
        public List<Master> lstSite { get; set; }

        public string SectorName { get; set; }
        public string SectorID { get; set; }
        public List<Master> lstSector { get; set; }
        public List<Master> NoticeMasterlist { get; set; }
        public List<SelectListItem> ddlSector { get; set; }
        public List<SelectListItem> lstBlock { get; set; }





        public string BlockID { get; set; }
        public string BlockName { get; set; }
        public List<Master> lstBlock1 { get; set; }
        public string Status { get; set; }
        public string BookingPercent { get; set; }
        public string AllottmentPercent { get; set; }
        public string PlotStatus { get; set; }
        public string PlotSize { get; set; }
        public string TotalArea { get; set; }


        public string PlotAmount { get; set; }
        public string StatusColor { get; set; }

        public string PlotID { get; set; }

        public string PlotRate { get; set; }
        public string PK_InvestmentID { get; set; }

        
        public string LoginId { get; set; }

        #region ProductMaster

        public DataSet SaveProduct()
        {
            SqlParameter[] para = { new SqlParameter("@ProductName", ProductName),
                                  new SqlParameter("@ProductPrice", ProductPrice),
                                  new SqlParameter("@IGST", IGST),
                                  new SqlParameter("@CGST", CGST),
                                  new SqlParameter("@SGST", SGST),
                                  new SqlParameter("@BinaryPercent", BinaryPercent),
                                  new SqlParameter("@DirectPercent", DirectPercent),
                                  new SqlParameter("@ROIPercent", ROIPercent),
                                  new SqlParameter("@BV",BV),
                                  new SqlParameter("@AddedBy", AddedBy)};

            DataSet ds = DBHelper.ExecuteQuery("AddProduct", para);
            return ds;
        }

        public DataSet ProductList()
        {
            SqlParameter[] para = { new SqlParameter("@ProductID", ProductID) };
            DataSet ds = DBHelper.ExecuteQuery("GetProductList", para);
            return ds;
        }

        public DataSet DeleteProduct()
        {
            SqlParameter[] para = { new SqlParameter("@ProductID", ProductID),
                                  new SqlParameter("@DeletedBy", AddedBy),};

            DataSet ds = DBHelper.ExecuteQuery("DeleteProduct", para);
            return ds;
        }

        public DataSet UpdateProduct()
        {
            SqlParameter[] para = { new SqlParameter("@ProductID", ProductID),
                                  new SqlParameter("@ProductName", ProductName),
                                  new SqlParameter("@ProductPrice", ProductPrice),
                                  new SqlParameter("@IGST", IGST),
                                  new SqlParameter("@CGST", CGST),
                                  new SqlParameter("@SGST", SGST),
                                  new SqlParameter("@BinaryPercent", BinaryPercent),
                                  new SqlParameter("@DirectPercent", DirectPercent),
                                  new SqlParameter("@ROIPercent", ROIPercent),
                                  new SqlParameter("@BV", BV),
                                  new SqlParameter("@UpdatedBy", UpdatedBy)};

            DataSet ds = DBHelper.ExecuteQuery("UpdateProduct", para);
            return ds;
        }

        #endregion

        #region NewsMaster

        public DataSet SaveNews()
        {
            SqlParameter[] para = { new SqlParameter("@NewsHeading", NewsHeading),
                                  new SqlParameter("@NewsBody", NewsBody),
                                  new SqlParameter("@AddedBy", AddedBy)};

            DataSet ds = DBHelper.ExecuteQuery("AddNews", para);
            return ds;
        }

        public DataSet NewsList()
        {
            SqlParameter[] para = { new SqlParameter("@NewsID", NewsID) };
            DataSet ds = DBHelper.ExecuteQuery("NewsList", para);
            return ds;
        }

        public DataSet UpdateNews()
        {
            SqlParameter[] para = { new SqlParameter("@NewsID", NewsID),
                                  new SqlParameter("@NewsHeading", NewsHeading),
                                  new SqlParameter("@NewsBody", NewsBody),
                                  new SqlParameter("@UpdatedBy", UpdatedBy) };

            DataSet ds = DBHelper.ExecuteQuery("UpdateNews", para);
            return ds;
        }

        public DataSet DeleteNews()
        {
            SqlParameter[] para = { new SqlParameter("@NewsID", NewsID),
                                  new SqlParameter("@DeletedBy", AddedBy),};

            DataSet ds = DBHelper.ExecuteQuery("DeleteNews", para);
            return ds;
        }

        #endregion

        #region Site

        public DataSet GetUnitList()
        {
            DataSet ds = DBHelper.ExecuteQuery("GetUnitList");
            return ds;
        }

        public DataSet GetSiteTypeList()
        {

            DataSet ds = DBHelper.ExecuteQuery("SiteTypeList");
            return ds;
        }

        public DataSet GetSiteList()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@PK_SiteID",SiteID)
            };

            DataSet ds = DBHelper.ExecuteQuery("GetSiteName", para);
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




        public DataSet GetSelectSectorFromCrm()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FK_SiteID",Fk_SiteId)
            };

            DataSet ds = DBHelper.ExecuteQuery("SelectSectorFromCrm", para);
            return ds;
        }



        public DataSet GetSelectSectorFromCrmForRetopup()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FK_SiteID",Fk_SiteId)
            };

            DataSet ds = DBHelper.ExecuteQuery("SelectSectorFromCrm", para);
            return ds;
        }




        public DataSet GetSitePlcChargeList()
        {
            SqlParameter[] para = { new SqlParameter("@SiteID", SiteID) };
            DataSet ds = DBHelper.ExecuteQuery("SitePlcChargeList", para);
            return ds;
        }

        public DataSet PLCList()
        {
            DataSet ds = DBHelper.ExecuteQuery("PLCList");
            return ds;
        }

        public DataSet SaveSite()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@SiteName", SiteName),
                                      new SqlParameter("@Location", Location),
                                      new SqlParameter("@AddedBy", AddedBy)

            };
            DataSet ds = DBHelper.ExecuteQuery("SiteMaster", para);
            return ds;
        }

        public DataSet SaveNoticeMaster()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Title", Title),
                                      new SqlParameter("@News", News),
                                      new SqlParameter("@AddedBy", AddedBy)

            };
            DataSet ds = DBHelper.ExecuteQuery("SaveNoticeMaster", para);
            return ds;
        }

        public DataSet UpdateSite()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@SiteName", SiteName),
                                      new SqlParameter("@Location", Location),
                                      new SqlParameter("@UpdatedBy", UpdatedBy),

                                      new SqlParameter("@SiteID", SiteID)

            };
            DataSet ds = DBHelper.ExecuteQuery("UpdateSite", para);
            return ds;
        }

        public DataSet UpdateNotice()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Title", Title),
                                      new SqlParameter("@News", News),
                                      new SqlParameter("@UpdatedBy", UpdatedBy),

                                      new SqlParameter("@PK_NoticeMasterId", PK_NoticeMasterId)

            };
            DataSet ds = DBHelper.ExecuteQuery("UpdateNotice", para);
            return ds;
        }

        public DataSet DeleteSite()
        {
            SqlParameter[] para = { new SqlParameter("@SiteID", SiteID),
                                  new SqlParameter("@DeletedBy", UpdatedBy) };
            DataSet ds = DBHelper.ExecuteQuery("DeleteSite", para);
            return ds;
        }

        public DataSet DeleteNotice()
        {
            SqlParameter[] para = { new SqlParameter("@PK_NoticeMasterId", PK_NoticeMasterId),
                                  new SqlParameter("@DeletedBy", UpdatedBy) };
            DataSet ds = DBHelper.ExecuteQuery("DeleteNotice", para);
            return ds;
        }




        public DataSet GetSectorList()
        {
            SqlParameter[] para = { new SqlParameter("@SiteID", SiteID) };
            DataSet ds = DBHelper.ExecuteQuery("GetSectorList", para);
            return ds;
        }








        public DataSet GetPLCChargeList()
        {
            SqlParameter[] para = { new SqlParameter("@FK_SiteID", SiteID) };
            DataSet ds = DBHelper.ExecuteQuery("GetPlotPLCCharge", para);
            return ds;

        }

        #endregion

        #region  Sector

        public DataSet SaveSector()
        {
            SqlParameter[] para =
                            {

                                new SqlParameter("@FK_SiteID",SiteID),
                                new SqlParameter("@SectorName",SectorName),
                                new SqlParameter("@AddedBy",AddedBy)

                            };
            DataSet ds = DBHelper.ExecuteQuery("SectorMaster", para);
            return ds;
        }


        public DataSet UpdateSector()
        {
            SqlParameter[] para =
                            {
                                new SqlParameter("@PK_SectorID",SectorID),
                                new SqlParameter("@FK_SiteID",SiteID),
                                new SqlParameter("@SectorName",SectorName),
                                new SqlParameter("@UpdatedBy",UpdatedBy)

                            };
            DataSet ds = DBHelper.ExecuteQuery("UpdateSector", para);
            return ds;
        }

        public DataSet GetSector()
        {
            SqlParameter[] para =
             {
                                new SqlParameter("@PK_SectorID",SectorID)

                            };
            DataSet ds = DBHelper.ExecuteQuery("SelectSector", para);
            return ds;
        }



        public DataSet SelectSectorFromCrm()
        {
            SqlParameter[] para =
             {
                                new SqlParameter("@FK_SiteID",SectorID)

                            };
            DataSet ds = DBHelper.ExecuteQuery("SelectSectorFromCrm", para);
            return ds;
        }


        public DataSet DeleteSector()
        {
            SqlParameter[] para = { new SqlParameter("@PK_SectorID", SectorID),
                                  new SqlParameter("@DeletedBy", UpdatedBy) };
            DataSet ds = DBHelper.ExecuteQuery("DeleteSector", para);
            return ds;
        }

        #endregion

        #region BlockMaster

        public DataSet DeleteBlock()
        {
            SqlParameter[] para = { new SqlParameter("@PK_BlockID", BlockID),
                                  new SqlParameter("@DeletedBy", UpdatedBy) };
            DataSet ds = DBHelper.ExecuteQuery("DeleteBlock", para);
            return ds;
        }


        public DataSet SaveBlock()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@FK_SiteID", SiteID),
                                      new SqlParameter("@BlockName", BlockName),
                                      new SqlParameter("@FK_SectorID", SectorID),
                                      new SqlParameter("@AddedBy", AddedBy)

                                  };
            DataSet ds = DBHelper.ExecuteQuery("BlockMaster", para);
            return ds;
        }

        public DataSet UpdateBlock()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@PK_BlockID", BlockID),
                                      new SqlParameter("@FK_SiteID ", SiteID ),
                                      new SqlParameter("@FK_SectorID", SectorID),
                                        new SqlParameter("@BlockName", BlockName),
                                      new SqlParameter("@UpdatedBy", UpdatedBy)

                                  };
            DataSet ds = DBHelper.ExecuteQuery("UpdateBlockMaster", para);
            return ds;
        }

        public DataSet GetBlockList()
        {
            SqlParameter[] para ={ new SqlParameter("@SiteID",SiteID),
                                     new SqlParameter("@SectorID",SectorID),
                                     new SqlParameter("@BlockID",BlockID),
                                 };
            DataSet ds = DBHelper.ExecuteQuery("GetBlockList", para);
            return ds;
        }


        public DataSet GetBlockListFromCrm()
        {
            SqlParameter[] para ={ new SqlParameter("@SiteID",Fk_SiteId),
                                     new SqlParameter("@SectorID",FK_SectorId),
                                     new SqlParameter("@BlockID",Fk_BlockId),
                                 };
            DataSet ds = DBHelper.ExecuteQuery("GetBlockListFromCrm", para);
            return ds;
        }



        public DataSet GetBlockListFromCrmupdatePlot()
        {
            SqlParameter[] para ={ new SqlParameter("@SiteID",Fk_SiteId),
                                     new SqlParameter("@SectorID",SectorID),
                                     new SqlParameter("@BlockID",BlockID),
                                 };
            DataSet ds = DBHelper.ExecuteQuery("GetBlockListFromCrm", para);
            return ds;
        }




        public DataSet GetBlockListFromCrmForRetopup()
        {
            SqlParameter[] para ={ new SqlParameter("@SiteID",Fk_SiteId),
                                     new SqlParameter("@SectorID",FK_SectorId),
                                     new SqlParameter("@BlockID",Fk_BlockId),
                                 };
            DataSet ds = DBHelper.ExecuteQuery("GetBlockListFromCrm", para);
            return ds;
        }








        public DataSet PlotListfromCRM()
        {
            SqlParameter[] para ={ new SqlParameter("@SiteID",SiteID),
                                     new SqlParameter("@SectorID",SectorID),
                                     new SqlParameter("@BlockID",BlockID),
                                      new SqlParameter("@PlotNumber",PlotNumber),
                                     new SqlParameter("@Status",Status),
                                 };
            DataSet ds = DBHelper.ExecuteQuery("PlotListfromCRM", para);
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

        #endregion


        public DataSet CheckPlotAvailibility()
        {
            SqlParameter[] para =
                            {
                                new SqlParameter("@SiteID",Fk_SiteId),
                                new SqlParameter("@SectorID",FK_SectorId),
                                new SqlParameter("@BlockID",Fk_BlockId),
                                new SqlParameter("@PlotNumber",PlotNumber)
                            };
            DataSet ds = DBHelper.ExecuteQuery("GetPlotStatus", para);
            return ds;
        }

        public DataSet CheckPlotAvailibilityForUpdatePlot()
        {
            SqlParameter[] para =
                            {
                                new SqlParameter("@SiteID",Fk_SiteId),
                                new SqlParameter("@SectorID",SectorID),
                                new SqlParameter("@BlockID",BlockID),
                                new SqlParameter("@PlotNumber",PlotNumber)
                            };
            DataSet ds = DBHelper.ExecuteQuery("GetPlotStatus", para);
            return ds;
        }
        
        public DataSet CheckPlotAvailibilityForRetopup()
        {
            SqlParameter[] para =
                            {
                                new SqlParameter("@SiteID",Fk_SiteId),
                                new SqlParameter("@SectorID",FK_SectorId),
                                new SqlParameter("@BlockID",Fk_BlockId),
                                new SqlParameter("@PlotNumber",PlotNumber)
                            };
            DataSet ds = DBHelper.ExecuteQuery("GetPlotStatus", para);
            return ds;
        }


        public string Fk_SiteId { get; set; }
        public string FK_SectorId { get; set; }
        public string Fk_BlockId { get; set; }


        //public DataSet UpdatePlotDetailsToMLM()
        //{
        //    SqlParameter[] para =
        //                    {
        //                        new SqlParameter("@Pk_InvestmentId",PK_InvestmentID),
        //                        new SqlParameter("@Fk_SiteId",Fk_SiteId),
        //                        new SqlParameter("@Fk_SectorId",SectorID),
        //                        new SqlParameter("@Fk_BlockId",BlockID),
        //                        new SqlParameter("@PlotNumber",PlotNumber),
        //                        new SqlParameter("@Fk_PlotId",PlotID),
        //                        new SqlParameter("@UpdatedBy",UpdatedBy)
        //                    };
        //    DataSet ds = DBHelper.ExecuteQuery("UpdatePlotDetailsToMLM", para);
        //    return ds;
        //}

        public DataSet GetMenuPermissionList()
        {
            SqlParameter[] para = { new SqlParameter("@PK_AdminId", Fk_UserId),
                                    new SqlParameter("@UserType", UserType),
                                    new SqlParameter("@URL",Url)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetMenuListForUser", para);
            return ds;
        }


        //public DataSet CheckPlotForRetopupForLoginId()
        //{
        //    SqlParameter[] para =
        //                    {
        //                        new SqlParameter("@LoginId",LoginId),
        //                        new SqlParameter("@Fk_SiteID",Fk_SiteId),
        //                        new SqlParameter("@Fk_SectorId",FK_SectorId),
        //                        new SqlParameter("@Fk_BlockID",Fk_BlockId),
        //                        new SqlParameter("@PlotNumber",PlotNumber)
        //                    };
        //    DataSet ds = DBHelper.ExecuteQuery("GetPlotStatus", para);
        //    return ds;
        //}

    }
}