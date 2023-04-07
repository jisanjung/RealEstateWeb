using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HomeLibrary;

namespace RealEstateWeb
{
    public partial class frmCreateHome : System.Web.UI.Page
    {
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
            int sum = 0;
            List<Room> rooms = (List<Room>)ViewState["rooms"];
            foreach (Room r in rooms)
            {
                sum += (r.Length * r.Width);
            }
            Response.Write($"house size: {sum}sqft");
        }
    }
}