using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

using Utilities;
using HomeLibrary;

namespace WebService
{
    /// <summary>
    /// Summary description for Feedback
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Feedback : System.Web.Services.WebService
    {
        DBConnect connection = new DBConnect();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public List<HomeFeedback> GetAllFeedbackForHome(int home_id)
        {
            SqlCommand objCommand = new SqlCommand();
            List<HomeFeedback> feedback = new List<HomeFeedback>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllFeedbackForHome";

            DataSet ds = connection.GetDataSet(objCommand);
            DataTable dt = ds.Tables[0];
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
            return feedback;
        }
    }
}
