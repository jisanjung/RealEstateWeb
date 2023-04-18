using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HomeLibrary;

namespace RealEstateWeb
{
    public partial class frmBuyerScheduledVisits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                string userType = Request.Cookies["user_cookie"]["user_type"];
                if (userType.CompareTo("Buyer") != 0)
                {
                    Response.Redirect("frmErrorPage.aspx");
                }
            }
            gvHomes.DataSource = DBOperations.GetBuyerHomes(Request.Cookies["user_cookie"]["user_email"]);
            gvHomes.DataBind();
        }
    }
}