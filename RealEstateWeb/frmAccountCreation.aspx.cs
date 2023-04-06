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
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace RealEstateWeb
{
    public partial class frmAccountCreation : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        public static int rand;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            if(    !string.IsNullOrEmpty(txtEmail.Text)
                && !string.IsNullOrEmpty(txtPassword.Text)
                && !string.IsNullOrEmpty(txtFullName.Text)
                && !string.IsNullOrEmpty(txtCurrAddress.Text)
                && !string.IsNullOrEmpty(txtSecureQuestion1.Text)
                && !string.IsNullOrEmpty(txtSecureQuestion2.Text)
                && !string.IsNullOrEmpty(txtSecureQuestion3.Text)
                && !string.IsNullOrEmpty(ddlType.SelectedValue.ToString())
                )
            {
                //Response.Redirect("frmMain.aspx");
                Email objEmail = new Email();
                String strTO = txtEmail.Text;
                String strFROM = "homesrus@temple.edu";
                String strSubject = "Verify Account";

                
                    //lblDisplay.Text = "The email was sent.";
                try
                {
                    rand = RandomNumber.randInt();
                    lblError.Text = "Verification code has been sent. Check your Email.";
                    objEmail.SendMail(strTO, strFROM, strSubject, rand.ToString());

                }
                catch (Exception ex) 
                { 
                    lblError.Text = ex.Message;
                }
            }
            else
            {
                lblError.Text = "Email already exists or there are some missing requirements";
            }
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_Signup";
            if (int.Parse(txtVerification.Text) == rand)
            {
                SqlParameter emailParam = ExtraUtil.CreateParamVarChar(txtEmail.Text, "tp_email", 100);
                SqlParameter fullnameparam = ExtraUtil.CreateParamVarChar(txtFullName.Text, "tp_fullname", 100);
                SqlParameter passwordparam = ExtraUtil.CreateParamVarChar(txtPassword.Text, "tp_password", 100);
                SqlParameter typeparam = ExtraUtil.CreateParamVarChar(ddlType.SelectedValue.ToString(), "tp_type", 100);
                SqlParameter addressparam = ExtraUtil.CreateParamVarChar(txtCurrAddress.Text, "tp_address", 100);
                SqlParameter answeroneparam = ExtraUtil.CreateParamVarChar(txtSecureQuestion1.Text, "tp_answerone", 100);
                SqlParameter answertwoparam = ExtraUtil.CreateParamVarChar(txtSecureQuestion2.Text, "tp_answertwo", 100);
                SqlParameter answerthreeparam = ExtraUtil.CreateParamVarChar(txtSecureQuestion3.Text, "tp_answerthree", 100);

                objCommand.Parameters.Add(emailParam);
                objCommand.Parameters.Add(passwordparam);
                objCommand.Parameters.Add(fullnameparam);
                objCommand.Parameters.Add(typeparam);
                objCommand.Parameters.Add(addressparam);
                objCommand.Parameters.Add(answeroneparam);
                objCommand.Parameters.Add(answertwoparam);
                objCommand.Parameters.Add(answerthreeparam);

                DataSet myds = objDB.GetDataSetUsingCmdObj(objCommand);

                Response.Redirect("frmMain.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_Login";

            if (!string.IsNullOrEmpty(txtEmailLogin.Text) && !string.IsNullOrEmpty(txtPasswordLogin.Text))
            {
                SqlParameter emailParam = ExtraUtil.CreateParamVarChar(txtEmailLogin.Text, "tp_username", 100);
                SqlParameter passwordParam = ExtraUtil.CreateParamVarChar(txtPasswordLogin.Text, "tp_password", 100);

                objCommand.Parameters.Add(emailParam);
                objCommand.Parameters.Add(passwordParam);

                DataSet myds = objDB.GetDataSetUsingCmdObj(objCommand);

                try
                {
                    string tempStr = myds.Tables[0].Rows[0][0].ToString();
                    //no need to check the password because the SP checks already and if they do not match then null is returned
                    if (tempStr.Equals(txtEmailLogin.Text))
                    {
                        HttpCookie myCookie = new HttpCookie("LoginCookie");
                        myCookie.Values["user_email"] = txtEmailLogin.Text;

                        Response.Cookies.Add(myCookie);
                        Response.Redirect("frmMain.aspx");

                        lblError.Text = tempStr;
                    }
                }
                catch (Exception ex)
                {
                    //lblError.Text = "Fix username or password; account might also just not exist";
                    objCommand.Parameters.Clear();
                    objCommand.CommandText = " ";
                }

                
            }
            else
            {
                lblError.Text = "Account not found, please double check all your information";
            }
            
        }
    }
}
    