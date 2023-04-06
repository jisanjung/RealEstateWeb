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
    }
}
