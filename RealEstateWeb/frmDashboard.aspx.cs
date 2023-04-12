using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateWeb
{
    public partial class frmDashboard : System.Web.UI.Page
    {
        HttpCookie loginCookie;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("frmAccountCreation.aspx");
            }
            else
            {
                loginCookie = Request.Cookies["user_cookie"];
            }
        }
    }
}