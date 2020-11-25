using HMGreenCityMLM.Models;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;


namespace HMGreenCityMLM.Controllers
{
    [RoutePrefix("api/ImageUpload")]
    public class ImageUploadController : ApiController
    {
        [Route("user/PostUserImage")]
        [AllowAnonymous]
        public HttpResponseMessage PostUserImage()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
              
                var httpRequest = HttpContext.Current.Request;
                var FK_UserId = "";
                FK_UserId = httpRequest.Form["fk_Userid"].ToString();

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {

                            var file1 = httpRequest.Files[file];

                            var filePath = HttpContext.Current.Server.MapPath("~/ProfilePicture/" + postedFile.FileName);
                            //  var thisFileName = rn.Next(10, 100) + "_DWPE_" + DateTime.Now.ToString("ddmmyyhhmmss") + "_" + file1.Headers.ContentDisposition.FileName.Trim('\"');
                        var df =    file1.FileName.ToString();
                            postedFile.SaveAs(filePath);
                            var thisFileName = "/ProfilePicture/"+df;
                            Upload model = new Upload();
                            model.Fk_UserId = FK_UserId;
                            model.ImageURL = thisFileName;
                            DataSet ds = model.UpdateImage();

                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
                }
                var res = string.Format("Please Upload a image.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
        }

    }




}