using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateWeb
{
    public partial class HomeCard : System.Web.UI.UserControl
    {
        public float Price { get; set; }
        public string Address { get; set; }
        public int HouseSize { get; set; }
        public float NumberBeds { get; set; }
        public float NumberBaths { get; set; }
        public string Img { get; set; }
        public int ZipCode { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblPrice.Text = Price.ToString("C");
            this.lblAddress.Text = $"{Address} {ZipCode}";
            this.lblSize.Text = $"{HouseSize} sqft";
            this.lblBed.Text = $"{NumberBeds} beds";
            this.lblBath.Text = $"{NumberBaths} bathrooms";
            this.imgHome.Src = $"~/Storage/{Img}";
        }
    }
}