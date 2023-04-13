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
            string jsonOffers = RestClient.Get("http://localhost:60855/api/homeoffers");
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<HomeOffer> allHomeOffers = js.Deserialize<List<HomeOffer>>(jsonOffers);
            List<HomeOffer> unacceptedOffers = new List<HomeOffer>();

            foreach (HomeOffer ho in allHomeOffers)
            {
                if (!ho.Accepted)
                {
                    unacceptedOffers.Add(ho);
                }
            }

            if (!IsPostBack)
            {
                this.displayOffers(unacceptedOffers);
            }
        }
        protected void btn_ViewOffer(object sender, CommandEventArgs e)
        {
            this.divViewOffer.Visible = true;

            int rowClicked = int.Parse(e.CommandArgument.ToString());
            Label lblOfferId = (Label)rptOffers.Items[rowClicked].FindControl("lblOfferId");
            int offerId = int.Parse(lblOfferId.Text);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonOffer = RestClient.Get("http://localhost:60855/api/homeoffers/" + offerId);
            HomeOffer homeOffer = js.Deserialize<HomeOffer>(jsonOffer);


            string jsonHome = RestClient.Get("http://localhost:60855/api/homes/" + homeOffer.HomeId);
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
            this.rptOffers.DataSource = homeOffers;
            this.rptOffers.DataBind();
        }
    }
}