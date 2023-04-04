using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace RealEstateWeb
{
    public class Email
    {
        private MailMessage objMail = new MailMessage();
        private MailAddress toAddress;
        private MailAddress fromAddress;
        private MailAddress ccAddress;
        private MailAddress bccAddress;
        private String subject;
        private String messageBody;
        private Boolean isHTMLBody = true;
        private MailPriority priority = MailPriority.Normal;
        private String mailHost = "smtp.temple.edu";
        public Email() { }

        public void SendMail(String recipient, String sender, String subject, String body, String cc = "", String bcc = "")
        {
            try
            {
                this.Recipient = recipient;
                this.Sender = sender;
                this.Subject = subject;
                this.Message = body;

                objMail.To.Add(this.toAddress);
                objMail.From = this.fromAddress;
                objMail.Subject = this.subject;
                objMail.Body = this.messageBody;
                objMail.IsBodyHtml = this.isHTMLBody;
                objMail.Priority = this.priority;

                if (cc != null && !cc.Equals(String.Empty))
                {
                    this.CCAddress = cc;
                    objMail.CC.Add(this.ccAddress);
                }

                if (bcc != null && !bcc.Equals(String.Empty))
                {
                    this.BCCAddress = bcc;
                    objMail.Bcc.Add(this.bccAddress);
                }

                SmtpClient smtpMailClient = new SmtpClient(this.mailHost);
                smtpMailClient.Send(objMail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String Recipient
        {
            get { return this.toAddress.ToString(); }
            set { this.toAddress = new MailAddress(value); }
        }
        public String Sender
        {
            get { return this.fromAddress.ToString(); }
            set { this.fromAddress = new MailAddress(value); }
        }
        public String CCAddress
        {
            get { return this.ccAddress.ToString(); }
            set { this.ccAddress = new MailAddress(value); }
        }
        public String BCCAddress
        {
            get { return this.bccAddress.ToString(); }
            set { this.bccAddress = new MailAddress(value); }
        }
        public String Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }
        public String Message
        {
            get { return this.messageBody; }
            set { this.messageBody = value; }
        }
        public Boolean HTMLBody
        {
            get { return this.isHTMLBody; }
            set { this.isHTMLBody = value; }
        }
        public MailPriority Priority
        {
            get { return this.priority; }
            set { this.priority = value; }
        }
        public String MailHost
        {
            get { return this.mailHost; }
            set { this.mailHost = value; }
        }
    }
    public partial class frmAccountCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmMain.aspx");
        }

        public int rand;
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            rand = rnd.Next(100000, 999999);

            Email objEmail = new Email();
            String strTO = txtEmail.Text;
            String strFROM = "HomesRus@temple.edu";
            String strSubject = "Verify your Account";
            String strMessage = "your verification code is: " + rand.ToString();
            try
            {
                objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                lblError.Text = "The email was sent.";
            }
            catch (Exception ex)
            {
                lblError.Text = "The email wasn't sent because one of the required fields was missing. <br/>" + ex;
            }
            //Response.Redirect("frmMain.aspx");
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            if (rand == int.Parse(txtVerification.Text))
            {
                lblError.Text = "nice!";
            }
            else
            {
                lblError.Text = "hmm.. that's not right";
            }
        }
    }
}