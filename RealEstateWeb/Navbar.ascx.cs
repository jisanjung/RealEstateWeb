using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateWeb
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmMain.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmSearch.aspx");
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDashboard.aspx");
        }

        protected void frmAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmPage.aspx");
        }
    }
}