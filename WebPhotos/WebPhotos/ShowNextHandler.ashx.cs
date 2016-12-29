using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace WebPhotos
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class ShowNextHandler : IHttpHandler
    {
        static List<FileInfo> photos = new List<FileInfo>();
        static int photoNumber = -1;
        static string sRoot = @"C:\Users\Farid Hatimi\Pictures\Covers";//@"C:\Users\Farid Hatimi\Documents\visual studio 2012\Projects\WebPhotos\WebPhotos\Images";
        public void ProcessRequest(HttpContext context)
        {
            if (photos.Count == 0)
            {
                photoNumber = 0;
                DirectoryInfo di = new DirectoryInfo(sRoot);
                FileInfo[] finfos = di.GetFiles("*.jpg", SearchOption.TopDirectoryOnly);
                for (int i = 0; i < finfos.Length; i++)
                {
                    photos.Add(finfos[i]);
                }

            }
            string sResultType = context.Request.QueryString["Type"];
            if (sResultType == "Label")
            {
                context.Response.ContentType = "plain/text";
                context.Response.Write(photos[photoNumber].Name);
            }
            else
            {
                string photo = photos[photoNumber].FullName; // /20151130_113200.jpg"
                context.Response.ContentType = "image/jpeg";
                context.Response.WriteFile(photo);
                // store Next Number
                photoNumber++;
                if (photoNumber == photos.Count)
                {
                    photoNumber = 0;
                }
            }
        }
        public void getPhotoName(HttpContext pContext)
        {
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}