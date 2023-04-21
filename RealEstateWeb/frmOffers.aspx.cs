using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using HomeLibrary;

namespace RealEstateWeb
{
    public partial class frmOffers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                string userType = Request.Cookies["user_cookie"]["user_type"];
                if (userType.CompareTo("Buyer") == 0)
                {
                    Response.Redirect("frmErrorPage.aspx");
                } else
                {
                    string jsonOffers = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebsAPITest/api/homeoffers");
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    List<HomeOffer> allHomeOffers = js.Deserialize<List<HomeOffer>>(jsonOffers);

                    if (!IsPostBack)
                    {
                        this.displayOffers(allHomeOffers);
                    }
                }
            }
        }
        protected void btn_ViewOffer(object sender, CommandEventArgs e)
        {
            this.divViewOffer.Visible = true;

            int rowClicked = int.Parse(e.CommandArgument.ToString());
            Label lblOfferId = (Label)rptOffers.Items[rowClicked].FindControl("lblOfferId");
            int offerId = int.Parse(lblOfferId.Text);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonOffer = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebsAPITest/api/homeoffers/" + offerId);
            HomeOffer homeOffer = js.Deserialize<HomeOffer>(jsonOffer);


            string jsonHome = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebsAPITest/api/homes/" + homeOffer.HomeId);
            Home home = js.Deserialize<Home>(jsonHome);

            this.lblViewOfferId.Text = homeOffer.HomeOfferId.ToString();
            this.lblOfferTitle.Text = $"Offer for {home.Address}";
            this.lblBuyerEmail.Text = $"{homeOffer.BuyerEmail} wants to buy this home";
            this.lblSaleType.Text = $"{homeOffer.SaleType}";
            this.lblContingencies.Text = $"{homeOffer.Contingencies}";
            this.lblMoveinDate.Text = $"{homeOffer.MoveInDate}";
            this.lblSellHomeFirst.Text = homeOffer.SellHomeFirst ? "Buyer needs to sell their home first" : "Buyer does not need to sell their home";
            this.btnAcceptAmount.Text = "Accept " + homeOffer.OfferAmount.ToString("c");
        }
        private void displayOffers(List<HomeOffer> homeOffers)
        {
            List<HomeOffer> unacceptedOffers = new List<HomeOffer>();

            if (Request.Cookies["user_cookie"] != null)
            {
                string sellerEmail = Request.Cookies["user_cookie"]["user_email"];
                foreach (HomeOffer ho in homeOffers)
                {
                    if (!ho.Accepted && ho.SellerEmail.CompareTo(sellerEmail) == 0)
                    {
                        unacceptedOffers.Add(ho);
                    }
                }
            }
            this.rptOffers.DataSource = unacceptedOffers;
            this.rptOffers.DataBind();
        }

        protected void btnAcceptAmount_Click(object sender, EventArgs e)
        {
            int offerId = int.Parse(this.lblViewOfferId.Text);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonOfferRes = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebsAPITest/api/homeoffers/" + offerId);
            HomeOffer homeOffer = js.Deserialize<HomeOffer>(jsonOfferRes);
            homeOffer.Accepted = true;

            string jsonOfferReq = js.Serialize(homeOffer);
            int status = int.Parse(RestClient.Put("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebsAPITest/api/homeoffers/Accept/" + offerId, jsonOfferReq));

            if (status < 1)
            {
                this.lblAlert.Text = "There was a problem accepting this offer...";
                this.lblAlert.CssClass = "alert alert-danger d-inline-block mt-3";
            } else
            {
                this.lblAlert.Text = "Offer Accepted!";
                this.lblAlert.CssClass = "alert alert-success d-inline-block mt-3";
            }
        }

        protected void btnDeclineOffer_Click(object sender, EventArgs e)
        {
            int offerId = int.Parse(this.lblViewOfferId.Text);

            int status = int.Parse(RestClient.Delete("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebsAPITest/api/homeoffers/Remove/" + offerId));

            if (status < 1)
            {
                this.lblAlert.Text = "There was a problem declining this offer...";
                this.lblAlert.CssClass = "alert alert-danger d-inline-block mt-3";
            }
            else
            {
                this.lblAlert.Text = "Declined Offer";
                this.lblAlert.CssClass = "alert alert-success d-inline-block mt-3";

                string jsonOffers = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebsAPITest/api/homeoffers");
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<HomeOffer> allHomeOffers = js.Deserialize<List<HomeOffer>>(jsonOffers);

                this.displayOffers(allHomeOffers);
            }
        }

        protected void linkbtnClose_Click(object sender, EventArgs e)
        {
            this.divViewOffer.Visible = false;
        }
    }
}