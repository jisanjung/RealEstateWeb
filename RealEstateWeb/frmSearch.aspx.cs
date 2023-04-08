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
                string jsonRes = RestClient.Get("http://localhost:60855/api/homes");
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<Home> allHomes = js.Deserialize<List<Home>>(jsonRes);

                this.rptHomeResults.DataSource = allHomes;
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