using HomeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HomeLibrary;

namespace RealEstateWeb
{
    public partial class frmDashboard : System.Web.UI.Page
    {
        HttpCookie loginCookie;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("frmAccountCreation.aspx");
            }
            else
            {
                loginCookie = Request.Cookies["user_cookie"];
            }

            if(loginCookie.Values["user_type"].Equals("Buyer"))
            {
                agentSellerSpecific.Visible = false;
                buyerSpecific.Visible = true;
            }
            else
            {
                agentSellerSpecific.Visible = true;
                buyerSpecific.Visible = false;
            }

            User user = DBOperations.GetUser(Request.Cookies["user_cookie"].Values["user_email"]);


            lblAddress.Text = user.Address;
            lblFullName.Text = user.FullName;
            lblPassword.Text = user.Password;
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (btnModify.Text.Equals("Edit"))
            {
                btnModify.Text = "Save";
                lblAddress.Visible = false;
                lblFullName.Visible = false;
                lblPassword.Visible = false;
                txtPassword.Visible = true;
                txtFullName.Visible = true;
                txtAddress.Visible = true;
            }
            else
            {
                btnModify.Text = "Edit";
                txtAddress.Visible = false;
                txtFullName.Visible = false;
                txtPassword.Visible = false;
                lblAddress.Visible = true;
                lblFullName.Visible = true;
                lblPassword.Visible = true;
            }
        }
    }
}