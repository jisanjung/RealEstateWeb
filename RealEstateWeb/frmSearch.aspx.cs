using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

using HomeLibrary;
using Utilities;

namespace RealEstateWeb
{
    public partial class frmSearch : System.Web.UI.Page
    {
        DBConnect connection = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string jsonRes = RestClient.Get("http://localhost:60855/api/homes");
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //List<Home> allHomes = js.Deserialize<List<Home>>(jsonRes);

            List<Home> allHomes = this.staticallyGenerateHomes();

            if (!IsPostBack)
            {
                this.displayHomes(allHomes);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<Home> filteredHomes = this.filterHomes();
            this.displayHomes(filteredHomes);
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

            //string jsonRes = RestClient.Get("http://localhost:60855/api/homes");
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //List<Home> allHomes = js.Deserialize<List<Home>>(jsonRes);

            List<Home> allHomes = this.staticallyGenerateHomes();

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
            h1.SellerEmail = "json.eth@gmail.com";
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

            allHomes.Add(h1);
            allHomes.Add(h2);
            allHomes.Add(h3);

            return allHomes;
        }
        private void fillHomeProfileInfo(int home_id)
        {
            // string jsonRes = RestClient.Get("http://localhost:60855/api/homes/" + home_id.ToString());
            List<Home> allHomes = this.staticallyGenerateHomes();
            Home selectedHome = new Home();
            foreach (Home h in allHomes)
            {
                if (h.HomeId == home_id)
                {
                    selectedHome = h;
                }
            }
            this.imgHomeProfile.Src = $"~/Storage/{selectedHome.Img}";
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
            this.lblHomeProfileDescription.Text = $"{selectedHome.SellerEmail}";
        }
    }
}