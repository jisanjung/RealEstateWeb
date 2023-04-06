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
        public DataSet GetAllFeedbackForHome(int home_id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllFeedbackForHome";

            SqlParameter homeIdParam = new SqlParameter("@home_id", home_id);
            objCommand.Parameters.Add(homeIdParam);

            DataSet ds = connection.GetDataSet(objCommand);
            return ds;
        }
        [WebMethod]
        public int AddFeedback(int home_id, string price_feedback, string location_feedback, string overall_feedback, int rating)
        {
            int status;
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddHomeFeedback";

            SqlParameter homeIdParam = new SqlParameter("@home_id", home_id);
            homeIdParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(homeIdParam);

            SqlParameter priceFeedbackParam = new SqlParameter("@price_feedback", price_feedback);
            priceFeedbackParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(priceFeedbackParam);

            SqlParameter locationFeedbackParam = new SqlParameter("@location_feedback", location_feedback);
            locationFeedbackParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(locationFeedbackParam);

            SqlParameter overallFeedbackParam = new SqlParameter("@overall_feedback", overall_feedback);
            overallFeedbackParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(overallFeedbackParam);

            SqlParameter ratingParam = new SqlParameter("@rating", rating);
            ratingParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(ratingParam);

            status = connection.DoUpdate(objCommand);
            return status;
        }
    }
}
