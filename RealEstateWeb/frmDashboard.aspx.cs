using HomeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RealEstateWeb
{
    public partial class frmDashboard : System.Web.UI.Page
    {
        HttpCookie loginCookie;
        User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("frmAccountCreation.aspx");
            }
            else
            {
                loginCookie = Request.Cookies["user_cookie"];
                string userEmail = Request.Cookies["user_cookie"]["user_email"];
                User user = DBOperations.GetUser(userEmail);

                this.lblWelcomeText.Text = $"Welcome, {user.FullName}";
            }

            if (loginCookie.Values["user_type"].Equals("Buyer"))
            {
                agentSellerSpecific.Visible = false;
                buyerSpecific.Visible = true;
            }
            else
            {
                agentSellerSpecific.Visible = true;
                buyerSpecific.Visible = false;
            }

            user = DBOperations.GetUser(Request.Cookies["user_cookie"].Values["user_email"]);


            lblAddress.Text = user.Address;
            lblFullName.Text = user.FullName;
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            this.txtFullName.Text = user.FullName;
            this.txtAddress.Text = user.Address;

            this.ulUserInfo.Visible = false;
            this.divModifyInputs.Visible = true;

            this.btnModify.Visible = false;
            this.btnSave.Visible = true;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            user.Address = txtAddress.Text;
            user.FullName = txtFullName.Text;

            DBOperations.UpdateUserInfo(user);

            lblAddress.Text = user.Address;
            lblFullName.Text= user.FullName;

            this.ulUserInfo.Visible = true;
            this.divModifyInputs.Visible = false;

            this.btnModify.Visible = true;
            this.btnSave.Visible = false;
        }
    }
}