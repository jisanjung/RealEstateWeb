﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateWeb
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        HttpCookie loginCookie;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                string userType = Request.Cookies["user_cookie"]["user_type"];
                
                if (userType.CompareTo("Agent") == 0)
                {
                    // agent user
                    this.agentLinks.Visible = true;
                    this.sellerLinks.Visible = false;
                    this.buyerLinks.Visible = false;

                } else if (userType.CompareTo("Seller") == 0)
                {
                    // seller user
                    this.sellerLinks.Visible = true;
                    this.agentLinks.Visible = false;
                    this.buyerLinks.Visible = false;

                } else if (userType.CompareTo("Buyer") == 0)
                {
                    // buyer user
                    this.buyerLinks.Visible = true;
                    this.agentLinks.Visible = false;
                    this.sellerLinks.Visible = false;
                }
            }
        }
    }
}