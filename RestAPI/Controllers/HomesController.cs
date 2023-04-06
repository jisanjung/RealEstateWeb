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
    public class HomesController : Controller
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
        [HttpGet("{home_id}")]
        public Home GetHome(int home_id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetHome";

            SqlParameter input = new SqlParameter("@home_id", home_id);
            objCommand.Parameters.Add(input);

            DataSet ds = connection.GetDataSet(objCommand);
            DataTable dt = ds.Tables[0];

            Home h = new Home();
            h.HomeId = int.Parse(dt.Rows[0]["home_id"].ToString());
            h.SellerEmail = dt.Rows[0]["seller_email"].ToString();
            h.Price = float.Parse(dt.Rows[0]["price"].ToString());
            h.Address = dt.Rows[0]["address"].ToString();
            h.ZipCode = int.Parse(dt.Rows[0]["zip_code"].ToString());
            h.PropertyType = dt.Rows[0]["property_type"].ToString();
            h.HouseSize = int.Parse(dt.Rows[0]["house_size"].ToString());
            h.NumberBed = int.Parse(dt.Rows[0]["number_bed"].ToString());
            h.NumberBath = int.Parse(dt.Rows[0]["number_bath"].ToString());
            h.OtherAmenities = dt.Rows[0]["other_amenities"].ToString();
            h.Rating = int.Parse(dt.Rows[0]["rating"].ToString());
            h.Status = dt.Rows[0]["status"].ToString();

            return h;
        }
        [HttpPost("Add")]
        public int AddHome([FromBody]Home home)
        {
            int status;
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddHome";

            SqlParameter sellerEmailParam = new SqlParameter("@seller_email", home.SellerEmail);
            sellerEmailParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(sellerEmailParam);

            SqlParameter priceParam = new SqlParameter("@price", home.Price);
            priceParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(priceParam);

            SqlParameter addressParam = new SqlParameter("@address", home.Address);
            addressParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(addressParam);

            SqlParameter zipCodeParam = new SqlParameter("@zip_code", home.ZipCode);
            zipCodeParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(zipCodeParam);

            SqlParameter propertyTypeParam = new SqlParameter("@property_type", home.PropertyType);
            propertyTypeParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(propertyTypeParam);

            SqlParameter houseSizeParam = new SqlParameter("@house_size", home.HouseSize);
            houseSizeParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(houseSizeParam);

            SqlParameter numberBedParam = new SqlParameter("@number_bed", home.NumberBed);
            numberBedParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(numberBedParam);

            SqlParameter numberBathParam = new SqlParameter("@number_bath", home.NumberBath);
            numberBathParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(numberBathParam);

            SqlParameter otherAmenitiesParam = new SqlParameter("@other_amenities", home.OtherAmenities);
            otherAmenitiesParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(otherAmenitiesParam);

            SqlParameter ratingParam = new SqlParameter("@rating", home.Rating);
            ratingParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(ratingParam);

            SqlParameter statusParam = new SqlParameter("@status", home.Status);
            statusParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(statusParam);

            status = connection.DoUpdate(objCommand);
            return status;
        }
        [HttpPut("Edit")]
        public int EditHome([FromBody]Home home)
        {
            int status;
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_EditHome";

            SqlParameter homeIdParam = new SqlParameter("@home_id", home.HomeId);
            homeIdParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(homeIdParam);

            SqlParameter sellerEmailParam = new SqlParameter("@seller_email", home.SellerEmail);
            sellerEmailParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(sellerEmailParam);

            SqlParameter priceParam = new SqlParameter("@price", home.Price);
            priceParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(priceParam);

            SqlParameter addressParam = new SqlParameter("@address", home.Address);
            addressParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(addressParam);

            SqlParameter zipCodeParam = new SqlParameter("@zip_code", home.ZipCode);
            zipCodeParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(zipCodeParam);

            SqlParameter propertyTypeParam = new SqlParameter("@property_type", home.PropertyType);
            propertyTypeParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(propertyTypeParam);

            SqlParameter houseSizeParam = new SqlParameter("@house_size", home.HouseSize);
            houseSizeParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(houseSizeParam);

            SqlParameter numberBedParam = new SqlParameter("@number_bed", home.NumberBed);
            numberBedParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(numberBedParam);

            SqlParameter numberBathParam = new SqlParameter("@number_bath", home.NumberBath);
            numberBathParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(numberBathParam);

            SqlParameter otherAmenitiesParam = new SqlParameter("@other_amenities", home.OtherAmenities);
            otherAmenitiesParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(otherAmenitiesParam);

            SqlParameter ratingParam = new SqlParameter("@rating", home.Rating);
            ratingParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(ratingParam);

            SqlParameter statusParam = new SqlParameter("@status", home.Status);
            statusParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(statusParam);

            status = connection.DoUpdate(objCommand);
            return status;
        }
    }
}
