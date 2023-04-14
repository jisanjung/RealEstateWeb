using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateWeb
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        HttpCookie loginCookie;

        public event EventHandler LoadComplete;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"]["user_type"].Equals("Buyer"))
            { //for buyers
                btnOffers.Visible = false;
                btnOffersBuyer.Visible = true;
                btnCreateHome.Visible = false;
                btnSellerHomes.Visible = false;
            }
            else 
            { //for sellers/agents
                btnOffers.Visible = true; 
                btnOffersBuyer.Visible = false;
                btnCreateHome.Visible = true;
                btnSellerHomes.Visible = true;
            }
        }



        protected void btnCreateHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCreateHome.aspx");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmSearch.aspx");
        }
        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDashboard.aspx");
        }
        protected void btnOffers_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmOffers.aspx");
        }
        protected void btnOffersBuyer_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmOffersBuyer.aspx");
        }
        protected void btnSellerHomes_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmSellerHomes.aspx");
        }
    }
}