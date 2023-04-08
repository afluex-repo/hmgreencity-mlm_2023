using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMGreenCityMLM.Models
{
    public class Imagelist
    {
       
        public string ImageUrl { get; set; }

        public string Pk_UserId { get; set; }
        public string Status { get; set; }
        public string Path { get; set; }
        public string ErrorMessage { get; set; }
        public string DocumentType { get; set; }
    }

    public class OffersImage
    {
        public string ImageURL { get; set; }
        public string ImageName { get; set; }
        public string Link { get; set; }
    }
    public class OfferImageResponse
    {
        public string response { get; set; }        
        public List<OffersImage> OfferImages { get; set; }
    }

    public class Support
    {

        public string ImageUrl { get; set; }

        public string Pk_UserId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string Subject { get; set; }
    }
}