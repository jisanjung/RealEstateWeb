using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

using Utilities;
using HomeLibrary;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Net;

namespace RealEstateWeb
{
    public partial class frmAccountCreation : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        public static int rand;

        protected void Page_Load(object sender, EventArgs e)
        {
            // take user straight to their dashboard if they already have a cookie stored
            if (Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("frmDashboard.aspx");
            }
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            bool accountAlreadyExists = false;
            foreach (User u in DBOperations.GetAllUsers())
            {
                if (u.Email.CompareTo(txtEmail.Text) == 0)
                {
                    accountAlreadyExists = true;
                    this.lblError.Text = "Account already exists";
                    this.lblError.CssClass = "alert alert-danger d-inline-block";
                }
            }
            if (!accountAlreadyExists)
            {
                this.divVerify.Visible = true;

                // account doesn't exist yet
                Email objEmail = new Email();
                String strTO = txtEmail.Text;
                String strFROM = "homesrus@temple.edu";
                String strSubject = "Verify Account";
                try
                {
                    rand = RandomNumber.randInt();
                    lblError.Text = "Verification code has been sent. Check your Email.";
                    this.lblError.CssClass = "alert alert-primary d-inline-block";
                    objEmail.SendMail(strTO, strFROM, strSubject, rand.ToString());
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    this.lblError.CssClass = "alert alert-danger d-inline-block";
                }
            }
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtVerification.Text) == rand)
            {
                User newUser = new User();
                newUser.Email = txtEmail.Text;
                newUser.FullName = txtFullName.Text;
                newUser.Password = Security.Encrypt(txtPassword.Text);
                newUser.Type = ddlType.SelectedValue;
                newUser.Address = txtCurrAddress.Text;
                newUser.SecurityAnswerOne = txtSecureQuestion1.Text;
                newUser.SecurityAnswerTwo = txtSecureQuestion2.Text;
                newUser.SecurityAnswerThree = txtSecureQuestion3.Text;
                newUser.IsVerified = true;
                int status = DBOperations.AddUser(newUser);

                if (status < 1)
                {
                    lblError.Text = "There was an issue creating your account";
                    this.lblError.CssClass = "alert alert-danger d-inline-block";

                }
                else
                {
                    lblError.Text = "Account created!";
                    HttpCookie myCookie = new HttpCookie("user_cookie");
                    myCookie.Values["user_email"] = txtEmail.Text;
                    myCookie.Values["user_type"] = ddlType.SelectedValue;

                    if (chkRememberSignup.Checked)
                    {
                        myCookie.Expires = DateTime.Now.AddYears(1000);
                    }

                    Response.Cookies.Add(myCookie);
                    Response.Redirect("frmDashboard.aspx");

                }
            } else
            {
                this.lblError.Text = "Incorrect verification code";
                this.lblError.CssClass = "alert alert-danger d-inline-block";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool accountExists = false;
            foreach (User u in DBOperations.GetAllUsers())
            {
                if (u.Email.CompareTo(txtEmailLogin.Text) == 0)
                {
                    // account exists
                    accountExists = true;
                    string dbReturnedEmail = u.Email;
                    string dbReturnedPassword = Security.Decrypt(u.Password);
                    string dbReturnedType = u.Type;

                    if (dbReturnedPassword.CompareTo(txtPasswordLogin.Text) == 0)
                    {
                        // account exists, password is correct
                        HttpCookie myCookie = new HttpCookie("user_cookie");
                        myCookie.Values["user_email"] = dbReturnedEmail;
                        myCookie.Values["user_type"] = dbReturnedType;

                        if (chkRememberLogin.Checked)
                        {
                            myCookie.Expires = DateTime.Now.AddYears(1000);
                        }

                        Response.Cookies.Add(myCookie);
                        Response.Redirect("frmDashboard.aspx");
                    }
                    else
                    {
                        // account exists, password is incorrect
                        this.lblError.Text = "Password is incorrect";
                        this.lblError.CssClass = "alert alert-danger d-inline-block";
                    }
                }
            }
            if (!accountExists)
            {
                this.lblError.Text = "Account does not exist";
                this.lblError.CssClass = "alert alert-danger d-inline-block";
            }
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            DataSet myds;
            SqlParameter answerParam = ExtraUtil.CreateParamVarChar(txtForgotAnswer.Text, "answer", 100);
            objCommand.Parameters.Add(answerParam);
            SqlParameter emailParam = ExtraUtil.CreateParamVarChar(txtForgotEmail.Text, "email", 100);
            objCommand.Parameters.Add(emailParam);
            bool flag = true;
            string mydstring;

            try
            {
                if(resultInt == 1) //maidenname
                {
                    objCommand.CommandText = "TP_QuestionOne";
                    
                    myds = objDB.GetDataSetUsingCmdObj(objCommand);

                    if (!myds.Tables[0].Rows[0][0].ToString().Equals(txtForgotAnswer.Text))
                    {
                        flag = false;
                        
                    }
                    objCommand.Parameters.Clear();
                    System.Diagnostics.Debug.WriteLine(myds.Tables[0].Rows[0][0].ToString());
                    mydstring = myds.Tables[0].Rows[0][0].ToString();
                }
                else if(resultInt == 2) //university
                {
                    objCommand.CommandText = "TP_QuestionTwo";
                    myds = objDB.GetDataSetUsingCmdObj(objCommand);

                    if (!myds.Tables[0].Rows[0][0].ToString().Equals(txtForgotAnswer.Text))
                    {
                        flag = false;
                    }
                    objCommand.Parameters.Clear();
                    System.Diagnostics.Debug.WriteLine(myds.Tables[0].Rows[0][0].ToString());
                    mydstring = myds.Tables[0].Rows[0][0].ToString();
                }
                else //pizza
                {
                    objCommand.CommandText = "TP_QuestionThree";
                    myds = objDB.GetDataSetUsingCmdObj(objCommand);

                    if (!myds.Tables[0].Rows[0][0].ToString().Equals(txtForgotAnswer.Text))
                    {
                        flag = false;
                    }
                    objCommand.Parameters.Clear();
                    System.Diagnostics.Debug.WriteLine(myds.Tables[0].Rows[0][0].ToString());
                    mydstring = myds.Tables[0].Rows[0][0].ToString();

                }

                if (flag)
                {
                    objCommand.CommandText = "TP_Forgot";

                    //lblError.Text = flag + " is true! " + mydstring;

                    objCommand.Parameters.Add(emailParam);
                    myds = objDB.GetDataSetUsingCmdObj(objCommand);

                    Email objEmail = new Email();
                    String strTO = txtForgotEmail.Text;
                    String strFROM = "homesrus@temple.edu";
                    String strSubject = "Homes R Us - Forgot password";

                    string body = "your password is: " + Security.Decrypt(myds.Tables[0].Rows[0][0].ToString());
                    lblError.Text = "Password has been sent to your email. Check your Email.";
                    this.lblError.CssClass = "alert alert-primary d-inline-block";
                    objEmail.SendMail(strTO, strFROM, strSubject, body);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message + " ";
                objCommand.Parameters.Clear();
                txtForgotAnswer.Text = "";
                txtForgotEmail.Text = "";
            }
        }

        static string[,] arr = { {"What is your mother's maiden name?", "1" }, { "What University did/do you attend?", "2" }, { "What is your favorite food?", "3" } };
        static int resultInt;
        protected void linkForgotPassword_Click(object sender, EventArgs e)
        {
            forgotFun.Visible = true;
            int rnd = RandomNumber.randSmallInt();
            string resultStr = arr[rnd, 0];
            resultInt = int.Parse(arr[rnd, 1]);
            lblForgot.Text = resultStr;

        }

        protected void linkbtnCreateAccount_Click(object sender, EventArgs e)
        {
            this.divSignup.Visible = true;
            this.divLogin.Visible = false;

            this.divOpenSignup.Visible = false;
            this.divOpenLogin.Visible = true;
        }

        protected void linkbtnLogin_Click(object sender, EventArgs e)
        {
            this.divSignup.Visible = false;
            this.divLogin.Visible = true;

            this.divOpenSignup.Visible = true;
            this.divOpenLogin.Visible = false;
        }
    }
}
    