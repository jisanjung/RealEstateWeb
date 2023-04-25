using HomeLibrary;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using Utilities;

namespace RealEstateWeb
{
    public partial class frmSearch : System.Web.UI.Page
    {
        DBConnect connection = new DBConnect();
        HttpCookie loginCookie;
        protected void Page_Load(object sender, EventArgs e)
        {
            string jsonRes = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebAPI/api/homes");
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Home> allHomes = js.Deserialize<List<Home>>(jsonRes);

            // List<Home> allHomes = this.staticallyGenerateHomes();

            if (!IsPostBack)
            {
                this.displayHomes(allHomes);
                this.h3Results.InnerText = $"Results ({allHomes.Count})";
            }

            if (Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("frmAccountCreation.aspx");
            }
            else
            {
                loginCookie = Request.Cookies["user_cookie"];
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<Home> filteredHomes = this.filterHomes();
            this.displayHomes(filteredHomes);
            this.h3Results.InnerText = $"Results ({filteredHomes.Count})";
        }
        protected void btn_ViewHome(object sender, CommandEventArgs e)
        {
            int rowClicked = int.Parse(e.CommandArgument.ToString());
            Label lblHomeId = (Label)rptHomeResults.Items[rowClicked].FindControl("lblHomeId");
            int homeId = int.Parse(lblHomeId.Text);

            this.divHomeProfile.Visible = true;
            this.fillHomeProfileInfo(homeId);
        }
        private void displayHomes(List<Home> homes)
        {
            this.rptHomeResults.DataSource = homes;
            this.rptHomeResults.DataBind();
        }
        private List<Home> filterHomes()
        {
            List<Home> toReturn = new List<Home>();

            string amenities = "";
            foreach (ListItem item in this.cblAmenities.Items)
            {
                if (item.Selected)
                {
                    amenities += $"{item.Value}, ";
                }
            }

            string jsonRes = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebAPI/api/homes");
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Home> allHomes = js.Deserialize<List<Home>>(jsonRes);

            // List<Home> allHomes = this.staticallyGenerateHomes();

            foreach (Home h in allHomes)
            {
                bool zipCond = String.IsNullOrEmpty(txtZipCode.Text) ? true : h.ZipCode == int.Parse(txtZipCode.Text);
                bool priceCond = String.IsNullOrEmpty(txtPriceRange.Text) ? true : h.Price <= int.Parse(txtPriceRange.Text);
                bool propertyTypeCond = ddlPropertyType.SelectedValue.CompareTo("Any") == 0 ? true : h.PropertyType.CompareTo(ddlPropertyType.SelectedValue) == 0;
                bool houseSizeCond = String.IsNullOrEmpty(txtHomeSize.Text) ? true : h.HouseSize <= int.Parse(txtHomeSize.Text);
                bool numBedroomCond = String.IsNullOrEmpty(txtMinBedrooms.Text) ? true : h.NumberBed >= int.Parse(txtMinBedrooms.Text);
                bool numBathroomCond = String.IsNullOrEmpty(txtMinBathrooms.Text) ? true : h.NumberBath >= int.Parse(txtMinBathrooms.Text);
                bool amenitiesCond = amenities.Length < 1 ? true : h.OtherAmenities.Contains(amenities.Substring(0, amenities.Length - 2));
                if (zipCond && priceCond && propertyTypeCond && houseSizeCond && numBedroomCond && numBathroomCond && amenitiesCond)
                {
                    toReturn.Add(h);
                }
            }
            return toReturn;
        }
        private void fillHomeProfileInfo(int home_id)
        {
            string jsonRes = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebAPI/api/homes/" + home_id.ToString());
            JavaScriptSerializer js = new JavaScriptSerializer();
            Home selectedHome = js.Deserialize<Home>(jsonRes);

            this.imgHomeProfile.Src = $"~/Storage/{selectedHome.Img}";
            this.lblHomeProfileHomeId.Text = selectedHome.HomeId.ToString();
            this.lblHomeProfilePrice.Text = selectedHome.Price.ToString("C");
            this.lblHomeProfileBeds.Text = $"{selectedHome.NumberBed} beds";
            this.lblHomeProfileBaths.Text = $"{selectedHome.NumberBath} bathrooms";
            this.lblHomeProfileHomeSize.Text = $"{selectedHome.HouseSize} sqft";
            this.lblHomeProfileAddress.Text = $"{selectedHome.Address} {selectedHome.ZipCode}";
            this.lblHomeProfilePropertyType.Text = $"{selectedHome.PropertyType}";
            this.lblHomeProfileYearBuilt.Text = $"{selectedHome.YearBuilt}";
            this.lblHomeProfileAmenities.Text = $"{selectedHome.OtherAmenities}";
            this.lblHomeProfileHVAC.Text = $"{selectedHome.HVAC}";
            this.lblHomeProfileGarage.Text = $"{selectedHome.Garage}";
            this.lblHomeProfileUtilities.Text = $"{selectedHome.Utilities}";
            this.lblHomeProfileDescription.Text = $"{selectedHome.Description}";

            // room dimensions
            string roomDimensionText = "<ul class='list-group'>";
            foreach (Room r in selectedHome.Rooms)
            {
                roomDimensionText += $"<li class='list-group-item'><span class='fw-bold'>{r.RoomType}:</span> {r.Length}ft x {r.Width}ft</li>";
            }
            this.lblHomeProfileRoomDimensions.Text = roomDimensionText + "</ul>";

            User seller = DBOperations.GetUser(selectedHome.AgentEmail);

            this.lblHomeProfileAgentEmail.Text = seller.Email;
            this.lblHomeProfileAgentInfo.Text = $" ({seller.FullName})</br>{seller.Address}<div><span>Real Estate Company: </span>{selectedHome.CompanyName}</div>";
        }

        protected void btnRequestShowing_Click(object sender, EventArgs e)
        {
            this.divCreateShowing.Visible = true;
        }

        protected void btnSubmitShowing_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                int homeId = int.Parse(this.lblHomeProfileHomeId.Text);
                string agentEmail = this.lblHomeProfileAgentEmail.Text;
                string buyerEmail = Request.Cookies["user_cookie"]["user_email"];
                string showDate = this.txtShowingDate.Text;
                string showTime = this.txtShowingTime.Text;

                HomeShowing showingRequest = new HomeShowing();
                showingRequest.HomeId = homeId;
                showingRequest.SellerEmail = agentEmail;
                showingRequest.BuyerEmail = buyerEmail;
                showingRequest.Date = showDate;
                showingRequest.Time = showTime;

                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonShowingRequest = js.Serialize(showingRequest);

                int status = int.Parse(RestClient.Post("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebAPI/api/homeshowing/Add", jsonShowingRequest));
                if (status < 1)
                {
                    this.lblAlerts.Text = "There was a problem submitting your request...";
                    this.lblAlerts.CssClass = "alert alert-danger d-inline-block mt-2";
                }
                else
                {
                    this.lblAlerts.Text = "Home Showing Request Submitted!";
                    this.lblAlerts.CssClass = "alert alert-success d-inline-block mt-2";
                }
            }
        }

