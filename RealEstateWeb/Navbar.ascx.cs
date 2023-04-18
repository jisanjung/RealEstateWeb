using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

using HomeLibrary;
using Utilities;

namespace RealEstateWeb
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        HttpCookie loginCookie;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                string userType = Request.Cookies["user_cookie"]["user_type"];
                string userEmail = Request.Cookies["user_cookie"]["user_email"];

                if (userType.CompareTo("Agent") == 0)
                {
                    // agent user
                    this.agentLinks.Visible = true;
                    this.sellerLinks.Visible = false;
                    this.buyerLinks.Visible = false;

                    this.agentOfferCount.InnerText = this.getOffersCount(userEmail, userType) == 0 ? "" : this.getOffersCount(userEmail, userType).ToString();

                }
                else if (userType.CompareTo("Seller") == 0)
                {
                    // seller user
                    this.sellerLinks.Visible = true;
                    this.agentLinks.Visible = false;
                    this.buyerLinks.Visible = false;

                    this.sellerOfferCount.InnerText = this.getOffersCount(userEmail, userType) == 0 ? "" : this.getOffersCount(userEmail, userType).ToString();

                }
                else if (userType.CompareTo("Buyer") == 0)
                {
                    // buyer user
                    this.buyerLinks.Visible = true;
                    this.agentLinks.Visible = false;
                    this.sellerLinks.Visible = false;

                    this.buyerOfferCount.InnerText = this.getOffersCount(userEmail, userType) == 0 ? "" : this.getOffersCount(userEmail, userType).ToString();
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // how to delete cookies in asp, just set the expiration date to past date: https://stackoverflow.com/questions/6635349/how-to-delete-cookies-on-an-asp-net-website
            HttpCookie cookie = new HttpCookie("user_cookie");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);

            Response.Redirect("frmAccountCreation.aspx");
        }
        private int getOffersCount(string userEmail, string userType)
        {
            int count;
            string jsonOffers = RestClient.Get("http://localhost:60855/api/homeoffers");
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<HomeOffer> allHomeOffers = js.Deserialize<List<HomeOffer>>(jsonOffers);
            List<HomeOffer> filteredOffers = new List<HomeOffer>();

            foreach (HomeOffer ho in allHomeOffers)
            {
                if (userType.CompareTo("Buyer") == 0 && ho.BuyerEmail.CompareTo(userEmail) == 0 && ho.Accepted)
                {
                    filteredOffers.Add(ho);
                }
                if (userType.CompareTo("Seller") == 0 && ho.SellerEmail.CompareTo(userEmail) == 0 && !ho.Accepted)
                {
                    filteredOffers.Add(ho);
                }
                if (userType.CompareTo("Agent") == 0 && ho.SellerEmail.CompareTo(userEmail) == 0 && !ho.Accepted)
                {
                    filteredOffers.Add(ho);
                }
            }
            return filteredOffers.Count;
        }
    }
}