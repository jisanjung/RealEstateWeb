using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using HomeLibrary;
using Utilities;

namespace RealEstateWeb
{
    public partial class frmSellerHomes : System.Web.UI.Page
    {
        HttpCookie loginCookie;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                string userName = Request.Cookies["user_cookie"]["user_email"];
                string userType = Request.Cookies["user_cookie"]["user_type"];
                
                if (userType.CompareTo("Buyer") == 0)
                {
                    Response.Redirect("frmErrorPage.aspx");
                } else
                {
                    List<Home> sellerHomes = DBOperations.GetSellerHomes(userName);
                    if (!IsPostBack)
                    {
                        this.displayHomes(sellerHomes);
                    }
                }
            }
            else
            {
                Response.Redirect("frmAccountCreation.aspx");
            }
        }
        protected void btn_EditHome(object sender, CommandEventArgs e)
        {
            int rowClicked = int.Parse(e.CommandArgument.ToString());
            Label lblHomeId = (Label)rptSellerHomes.Items[rowClicked].FindControl("lblHomeId");
            int homeId = int.Parse(lblHomeId.Text);

            this.divEditHome.Visible = true;

            string jsonRes = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebAPI/api/homes/" + homeId);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Home selectedHome = js.Deserialize<Home>(jsonRes);

            this.lblSelectedId.Text = selectedHome.HomeId.ToString();
            this.txtChangePrice.Text = selectedHome.Price.ToString();
            this.txtChangeStatus.Text = selectedHome.Status;
            this.taChangeDescription.Value = selectedHome.Description;
        }
        protected void btn_ShowingRequests(object sender, CommandEventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                int rowClicked = int.Parse(e.CommandArgument.ToString());
                Label lblHomeId = (Label)rptSellerHomes.Items[rowClicked].FindControl("lblHomeId");
                int homeId = int.Parse(lblHomeId.Text);

                string jsonHome = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebAPI/api/homes/" + homeId);
                JavaScriptSerializer js = new JavaScriptSerializer();
                Home selectedHome = js.Deserialize<Home>(jsonHome);

                this.divHomeShowingResults.Visible = true;

                this.lblHomeShowingsTitle.Text = $"Requests for {selectedHome.Address}";

                string jsonShowings = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebAPI/api/homeshowing/");
                List<HomeShowing> allHomeShowings = js.Deserialize<List<HomeShowing>>(jsonShowings);

                string userName = Request.Cookies["user_cookie"]["user_email"];

                string homeShowingHTML = "";
                foreach (HomeShowing hs in allHomeShowings)
                {
                    if (hs.HomeId == homeId && hs.SellerEmail.CompareTo(userName) == 0)
                    {
                        homeShowingHTML += this.generateHomeShowingHTML(hs);
                    }
                }
                this.ulHomeShowingList.InnerHtml = homeShowingHTML;
            }
        }
        protected void btn_ViewFeedback(object sender, CommandEventArgs e)
        {
            int rowClicked = int.Parse(e.CommandArgument.ToString());
            Label lblHomeId = (Label)rptSellerHomes.Items[rowClicked].FindControl("lblHomeId");
            int homeId = int.Parse(lblHomeId.Text);

            string jsonHome = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebAPI/api/homes/" + homeId);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Home selectedHome = js.Deserialize<Home>(jsonHome);

            this.divFeedbackResults.Visible = true;
            this.lblFeedbackTitle.Text = $"Feedback for {selectedHome.Address}";

            FeedbackService.Feedback pxy = new FeedbackService.Feedback();
            DataSet ds = pxy.GetAllFeedbackForHome(homeId);
            DataTable dt = ds.Tables[0];

            List<HomeFeedback> feedback = new List<HomeFeedback>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HomeFeedback hf = new HomeFeedback();
                hf.FeedbackId = int.Parse(dt.Rows[i]["feedback_id"].ToString());
                hf.HomeId = int.Parse(dt.Rows[i]["home_id"].ToString());
                hf.PriceFeedback = dt.Rows[i]["price_feedback"].ToString();
                hf.LocationFeedback = dt.Rows[i]["location_feedback"].ToString();
                hf.OverallFeedback = dt.Rows[i]["overall_feedback"].ToString();
                hf.Rating = int.Parse(dt.Rows[i]["rating"].ToString());
                feedback.Add(hf);
            }
            string feedbackHTML = "";
            foreach (HomeFeedback hf in feedback)
            {
                feedbackHTML += this.generateFeedbackHTML(hf);
            }
            this.ulFeedback.InnerHtml = feedbackHTML;
        }
        private void displayHomes(List<Home> homeList)
        {
            this.rptSellerHomes.DataSource = homeList;
            this.rptSellerHomes.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int homeId = int.Parse(this.lblSelectedId.Text);

            string jsonRes = RestClient.Get("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebAPI/api/homes/" + homeId);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Home editedHome = js.Deserialize<Home>(jsonRes);

            editedHome.Price = int.Parse(this.txtChangePrice.Text);
            editedHome.Status = this.txtChangeStatus.Text;
            editedHome.Description = this.taChangeDescription.Value;

            if (this.fuChangeImage.HasFile)
            {
                string filename = this.fuChangeImage.FileName;
                this.fuChangeImage.PostedFile.SaveAs(Server.MapPath($"~/Storage/{filename}"));
                editedHome.Img = this.fuChangeImage.FileName;
            }

            String jsonHome = js.Serialize(editedHome);
            int status = int.Parse(RestClient.Put("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebAPI/api/homes/Edit", jsonHome));

            if (status < 1)
            {
                this.lblEditHomeAlert.Text = "Could not save home...";
                this.lblEditHomeAlert.CssClass = "alert alert-danger d-inline-block mt-3 w-100";
            }
            else
            {
                this.lblEditHomeAlert.Text = "Saved successfully";
                this.lblEditHomeAlert.CssClass = "alert alert-success d-inline-block mt-3 w-100";

                if (Request.Cookies["user_cookie"] != null)
                {
                    string username = Request.Cookies["user_cookie"]["user_email"];
                    List<Home> sellerHomes = DBOperations.GetSellerHomes(username);
                    this.displayHomes(sellerHomes);
                    this.divEditHome.Visible = false;
                }
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int homeId = int.Parse(this.lblSelectedId.Text);
            int status = int.Parse(RestClient.Delete("https://cis-iis2.temple.edu/Spring2023/CIS3342_tun22982/WebAPI/api/homes/Remove/" + homeId));

            if (status < 1)
            {
                this.lblEditHomeAlert.Text = "Could not delete home...";
                this.lblEditHomeAlert.CssClass = "alert alert-danger d-inline-block mt-3 w-100";
            }
            else
            {
                this.lblEditHomeAlert.Text = "Deleted successfully";
                this.lblEditHomeAlert.CssClass = "alert alert-success d-inline-block mt-3 w-100";

                if (Request.Cookies["user_cookie"] != null)
                {
                    string username = Request.Cookies["user_cookie"]["user_email"];
                    List<Home> sellerHomes = DBOperations.GetSellerHomes(username);
                    this.displayHomes(sellerHomes);
                    this.divEditHome.Visible = false;
                }
            }
        }
        private string generateHomeShowingHTML(HomeShowing hs)
        {
            User buyer = DBOperations.GetUser(hs.BuyerEmail);
            string htmlStr =
                $"<li class='list-group-item'>" +
                $"<div>{buyer.FullName} has scheduled a home showing on <span class='fw-bold'>{hs.Date}</span> at <span class='fw-bold'>{hs.Time}</span></div>" +
                $"<div>Contact the buyer via email at <a href='mailto:{buyer.Email}'>{buyer.Email}</a></div>" +
                $"</li>";
            return htmlStr;
        }
        private string generateFeedbackHTML(HomeFeedback hf)
        {
            string actualRating = "";
            string totalRating = "";
            for (int i = 0; i < hf.Rating; i++)
            {
                actualRating += "<i class='bi-star-fill'></i>";
            }
            for (int i = 0; i < 5 - hf.Rating; i++)
            {
                totalRating += "<i class='bi-star'></i>";
            }
            string htmlStr =
                $"<li class='list-group-item'>" +
                $"<div>{actualRating + totalRating}</div>" +
                $"<div>Feedback on price: <span class='text-secondary'>{hf.PriceFeedback}</span></div>" +
                $"<div>Feedback on location: <span class='text-secondary'>{hf.LocationFeedback}</span></div>" +
                $"<div>Overall feedback: <span class='text-secondary'>{hf.OverallFeedback}</span></div>" +
                $"</li>";
            return htmlStr;
        }

        protected void linkbtnClose_Click(object sender, EventArgs e)
        {
            this.divEditHome.Visible = false;
        }

        protected void linkbtnCloseHomeShowing_Click(object sender, EventArgs e)
        {
            this.divHomeShowingResults.Visible = false;
        }

        protected void linkbtnCloseFeedback_Click(object sender, EventArgs e)
        {
            this.divFeedbackResults.Visible = false;
        }
    }
}