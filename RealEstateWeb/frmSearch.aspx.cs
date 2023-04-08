using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateWeb
{
    public partial class frmSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int zipCode = int.Parse(this.txtZipCode.Text);
            int price = int.Parse(this.txtPriceRange.Text);
            string proprtyType = this.ddlPropertyType.SelectedValue;
            int houseSize = int.Parse(this.txtHomeSize.Text);
            int numOfBedrooms = int.Parse(this.txtMinBedrooms.Text);
            int numOfBathrooms = int.Parse(this.txtMinBathrooms.Text);

            string amenities = "";
            foreach (ListItem item in this.cblAmenities.Items)
            {
                if (item.Selected)
                {
                    amenities += $"{item.Value}, ";
                }
            }
            amenities = amenities.Substring(0, amenities.Length - 2);
            
        }
    }
}