using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;

namespace WjjStudy.aspx
{
    public partial class testCnoStr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = ConfigurationManager.ConnectionStrings["db1"] + "<br/>" + DES.Decrypt(ConfigurationManager.AppSettings["ZNDD1"]) + "<br/>" + DES.Decrypt(ConfigurationManager.AppSettings["ZNDD2"]) + "<br/>" + DES.Decrypt(ConfigurationManager.AppSettings["ConnectionString"]);
        }
    }
}