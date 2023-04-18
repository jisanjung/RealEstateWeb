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
            string jsonRes = RestClient.Get("http://localhost:60855/api/homes");
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Home> allHomes = js.Deserialize<List<Home>>(jsonRes);

            // List<Home> allHomes = this.staticallyGenerateHomes();

            if (!IsPostBack)
            {
                this.displayHomes(allHomes);
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
            if (this.isSearchValid())
            {
                List<Home> filteredHomes = this.filterHomes();
                this.displayHomes(filteredHomes);
            }
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

            string jsonRes = RestClient.Get("http://localhost:60855/api/homes");
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
        private List<Home> staticallyGenerateHomes()
        {
            List<Home> allHomes = new List<Home>();
            Home h1 = new Home();
            h1.Address = "522 lansdale ave";
            h1.Price = 23000;
            h1.NumberBed = 2;
            h1.NumberBath = 1;
            h1.ZipCode = 19446;
            h1.Img = "2023-02-13 20.44.09.jpg";
            h1.HomeId = 7;
            h1.PropertyType = "Single-Family";
            h1.HouseSize = 657;
            h1.OtherAmenities = "Garden";
            h1.HVAC = "Oil";
            h1.YearBuilt = 1950;
            h1.Garage = "None";
            h1.Utilities = "Public Water";
            h1.Description = "this is a comfy home";
            h1.SellerEmail = "json.jung@temple.edu";
            h1.CompanyName = "N/A";
            Home h2 = new Home();
            h2.Address = "805 freedom cir";
            h2.Price = 81000;
            h2.NumberBed = 4;
            h2.NumberBath = 2;
            h2.ZipCode = 19454;
            h2.Img = "2023-02-13 20.44.09.jpg";
            h2.HomeId = 8;
            h2.PropertyType = "Multi-Family";
            h2.HouseSize = 1498;
            h2.OtherAmenities = "Fireplace";
            h2.HVAC = "Electric";
            h2.YearBuilt = 2001;
            h2.Garage = "2 Car";
            h2.Utilities = "Well Water";
            h2.Description = "this is an aight home";
            h2.SellerEmail = "hong@gmail.com";
            h2.CompanyName = "N/A";
            Home h3 = new Home();
            h3.Address = "901 shelby dr";
            h3.Price = 1000000;
            h3.NumberBed = 6;
            h3.NumberBath = 3;
            h3.ZipCode = 90210;
            h3.Img = "2023-02-13 20.44.09.jpg";
            h3.HomeId = 9;
            h3.PropertyType = "Condo";
            h3.HouseSize = 3894;
            h3.OtherAmenities = "Fireplace, Hot Tub";
            h3.HVAC = "Electric";
            h3.YearBuilt = 2007;
            h3.Garage = "4 Car";
            h3.Utilities = "Well Water";
            h3.Description = "this is a great home";
            h3.SellerEmail = "bob@gmail.com";
            h3.CompanyName = "Brother Technologies";

            allHomes.Add(h1);
            allHomes.Add(h2);
            allHomes.Add(h3);

            return allHomes;
        }
        private void fillHomeProfileInfo(int home_id)
        {
            string jsonRes = RestClient.Get("http://localhost:60855/api/homes/" + home_id.ToString());
            JavaScriptSerializer js = new JavaScriptSerializer();
            Home selectedHome = js.Deserialize<Home>(jsonRes);

            this.imgHomeProfile.Src = $"~/Storage/{selectedHome.Img}";
            this.lblHomeProfileHomeId.Text = selectedHome.HomeId.ToString();
            this.lblHomeProfilePrice.Text = selectedHome.Price.ToString("c");
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

            User seller = DBOperations.GetUser(selectedHome.SellerEmail);

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

                int status = int.Parse(RestClient.Post("http://localhost:60855/api/homeshowing/Add", jsonShowingRequest));
                if (status < 1)
                {
                    this.lblHomeShowingAlert.Text = "There was a problem submitting your request...";
                }
                else
                {
                    this.lblHomeShowingAlert.Text = "Home Showing Request Submitted!";
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
                this.lblFeedbackAlert.Text = "Could not submit feedback...";
            } else
            {
                this.lblFeedbackAlert.Text = "Thank you for your response. Your feedback matters to us";
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

                    int status = int.Parse(RestClient.Post("http://localhost:60855/api/homeoffers/Add/", jsonOffer));

                    if (status < 1)
                    {
                        this.lblOfferAlert.Text = "Offer could not be sent...";
                    }
                    else
                    {
                        this.lblOfferAlert.Text = "Offer sent successfully";
                    }
                } else
                {
                    this.lblOfferAlert.Text = "Offer must be a number";
                }
            }
        }

        private bool isSearchValid()
        {
            bool toReturn = true;
            int value;
            if (!int.TryParse(this.txtZipCode.Text, out value) && !int.TryParse(this.txtPriceRange.Text, out value) && !int.TryParse(this.txtHomeSize.Text, out value) && !int.TryParse(this.txtMinBedrooms.Text, out value) && !int.TryParse(this.txtMinBathrooms.Text, out value))
            {
                this.lblSearchAlert.Text = "Inputs must be numbers";
            }
            return toReturn;
        }
    }
}