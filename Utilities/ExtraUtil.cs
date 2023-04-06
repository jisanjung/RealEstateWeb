using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class ExtraUtil
    {
        public static SqlParameter CreateParamVarChar(string input, string paramID, int len)
        {
            SqlParameter templateParameter = new SqlParameter(paramID, input);
            templateParameter.Direction = ParameterDirection.Input;
            templateParameter.SqlDbType = SqlDbType.VarChar;
            templateParameter.Size = len;


            return templateParameter;
        }
    }
}
