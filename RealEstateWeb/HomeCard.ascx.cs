﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateWeb
{
    public partial class HomeCard : System.Web.UI.UserControl
    {
        public string Address { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblAddress.Text = Address;
        }
    }
}