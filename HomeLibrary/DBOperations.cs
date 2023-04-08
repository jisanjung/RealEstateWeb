using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Utilities;

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
            return status;
        }
    }
}
