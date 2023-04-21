﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

using HomeLibrary;
using Utilities;

namespace RealEstateWeb
{
    public partial class frmCreateHome : System.Web.UI.Page
    {
        HttpCookie loginCookie;
        DBConnect connection = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                if (!IsPostBack)
                {
                    List<Room> rooms = new List<Room>();
                    ViewState["rooms"] = rooms;
                }
                // display seller account creation if user type is agent
                string userType = Request.Cookies["user_cookie"]["user_type"];
                string userEmail = Request.Cookies["user_cookie"]["user_email"];
                if (userType.CompareTo("Agent") == 0)
                {
                    this.txtAgentEmail.Text = userEmail;
                    this.divCreateSellerAcc.Visible = true;
                    this.divAgentInfo.Visible = true;
                    this.pCreateSeller.Visible = true;
                } else
                {
                    this.txtAgentEmail.Text = userEmail;
                    this.txtSellerEmail.Text = userEmail;
                    this.divCreateSellerAcc.Visible = false;
                    this.divAgentInfo.Visible = false;
                    this.pCreateSeller.Visible = false;
                }

                // redirect a buyer trying to access
                if (userType.CompareTo("Buyer") == 0)
                {
                    Response.Redirect("frmErrorPage.aspx");
                }
            }
            else
            {
                Response.Redirect("frmAccountCreation.aspx");
            }
        }

        protected void linkbtnAddBedroom_Click(object sender, EventArgs e)
        {
            this.divBedroomDimensions.Visible = true;
        }

        protected void linkbtnAddBR_Click(object sender, EventArgs e)
        {
            this.divBRDimensions.Visible = true;
        }

        protected void linkbtnAddOtherRoom_Click(object sender, EventArgs e)
        {
            this.divOtherRoomDimensions.Visible = true;
        }

        protected void btnAddBedroom_Click(object sender, EventArgs e)
        {
            Room r = new Room("Bedroom", int.Parse(this.txtBedroomLength.Text), int.Parse(this.txtBedroomWidth.Text));
            List<Room> rooms = (List<Room>)ViewState["rooms"];
            rooms.Add(r);

            this.lblBedrooms.Text += $"<div>{r.RoomType}: {r.Length}ft x {r.Length}ft</div>";
            this.lblBedroomCount.Text = (int.Parse(this.lblBedroomCount.Text) + 1).ToString();

            this.divBedroomDimensions.Visible = false;
        }

        protected void btnAddBR_Click(object sender, EventArgs e)
        {
            Room r = new Room("Bathroom", int.Parse(this.txtBRLength.Text), int.Parse(this.txtBRWidth.Text));
            List<Room> rooms = (List<Room>)ViewState["rooms"];
            rooms.Add(r);

            this.lblBathrooms.Text = $"<div>{r.RoomType}: {r.Length}ft by {r.Width}ft</div>";
            this.lblBRCount.Text = (int.Parse(this.lblBRCount.Text) + 1).ToString();

            this.divBRDimensions.Visible = false;
        }

        protected void btnAddOtherRoom_Click(object sender, EventArgs e)
        {
            Room r = new Room(this.txtRoomName.Text, int.Parse(this.txtOtherRoomLength.Text), int.Parse(this.txtOtherRoomWidth.Text));
            List<Room> rooms = (List<Room>)ViewState["rooms"];
            rooms.Add(r);

            this.lblOtherRooms.Text += $"<div>{r.RoomType}: {r.Length}ft by {r.Width}ft</div>";
            this.lblOtherRoomsCount.Text = (int.Parse(this.lblOtherRoomsCount.Text) + 1).ToString();

            this.divOtherRoomDimensions.Visible = false;
        }

        protected void btnSubmitHome_Click(object sender, EventArgs e)
        {
            if (this.inputsAreValid())
            {
                // make a home
                Home home = this.makeHomeFromInput();
                // serialize into json string
                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonHome = js.Serialize(home);
                // insert into db
                int status = int.Parse(RestClient.Post("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebsAPITest/api/homes/Add", jsonHome));

                if (status < 1)
                {
                    this.lblAlert.Text = "There was a problem posting this home...";
                    this.lblAlert.CssClass = "alert alert-danger d-inline-block";
                }
                else
                {
                    this.lblAlert.Text = "Home posted successfully!";
                    this.createSellerAccount();
                    Response.Redirect("frmSellerHomes.aspx");
                }
            }
        }

        private Home makeHomeFromInput()
        {
            // get rooms from view state
            List<Room> rooms = (List<Room>)ViewState["rooms"];

            // make a home
            Home home = new Home();
            home.SellerEmail = this.txtSellerEmail.Text;
            home.Price = float.Parse(this.txtPrice.Text);
            home.Address = $"{this.txtStreetAddress.Text} {this.txtCity.Text}, {this.txtState.Text}";
            home.ZipCode = int.Parse(this.txtZip.Text);
            home.YearBuilt = int.Parse(this.txtYearBuilt.Text);
            home.PropertyType = this.ddlPropertyType.SelectedValue;

            // calculate the size of the house based on the sum of each rooms sqft
            int sum = 0;
            foreach (Room r in rooms)
            {
                sum += (r.Length * r.Width);
            }

            home.HouseSize = sum;
            home.NumberBed = int.Parse(this.lblBedroomCount.Text);
            home.NumberBath = int.Parse(this.lblBRCount.Text);
            home.Rooms = rooms;
            home.HVAC = this.ddlHVAC.SelectedValue;
            home.Garage = this.ddlGarage.SelectedValue;
            home.Utilities = $"{this.ddlWater.SelectedValue} and {this.ddlSewage.SelectedValue}";

            string amenities = "";
            foreach (ListItem item in this.cblAmenities.Items)
            {
                if (item.Selected)
                {
                    amenities += $"{item.Value}, ";
                }
            }
            amenities = String.IsNullOrEmpty(amenities) ? "None" : amenities.Substring(0, amenities.Length - 2);

            home.OtherAmenities = amenities;

            // add image local folder
            if (this.fuHomeImg.HasFile)
            {
                string filename = this.fuHomeImg.FileName;
                this.fuHomeImg.PostedFile.SaveAs(Server.MapPath($"~/Storage/{filename}"));
                home.Img = this.fuHomeImg.FileName;
            }
            home.ImgCaption = this.txtImgCaption.Text;
            home.Status = "Sale";
            home.Description = this.taHomeDescription.Value;
            home.CompanyName = String.IsNullOrEmpty(this.txtCompanyName.Text) ? "N/A" : this.txtCompanyName.Text;
            home.AgentEmail = String.IsNullOrEmpty(this.txtAgentEmail.Text) ? this.txtSellerEmail.Text : this.txtAgentEmail.Text;

            return home;
        }
        private void createSellerAccount() {
            if (Request.Cookies["user_cookie"] != null && Request.Cookies["user_cookie"]["user_type"].CompareTo("Agent") == 0)
            {
                User seller = new User();
                seller.Email = this.txtSellerEmail.Text;
                seller.Password = Security.Encrypt(this.sellerPassword.Value);
                seller.FullName = this.txtSellerName.Text;
                seller.Address = this.txtAddress.Text;
                seller.Type = "Seller";
                seller.SecurityAnswerOne = "N/A";
                seller.SecurityAnswerTwo = "N/A";
                seller.SecurityAnswerThree = "N/A";
                seller.IsVerified = false;

                int insertSellerStatus = DBOperations.AddUser(seller);

                if (insertSellerStatus < 1)
                {
                    this.lblCreateSellerAlert.Text = "Error creating a seller";
                    this.lblAlert.CssClass = "alert alert-danger d-inline-block";
                }
                else
                {
                    this.lblCreateSellerAlert.Text = "Created seller account successfully";
                }
            }
        }
        private bool inputsAreValid()
        {
            bool toReturn = true;

            int value;
            string errorText = "";
            if (!int.TryParse(this.txtZip.Text, out value))
            {
                toReturn = false;
                errorText += "Zip code must be a number, ";
            }
            if (!int.TryParse(this.txtYearBuilt.Text, out value))
            {
                toReturn = false;
                errorText += "Year built must be a number, ";
            }
            if (!int.TryParse(this.txtPrice.Text, out value))
            {
                toReturn = false;
                errorText += "Price must be a number, ";
            }

            errorText = String.IsNullOrEmpty(errorText) ? "" : errorText.Substring(0, errorText.Length - 2);
            this.lblAlert.Text = errorText;
            this.lblAlert.CssClass = "alert alert-danger d-inline-block";

            return toReturn;
        }
    }
}