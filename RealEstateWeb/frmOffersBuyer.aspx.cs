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
    public partial class frmOffersBuyer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                string jsonOffers = RestClient.Get("http://localhost:60855/api/homeoffers");
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<HomeOffer> allHomeOffers = js.Deserialize<List<HomeOffer>>(jsonOffers);

                List<HomeOffer> acceptedOffers = new List<HomeOffer>();
                string buyerEmail = Request.Cookies["user_cookie"]["user_email"];
                foreach (HomeOffer ho in allHomeOffers)
                {
                    if (ho.Accepted && ho.BuyerEmail.CompareTo(buyerEmail) == 0)
                    {
                        acceptedOffers.Add(ho);
                    }
                }

                if (acceptedOffers.Count > 0)
                {
                    this.lblTitle.Text = "Congratulations! You are soon to be a home owner.";
                } else
                {
                    this.ucOffersBuyer.Visible = false;
                    this.lblTitle.Text = "Looks like you currently have no offers accepted :(";
                }
            }
        }
    }
}