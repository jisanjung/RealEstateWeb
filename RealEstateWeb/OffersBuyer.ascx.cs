using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using HomeLibrary;
using System.Web.Script.Serialization;

namespace RealEstateWeb
{
    public partial class OffersBuyer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string jsonOffers = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebsAPITest/api/homeoffers");
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<HomeOffer> allHomeOffers = js.Deserialize<List<HomeOffer>>(jsonOffers);

            if (!IsPostBack)
            {
                this.displayOffers(allHomeOffers);
            }
        }
        private void displayOffers(List<HomeOffer> homeOffers)
        {
            List<HomeOffer> acceptedOffers = new List<HomeOffer>();

            if (Request.Cookies["user_cookie"] != null)
            {
                string buyerEmail = Request.Cookies["user_cookie"]["user_email"];
                foreach (HomeOffer ho in homeOffers)
                {
                    if (ho.Accepted && ho.BuyerEmail.CompareTo(buyerEmail) == 0)
                    {
                        acceptedOffers.Add(ho);
                    }
                }
            }
            this.rptAcceptedOffers.DataSource = acceptedOffers;
            this.rptAcceptedOffers.DataBind();
        }
    }
}