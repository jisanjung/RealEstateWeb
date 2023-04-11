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

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text)
                && !string.IsNullOrEmpty(txtPassword.Text)
                && !string.IsNullOrEmpty(txtFullName.Text)
                && !string.IsNullOrEmpty(txtCurrAddress.Text)
                && !string.IsNullOrEmpty(txtSecureQuestion1.Text)
                && !string.IsNullOrEmpty(txtSecureQuestion2.Text)
                && !string.IsNullOrEmpty(txtSecureQuestion3.Text)
                && !string.IsNullOrEmpty(ddlType.SelectedValue.ToString())
                )
            {
                Email objEmail = new Email();
                String strTO = txtEmail.Text;
                String strFROM = "homesrus@temple.edu";
                String strSubject = "Verify Account";

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
                }
                DataSet myds = objDB.GetDataSetUsingCmdObj(objCommand);

                HttpCookie myCookie = new HttpCookie("user_cookie");
                myCookie.Values["user_email"] = txtEmailLogin.Text;
                myCookie.Values["user_type"] = ddlType.SelectedValue;

                if (chkRememberSignup.Checked)
                {
                    myCookie.Expires = DateTime.Now.AddYears(1000);
                }

                Response.Redirect("frmDashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_Login";

            if (!string.IsNullOrEmpty(txtEmailLogin.Text) && !string.IsNullOrEmpty(txtPasswordLogin.Text))
            {

                SqlParameter emailParam = ExtraUtil.CreateParamVarChar(txtEmailLogin.Text, "email", 100);
                SqlParameter passwordParam = ExtraUtil.CreateParamVarChar(txtPasswordLogin.Text, "password", 100);

                objCommand.Parameters.Add(emailParam);
                objCommand.Parameters.Add(passwordParam);

                DataSet myds = objDB.GetDataSetUsingCmdObj(objCommand);

                try
                {
                    string dbReturnedEmail = myds.Tables[0].Rows[0][1].ToString();
                    string dbReturnedType = myds.Tables[0].Rows[0][4].ToString();

                    //no need to check the password because the SP checks already and if they do not match then null is returned
                    if (dbReturnedEmail.Equals(txtEmailLogin.Text))
                    {
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

                }
                catch (Exception ex)
                {
                    lblError.Text = "Fix username or password; account might not exist";
                    objCommand.Parameters.Clear();
                    objCommand.CommandText = " ";
                }

            }
            else
            {
                lblError.Text = "Account not found, please double check all your information";
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

                    string body = "your password is: " + myds.Tables[0].Rows[0][0].ToString();
                    lblError.Text = "Verification code has been sent. Check your Email.";
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
    }
}
    