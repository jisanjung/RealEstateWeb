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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
                h.YearBuilt = int.Parse(dt.Rows[i]["year_built"].ToString());

                if (connection.GetField("rooms", i) != System.DBNull.Value)
                {
                    Byte[] byteArray = (Byte[])connection.GetField("rooms", i);
                    BinaryFormatter deSerializer = new BinaryFormatter();
                    MemoryStream memStream = new MemoryStream(byteArray);
                    List<Room> rooms = (List<Room>)deSerializer.Deserialize(memStream);
                    h.Rooms = rooms;
                } else
                {
                    h.Rooms = new List<Room>();
                }

                h.HVAC = dt.Rows[i]["hvac"].ToString();
                h.Garage = dt.Rows[i]["garage"].ToString();
                h.Utilities = dt.Rows[i]["utilities"].ToString();
                h.Img = dt.Rows[i]["img"].ToString();
                h.ImgCaption = dt.Rows[i]["img_caption"].ToString();
                h.Description = dt.Rows[i]["description"].ToString();
                h.CompanyName = dt.Rows[i]["company_name"].ToString();
                h.AgentEmail = dt.Rows[i]["agent_email"].ToString();
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
            h.YearBuilt = int.Parse(dt.Rows[0]["year_built"].ToString());

            if (connection.GetField("rooms", 0) != System.DBNull.Value)
            {
                Byte[] byteArray = (Byte[])connection.GetField("rooms", 0);
                BinaryFormatter deSerializer = new BinaryFormatter();
                MemoryStream memStream = new MemoryStream(byteArray);
                List<Room> rooms = (List<Room>)deSerializer.Deserialize(memStream);
                h.Rooms = rooms;
            }
            else
            {
                h.Rooms = new List<Room>();
            }

            h.HVAC = dt.Rows[0]["hvac"].ToString();
            h.Garage = dt.Rows[0]["garage"].ToString();
            h.Utilities = dt.Rows[0]["utilities"].ToString();
            h.Img = dt.Rows[0]["img"].ToString();
            h.ImgCaption = dt.Rows[0]["img_caption"].ToString();
            h.Description = dt.Rows[0]["description"].ToString();
            h.CompanyName = dt.Rows[0]["company_name"].ToString();
            h.AgentEmail = dt.Rows[0]["agent_email"].ToString();

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

            SqlParameter yearBuiltParam = new SqlParameter("@year_built", home.YearBuilt);
            yearBuiltParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(yearBuiltParam);

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

            // serialize list of rooms before adding as a parameter
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            Byte[] byteArray;
            serializer.Serialize(memStream, home.Rooms);
            byteArray = memStream.ToArray();

            SqlParameter roomsParam = new SqlParameter("@rooms", byteArray);
            roomsParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(roomsParam);

            SqlParameter hvacParam = new SqlParameter("@hvac", home.HVAC);
            hvacParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(hvacParam);

            SqlParameter garageParam = new SqlParameter("@garage", home.Garage);
            garageParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(garageParam);

            SqlParameter utilitiesParam = new SqlParameter("@utilities", home.Utilities);
            utilitiesParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(utilitiesParam);

            SqlParameter otherAmenitiesParam = new SqlParameter("@other_amenities", home.OtherAmenities);
            otherAmenitiesParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(otherAmenitiesParam);

            SqlParameter imgParam = new SqlParameter("@img", home.Img);
            imgParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(imgParam);

            SqlParameter imgCaptionParam = new SqlParameter("@img_caption", home.ImgCaption);
            imgCaptionParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(imgCaptionParam);

            SqlParameter ratingParam = new SqlParameter("@rating", home.Rating);
            ratingParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(ratingParam);

            SqlParameter statusParam = new SqlParameter("@status", home.Status);
            statusParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(statusParam);

            SqlParameter descriptionParam = new SqlParameter("@description", home.Description);
            descriptionParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(descriptionParam);

            SqlParameter companyNameParam = new SqlParameter("@company_name", home.CompanyName);
            companyNameParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(companyNameParam);

            SqlParameter agentEmailParam = new SqlParameter("@agent_email", home.AgentEmail);
            agentEmailParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(agentEmailParam);

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

            SqlParameter yearBuiltParam = new SqlParameter("@year_built", home.YearBuilt);
            yearBuiltParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(yearBuiltParam);

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


            // serialize list of rooms before adding as a parameter
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            Byte[] byteArray;
            serializer.Serialize(memStream, home.Rooms);
            byteArray = memStream.ToArray();

            SqlParameter roomsParam = new SqlParameter("@rooms", byteArray);
            roomsParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(roomsParam);

            SqlParameter hvacParam = new SqlParameter("@hvac", home.HVAC);
            hvacParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(hvacParam);

            SqlParameter garageParam = new SqlParameter("@garage", home.Garage);
            garageParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(garageParam);

            SqlParameter utilitiesParam = new SqlParameter("@utilities", home.Utilities);
            utilitiesParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(utilitiesParam);

            SqlParameter otherAmenitiesParam = new SqlParameter("@other_amenities", home.OtherAmenities);
            otherAmenitiesParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(otherAmenitiesParam);

            SqlParameter imgParam = new SqlParameter("@img", home.Img);
            imgParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(imgParam);

            SqlParameter imgCaptionParam = new SqlParameter("@img_caption", home.ImgCaption);
            imgCaptionParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(imgCaptionParam);

            SqlParameter ratingParam = new SqlParameter("@rating", home.Rating);
            ratingParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(ratingParam);

            SqlParameter statusParam = new SqlParameter("@status", home.Status);
            statusParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(statusParam);

            SqlParameter descriptionParam = new SqlParameter("@description", home.Description);
            descriptionParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(descriptionParam);

            SqlParameter companyNameParam = new SqlParameter("@company_name", home.CompanyName);
            companyNameParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(companyNameParam);

            SqlParameter agentEmailParam = new SqlParameter("@agent_email", home.AgentEmail);
            agentEmailParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(agentEmailParam);

            status = connection.DoUpdate(objCommand);
            return status;
        }
        [HttpDelete("Remove/{home_id}")]
        public int RemoveHome(int home_id)
        {
            int status;
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_RemoveHome";

            SqlParameter homeIdParam = new SqlParameter("@home_id", home_id);
            homeIdParam.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(homeIdParam);

            status = connection.DoUpdate(objCommand);
            return status;
        }
    }
}
