using HMGreenCityMLM.Models;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace HMGreenCityMLM.Controllers
{
    public class ImageUploadController : Controller
    {

        public ActionResult UpdateProfile(Upload model)
        {
            Response obj = new Response();
            try
            {
                if (model.ImageURL != null)
                {
                    string timeStamp = DateTime.Now.ToString("yyMMddHHmmssfff");
                    //model.ProfilePic = model.ProfilePic.Replace('-', '+').Replace('%','/').Replace('_', '/').PadRight(4*((model.ProfilePic.Length+3)/4), '=');


                    string pattern = @".*,";
                    string substitution = @"";

                    Regex regex = new Regex(pattern, RegexOptions.Multiline);
                    string result = regex.Replace(model.ImageURL, substitution);

                    byte[] bytes = Convert.FromBase64String(result);
                    string dirFullPath = System.Web.HttpContext.Current.Server.MapPath("~/ProfilePicture/");
                    int fCount = Directory.GetFiles(dirFullPath, "*", SearchOption.AllDirectories).Length;
                    string filePath = dirFullPath + timeStamp + "img" + fCount + ".png";
                    System.IO.File.WriteAllBytes(filePath, bytes);

                    string rep = Regex.Replace(dirFullPath, @"[\\,]+", "/");
                    string cleanString = rep.Remove(0, 55);
                  

                    model.ImageURL = cleanString + timeStamp + "img" + fCount + ".png";
                }
                else
                {
                    model.ImageURL = "";
                }
                DataSet dsResult = model.UpdateImage();
                if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
                {
                    if (dsResult.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        obj.Status = "0";
                        obj.SuccessMessage = "Image Upload Successfully.";

                    }
                    else
                    {
                        obj.Status = "1";
                        obj.ErrorMessage = dsResult.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    obj.Status = "1";
                    obj.ErrorMessage = "Some Error Occured.";
                }
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                obj.Status = "1";
                obj.ErrorMessage = ex.Message;
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UploadKYCDetails(UploadKYC model)
        {
            Response obj = new Response();
            try
            {
                if (model.AdharImage != null && model.PanImage !=null && model.DocImage!=null)
                {
                    string timeStamp = DateTime.Now.ToString("yyMMddHHmmssfff");
                    //model.ProfilePic = model.ProfilePic.Replace('-', '+').Replace('%','/').Replace('_', '/').PadRight(4*((model.ProfilePic.Length+3)/4), '=');


                    string pattern = @".*,";
                    string substitution = @"";

                    Regex regex = new Regex(pattern, RegexOptions.Multiline);
                    string result = regex.Replace(model.AdharImage, substitution);
                    string result1 = regex.Replace(model.PanImage, substitution);
                    string result2 = regex.Replace(model.DocImage, substitution);

                    byte[] bytes = Convert.FromBase64String(result);
                    byte[] bytes1 = Convert.FromBase64String(result1);
                    byte[] bytes2 = Convert.FromBase64String(result2);
                    string aadharfullpath = System.Web.HttpContext.Current.Server.MapPath("~/AadharPicture/");
                    string panfullpath = System.Web.HttpContext.Current.Server.MapPath("~/PanPicture/");
                    string docfullpath = System.Web.HttpContext.Current.Server.MapPath("~/DocumentPicture/");
                    int fCount = Directory.GetFiles(aadharfullpath, "*", SearchOption.AllDirectories).Length;
                    int fCount1 = Directory.GetFiles(panfullpath, "*", SearchOption.AllDirectories).Length;
                    int fCount2 = Directory.GetFiles(docfullpath, "*", SearchOption.AllDirectories).Length;

                    string adharfilePath = aadharfullpath + timeStamp + "img" + fCount + ".png";
                    System.IO.File.WriteAllBytes(adharfilePath, bytes);

                    string panfilePath = panfullpath + timeStamp + "img" + fCount1 + ".png";
                    System.IO.File.WriteAllBytes(panfilePath, bytes1);

                    string docfilePath = docfullpath + timeStamp + "img" + fCount2 + ".png";
                    System.IO.File.WriteAllBytes(docfilePath, bytes2);


                    string rep = Regex.Replace(aadharfullpath, @"[\\,]+", "/");
                    string cleanString = rep.Remove(0, 55);

                    string rep1 = Regex.Replace(panfullpath, @"[\\,]+", "/");
                    string cleanString1 = rep1.Remove(0, 55);

                    string rep2 = Regex.Replace(docfullpath, @"[\\,]+", "/");
                    string cleanString2 = rep2.Remove(0, 55);


                    model.AdharImage = cleanString + timeStamp + "img" + fCount + ".png";
                    model.PanImage = cleanString1 + timeStamp + "img" + fCount + ".png";
                    model.DocImage = cleanString2 + timeStamp + "img" + fCount + ".png";
                }
                else
                {
                    model.ImageURL = "";
                }
                DataSet dsResult = model.UploadKYCDocuments();
                if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
                {
                    if (dsResult.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        obj.Status = "0";
                        obj.SuccessMessage = "Image Upload Successfully.";

                    }
                    else
                    {
                        obj.Status = "1";
                        obj.ErrorMessage = dsResult.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    obj.Status = "1";
                    obj.ErrorMessage = "Some Error Occured.";
                }
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                obj.Status = "1";
                obj.ErrorMessage = ex.Message;
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult PanUpload(UploadPan model)
        {
            Response obj = new Response();
            try
            {
                if (model.ImageURL != null)
                {
                    string timeStamp = DateTime.Now.ToString("yyMMddHHmmssfff");
                    //model.ProfilePic = model.ProfilePic.Replace('-', '+').Replace('%','/').Replace('_', '/').PadRight(4*((model.ProfilePic.Length+3)/4), '=');


                    string pattern = @".*,";
                    string substitution = @"";

                    Regex regex = new Regex(pattern, RegexOptions.Multiline);
                    string result = regex.Replace(model.ImageURL, substitution);

                    byte[] bytes = Convert.FromBase64String(result);
                    string dirFullPath = System.Web.HttpContext.Current.Server.MapPath("~/PanPicture/");
                    int fCount = Directory.GetFiles(dirFullPath, "*", SearchOption.AllDirectories).Length;
                    string filePath = dirFullPath + timeStamp + "img" + fCount + ".png";
                    System.IO.File.WriteAllBytes(filePath, bytes);

                    string rep = Regex.Replace(dirFullPath, @"[\\,]+", "/");
                    string cleanString = rep.Remove(0, 55);


                    model.ImageURL = cleanString + timeStamp + "img" + fCount + ".png";
                }
                else
                {
                    model.ImageURL = "";
                }
                DataSet dsResult = model.UploadPanDocuments();
                if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
                {
                    if (dsResult.Tables[0].Rows[0]["Msg"].ToString() == "1")
                    {
                        obj.Status = "0";
                        obj.SuccessMessage = "Image Upload Successfully.";

                    }
                    else
                    {
                        obj.Status = "1";
                        obj.ErrorMessage = dsResult.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                }
                else
                {
                    obj.Status = "1";
                    obj.ErrorMessage = "Some Error Occured.";
                }
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                obj.Status = "1";
                obj.ErrorMessage = ex.Message;
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

    }
}