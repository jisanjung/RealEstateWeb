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
    public partial class frmSellerHomes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // List<Home> sellerHomes = this.staticallyGenerateHomes();
            List<Home> sellerHomes = DBOperations.GetSellerHomes("kevin@gmail.com");

            if (!IsPostBack)
            {
                this.displayHomes(sellerHomes);
            }
        }
        protected void btn_EditHome(object sender, CommandEventArgs e)
        {
            int rowClicked = int.Parse(e.CommandArgument.ToString());
            Label lblHomeId = (Label)rptSellerHomes.Items[rowClicked].FindControl("lblHomeId");
            int homeId = int.Parse(lblHomeId.Text);

            this.divEditHome.Visible = true;

            string jsonRes = RestClient.Get("http://localhost:60855/api/homes/" + homeId);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Home selectedHome = js.Deserialize<Home>(jsonRes);

            //foreach (Home h in this.staticallyGenerateHomes())
            //{
            //    if (h.HomeId == homeId)
            //    {
            //        selectedHome = h;
            //    }
            //}
            this.lblSelectedId.Text = selectedHome.HomeId.ToString();
            this.txtChangePrice.Text = selectedHome.Price.ToString();
            this.txtChangeStatus.Text = selectedHome.Status;
            this.taChangeDescription.Value = selectedHome.Description;
        }
        private void displayHomes(List<Home> homeList)
        {
            this.rptSellerHomes.DataSource = homeList;
            this.rptSellerHomes.DataBind();
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
            h1.Status = "sold";
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
            h2.Status = "sold";
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
            h3.Status = "sale";

            allHomes.Add(h1);
            allHomes.Add(h2);
            allHomes.Add(h3);

            return allHomes;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int homeId = int.Parse(this.lblSelectedId.Text);

            string jsonRes = RestClient.Get("http://localhost:60855/api/homes/" + homeId);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Home editedHome = js.Deserialize<Home>(jsonRes);

            editedHome.Price = int.Parse(this.txtChangePrice.Text);
            editedHome.Status = this.txtChangeStatus.Text;
            editedHome.Description = this.taChangeDescription.Value;

            if (this.fuChangeImage.HasFile)
            {
                string filename = this.fuChangeImage.FileName;
                this.fuChangeImage.PostedFile.SaveAs(Server.MapPath($"~/Storage/{filename}"));
                editedHome.Img = this.fuChangeImage.FileName;
            }

            String jsonHome = js.Serialize(editedHome);
            int status = int.Parse(RestClient.Put("http://localhost:60855/api/homes/Edit", jsonHome));
            
            if (status < 1)
            {
                this.lblAlert.Text = "Could not save home...";
            } else
            {
                this.lblAlert.Text = "Saved successfully";

                List<Home> sellerHomes = DBOperations.GetSellerHomes("kevin@gmail.com");
                this.displayHomes(sellerHomes);
                this.divEditHome.Visible = false;
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int homeId = int.Parse(this.lblSelectedId.Text);
            int status = int.Parse(RestClient.Delete("http://localhost:60855/api/homes/Remove/" + homeId));

            if (status < 1)
            {
                this.lblAlert.Text = "Could not delete home...";
            }
            else
            {
                this.lblAlert.Text = "Deleted successfully";

                List<Home> sellerHomes = DBOperations.GetSellerHomes("kevin@gmail.com");
                this.displayHomes(sellerHomes);
                this.divEditHome.Visible = false;
            }
        }
    }
}