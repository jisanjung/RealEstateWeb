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
    public class HomeOffersController : Controller
    {
        DBConnect connection = new DBConnect();

        [HttpGet]
        public List<HomeOffer> GetAllHomeOffers()
        {
            SqlCommand objCommand = new SqlCommand();
            List<HomeOffer> homeOffers = new List<HomeOffer>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllHomeOffers";

            DataSet ds = connection.GetDataSet(objCommand);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HomeOffer ho = new HomeOffer();
                ho.HomeOfferId = int.Parse(dt.Rows[i]["offer_id"].ToString());
                ho.HomeId = int.Parse(dt.Rows[i]["home_id"].ToString());
                ho.SaleType = dt.Rows[i]["sale_type"].ToString();
                ho.Contingencies = dt.Rows[i]["contingencies"].ToString();
                ho.OfferAmount = float.Parse(dt.Rows[i]["offer_amount"].ToString());
                ho.MoveInDate = dt.Rows[i]["movein_date"].ToString();
                ho.SellHomeFirst = bool.Parse(dt.Rows[i]["sell_home_first"].ToString());
                ho.BuyerEmail = dt.Rows[i]["buyer_email"].ToString();
                ho.SellerEmail = dt.Rows[i]["seller_email"].ToString();
                ho.Accepted = bool.Parse(dt.Rows[i]["accepted"].ToString());
                homeOffers.Add(ho);
            }
            return homeOffers;
        }
        [HttpGet("{offer_id}")]
        public HomeOffer GetHomeOffer(int offer_id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetHomeOffer";

            SqlParameter offerIdParam = new SqlParameter("@offer_id", offer_id);
            objCommand.Parameters.Add(offerIdParam);

            DataSet ds = connection.GetDataSet(objCommand);
            DataTable dt = ds.Tables[0];

            HomeOffer ho = new HomeOffer();
            ho.HomeOfferId = int.Parse(dt.Rows[0]["offer_id"].ToString());
            ho.HomeId = int.Parse(dt.Rows[0]["home_id"].ToString());
            ho.SaleType = dt.Rows[0]["sale_type"].ToString();
            ho.Contingencies = dt.Rows[0]["contingencies"].ToString();
            ho.OfferAmount = float.Parse(dt.Rows[0]["offer_amount"].ToString());
            ho.MoveInDate = dt.Rows[0]["movein_date"].ToString();
            ho.SellHomeFirst = bool.Parse(dt.Rows[0]["sell_home_first"].ToString());
            ho.BuyerEmail = dt.Rows[0]["buyer_email"].ToString();
            ho.SellerEmail = dt.Rows[0]["seller_email"].ToString();
            ho.Accepted = bool.Parse(dt.Rows[0]["accepted"].ToString());

            return ho;
        }
    }
}