        protected void btnFeedback_Click(object sender, EventArgs e)
        {
            this.divLeaveFeedback.Visible = true;
        }

        protected void btnSubmitFeedback_Click(object sender, EventArgs e)
        {
            int homeId = int.Parse(this.lblHomeProfileHomeId.Text);
            FeedbackService.Feedback pxy = new FeedbackService.Feedback();

            string priceFeedback = this.ddlPriceFeedback.SelectedValue;
            string locationFeedback = this.ddlLocationFeedback.SelectedValue;
            string overallFeedback = this.taOverallFeedback.Value;
            int rating = int.Parse(this.ddlRating.SelectedValue);

            int status = pxy.AddFeedback(homeId, priceFeedback, locationFeedback, overallFeedback, rating);
            
            if (status < 1)
            {
                this.lblAlerts.Text = "Could not submit feedback...";
                this.lblAlerts.CssClass = "alert alert-danger d-inline-block mt-2";
            } else
            {
                this.lblAlerts.Text = "Thank you for your response. Your feedback matters to us";
                this.lblAlerts.CssClass = "alert alert-success d-inline-block mt-2";
            }
        }

        protected void linkbtnMakeOffer_Click(object sender, EventArgs e)
        {
            this.divMakeOffer.Visible = true;
        }

        protected void btnSubmitOffer_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                float offerAmount;
                if (float.TryParse(this.txtOfferAmount.Text, out offerAmount))
                {
                    int homeId = int.Parse(this.lblHomeProfileHomeId.Text);
                    string saleType = this.ddlSaleType.SelectedValue;

                    string contingencies = "";
                    foreach (ListItem item in this.cblContingencies.Items)
                    {
                        if (item.Selected)
                        {
                            contingencies += $"{item.Value}, ";
                        }
                    }

                    contingencies = String.IsNullOrEmpty(contingencies) ? "None" : contingencies.Substring(0, contingencies.Length - 2);
                    string moveinDate = this.txtMoveinDate.Text;
                    bool sellHomeFirst = this.chkSellHomeFirst.Checked;
                    string buyerEmail = Request.Cookies["user_cookie"]["user_email"];
                    string agentEmail = this.lblHomeProfileAgentEmail.Text;

                    HomeOffer ho = new HomeOffer();
                    ho.HomeId = homeId;
                    ho.SaleType = saleType;
                    ho.Contingencies = contingencies;
                    ho.OfferAmount = offerAmount;
                    ho.MoveInDate = moveinDate;
                    ho.SellHomeFirst = sellHomeFirst;
                    ho.BuyerEmail = buyerEmail;
                    ho.SellerEmail = agentEmail;
                    ho.Accepted = false;

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    String jsonOffer = js.Serialize(ho);

                    int status = int.Parse(RestClient.Post("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebAPI/api/homeoffers/Add/", jsonOffer));

                    if (status < 1)
                    {
                        this.lblAlerts.Text = "Offer could not be sent...";
                        this.lblAlerts.CssClass = "alert alert-danger d-inline-block mt-2";
                    }
                    else
                    {
                        this.lblAlerts.Text = "Offer sent successfully";
                        this.lblAlerts.CssClass = "alert alert-success d-inline-block mt-2";
                    }
                } else
                {
                    this.lblAlerts.Text = "Offer must be a number";
                    this.lblAlerts.CssClass = "alert alert-danger d-inline-block mt-2";
                }
            }
        }

        protected void linkbtnClose_Click(object sender, EventArgs e)
        {
            this.divHomeProfile.Visible = false;
        }
    }
}