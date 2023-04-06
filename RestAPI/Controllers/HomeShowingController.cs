using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Utilities;
using HomeLibrary;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    // [ApiController]
    public class HomeShowingController : Controller
    {
        DBConnect connection = new DBConnect();

        [HttpGet]
        public List<HomeShowing> GetAllHomeShowings()
        {
            SqlCommand objCommand = new SqlCommand();
            List<HomeShowing> homeShowings = new List<HomeShowing>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllHomeShowings";

            DataSet ds = connection.GetDataSet(objCommand);
            DataTable dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HomeShowing hs = new HomeShowing();
                hs.ShowingId = int.Parse(dt.Rows[i]["showing_id"].ToString());
                hs.HomeId = int.Parse(dt.Rows[i]["home_id"].ToString());
                hs.BuyerEmail = dt.Rows[i]["buyer_email"].ToString();
                hs.SellerEmail = dt.Rows[i]["seller_email"].ToString();
                hs.Date = dt.Rows[i]["show_date"].ToString();
                hs.Time = dt.Rows[i]["show_time"].ToString();
                homeShowings.Add(hs);
            }
            return homeShowings;
        }
        [HttpGet("{showing_id}")]
        public HomeShowing GetHomeShowing(int showing_id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetHomeShowing";

            SqlParameter showingIdParam = new SqlParameter("@showing_id", showing_id);
            objCommand.Parameters.Add(showingIdParam);

            DataSet ds = connection.GetDataSet(objCommand);
            DataTable dt = ds.Tables[0];

            HomeShowing hs = new HomeShowing();
            hs.ShowingId = int.Parse(dt.Rows[0]["showing_id"].ToString());
            hs.HomeId = int.Parse(dt.Rows[0]["home_id"].ToString());
            hs.BuyerEmail = dt.Rows[0]["buyer_email"].ToString();
            hs.SellerEmail = dt.Rows[0]["seller_email"].ToString();
            hs.Date = dt.Rows[0]["show_date"].ToString();
            hs.Time = dt.Rows[0]["show_time"].ToString();

            return hs;
        }
    }
}
