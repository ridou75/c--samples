using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
namespace WebPhotos
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblImage.Text = getTitle();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblImage.Text = getTitle();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        protected string getTitle()
        {
            WebRequest request = HttpWebRequest.Create("http://localhost:18343/ShowNextHandler.ashx?Type=Label"); //, "Type=Label");
            WebResponse response = request.GetResponse();
            int l = (int)response.ContentLength;
            byte[] buffer = new byte[l];
            response.GetResponseStream().Read(buffer, 0, l);
            response.Close();
            string sTitle = "";
            for (int i = 0; i < buffer.Length; i++)
            {
                sTitle += (char)buffer[i];
            }
            return sTitle;
        }
    }
}