using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Utilities;
using HomeClassLibrary;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    // [ApiController]
    public class HomeController : Controller
    {
        DBConnect connection = new DBConnect();

        [HttpGet]
        public List<Home> GetAllHomes()
        {
            SqlCommand objCommand = new SqlCommand();
            List<Home> homes = new List<Home>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllHomes";

            DataSet ds = connection.GetDataSet(objCommand);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Home h = new Home();
                h.HomeId = int.Parse(dt.Rows[i]["home_id"].ToString());
                h.SellerEmail = dt.Rows[i]["seller_email"].ToString();
                h.Price = float.Parse(dt.Rows[i]["price"].ToString());
                h.Address = dt.Rows[i]["address"].ToString();
                h.ZipCode = int.Parse(dt.Rows[i]["zip_code"].ToString());
                h.PropertyType = dt.Rows[i]["property_type"].ToString();
                h.HouseSize = int.Parse(dt.Rows[i]["house_size"].ToString());
                h.NumberBed = int.Parse(dt.Rows[i]["number_bed"].ToString());
                h.NumberBath = int.Parse(dt.Rows[i]["number_bath"].ToString());
                h.OtherAmenities = dt.Rows[i]["other_amenities"].ToString();
                h.Rating = int.Parse(dt.Rows[i]["rating"].ToString());
                h.Status = dt.Rows[i]["status"].ToString();
                homes.Add(h);
            }
            return homes;
        }
    }
}
