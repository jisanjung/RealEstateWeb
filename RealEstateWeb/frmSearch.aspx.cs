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
            if (!IsPostBack)
            {
                List<Home> homes = new List<Home>();
                Home h1 = new Home();
                h1.Address = "522 Lansdale Ave";
                h1.Price = 23000;
                h1.HouseSize = 657;
                h1.NumberBed = 2;
                h1.NumberBath = 1;
                h1.ZipCode = 19446;
                h1.Img = "2023-02-13 20.44.09.jpg";
                Home h2 = new Home();
                h2.Address = "805 Freedom Cir";
                h2.Price = 4000000;
                h2.HouseSize = 1203;
                h2.NumberBed = 4;
                h2.NumberBath = 2;
                h2.ZipCode = 90210;
                h2.Img = "2023-02-13 20.44.09.jpg";
                homes.Add(h1);
                homes.Add(h2);

                this.rptHomeResults.DataSource = homes;
                this.rptHomeResults.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.filterHomes();
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

            if (String.IsNullOrEmpty(this.txtZipCode.Text) && String.IsNullOrEmpty(this.txtPriceRange.Text) && this.ddlPropertyType.SelectedValue.CompareTo("Any") == 0 && String.IsNullOrEmpty(this.txtHomeSize.Text) && String.IsNullOrEmpty(this.txtMinBedrooms.Text) && String.IsNullOrEmpty(this.txtMinBathrooms.Text) && amenities.Length < 1)
            {
                toReturn = allHomes;
                Response.Write(jsonRes);
            }
            else
            {
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
                        Response.Write(h.Address + "<br>");
                    }
                }
            }
            return toReturn;
        }
    }
}