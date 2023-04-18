using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Utilities;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace HomeLibrary
{
    public static class DBOperations
    {
        public static int AddUser(User user)
        {

            DBConnect connection = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddUser";

            SqlParameter emailParam = new SqlParameter("@email", user.Email);
            objCommand.Parameters.Add(emailParam);
            SqlParameter fullnameParam = new SqlParameter("@fullname", user.FullName);
            objCommand.Parameters.Add(fullnameParam);
            SqlParameter passwordParam = new SqlParameter("@user_password", user.Password);
            objCommand.Parameters.Add(passwordParam);
            SqlParameter userTypeParam = new SqlParameter("@user_type", user.Type);
            objCommand.Parameters.Add(userTypeParam);
            SqlParameter homeAddressParam = new SqlParameter("@home_address", user.Address);
            objCommand.Parameters.Add(homeAddressParam);
            SqlParameter securityAnswer1Param = new SqlParameter("@security_answer1", user.SecurityAnswerOne);
            objCommand.Parameters.Add(securityAnswer1Param);
            SqlParameter securityAnswer2Param = new SqlParameter("@security_answer2", user.SecurityAnswerTwo);
            objCommand.Parameters.Add(securityAnswer2Param);
            SqlParameter securityAnswer3Param = new SqlParameter("@security_answer3", user.SecurityAnswerThree);
            objCommand.Parameters.Add(securityAnswer3Param);
            SqlParameter isVerifiedParam = new SqlParameter("@is_verified", user.IsVerified);
            objCommand.Parameters.Add(isVerifiedParam);


            int status = connection.DoUpdate(objCommand);

            if (status < 1)
            {
                objCommand.Parameters.Clear();
                objCommand.CommandText = " ";
            }
            else
            {
                return status;
            }
            return status;
        }
        public static User GetUser(string email)
        {
            DBConnect connection = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            User user = new User();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetUser";

            SqlParameter emailParam = new SqlParameter("@email", email);
            objCommand.Parameters.Add(emailParam);

            DataSet ds = connection.GetDataSet(objCommand);
            DataTable dt = ds.Tables[0];

            user.Email = dt.Rows[0]["email"].ToString();
            user.FullName = dt.Rows[0]["fullname"].ToString();
            user.Type = dt.Rows[0]["user_type"].ToString();
            user.Address = dt.Rows[0]["home_address"].ToString();

            return user;
        }

        public static List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();
            DBConnect connection = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllUsers";

            DataSet ds = connection.GetDataSet(objCommand);
            DataTable dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                User u = new User();
                u.Email = dt.Rows[i]["email"].ToString();
                u.FullName = dt.Rows[i]["fullname"].ToString();
                u.Password = dt.Rows[i]["user_password"].ToString();
                u.Type = dt.Rows[i]["user_type"].ToString();
                u.Address = dt.Rows[i]["home_address"].ToString();
                u.SecurityAnswerOne = dt.Rows[i]["security_answer1"].ToString();
                u.SecurityAnswerTwo = dt.Rows[i]["security_answer2"].ToString();
                u.SecurityAnswerThree = dt.Rows[i]["security_answer3"].ToString();
                u.IsVerified = bool.Parse(dt.Rows[i]["is_verified"].ToString());
                allUsers.Add(u);
            }
            return allUsers;
        }

        public static List<Home> GetSellerHomes(string email)
        {
            DBConnect connection = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            List<Home> sellerHomes = new List<Home>();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetSellerHomes";

            SqlParameter emailParam = new SqlParameter("@email", email);
            objCommand.Parameters.Add(emailParam);

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
                }
                else
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
                sellerHomes.Add(h);
            }
            return sellerHomes;
        }
        public static int UpdateUserInfo(User user)
        {
            DBConnect connection = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateUser";

            SqlParameter emailParam = new SqlParameter("@email", user.Email);
            objCommand.Parameters.Add(emailParam);
            SqlParameter fullnameParam = new SqlParameter("@name", user.FullName);
            objCommand.Parameters.Add(fullnameParam);
            SqlParameter homeAddressParam = new SqlParameter("@address", user.Address);
            objCommand.Parameters.Add(homeAddressParam);


            int status = connection.DoUpdate(objCommand);

            return status;
        }
    }
}
