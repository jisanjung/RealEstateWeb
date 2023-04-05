using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

using Utilities;
using System.Globalization;

namespace RealEstateWeb
{
    public partial class frmAccountCreation : System.Web.UI.Page
    {
        public int rand;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            rand = RandomNumber.randInt();
                        
            //rand = rnd.Num;
            lblError.Text = rand.ToString();
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblError.Text) == int.Parse(txtVerification.Text))
            {
                lblError.Text = "correct!";
            }
            else
            {
                lblError.Text = rand.ToString();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmMain.aspx");
        }
    }
}
    