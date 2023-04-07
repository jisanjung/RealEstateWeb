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
        DBConnect connection = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Room> rooms = new List<Room>();
                ViewState["rooms"] = rooms;
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
            // make a home
            Home home = this.makeHomeFromInput();

            // serialize into json string
            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonHome = js.Serialize(home);

            // insert into db
            int status = int.Parse(RestClient.Post("http://localhost:60855/api/homes/Add", jsonHome));
            
            if (status < 1)
            {
                Response.Write("insert failed");
            } else
            {
                Response.Write("insert success");
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
            amenities = amenities.Substring(0, amenities.Length - 2);

            home.OtherAmenities = amenities;
            home.Img = this.fuHomeImg.FileName;
            home.ImgCaption = this.txtImgCaption.Text;
            home.Status = "sale";

            return home;
        }
    }
}