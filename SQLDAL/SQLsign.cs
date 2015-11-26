using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OAS.MODEL;
using OAS.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace OAS.SQLDAL
{
    public class sign : OAS.IDAL.Isign
    {
        public void InsertIntoSign(MSign objsign)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO tb_sign (datetime, employeeName, late, quit) values (@Datetime,@EmployeeName,@Late,@Quit)");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@Datetime",SqlDbType.DateTime,"datetime",objsign.Datetime),
                                       SQLDbHelper.GetParameter("@EmployeeName",SqlDbType.VarChar,20,"employeeName",objsign.EmployeeName),
                                       SQLDbHelper.GetParameter("@Late",SqlDbType.Bit,"late",objsign.Late),
                                       SQLDbHelper.GetParameter("@Quit",SqlDbType.Bit,"quit",objsign.Quit)
                                   };
            SQLDbHelper.ExecuteSql(sb.ToString(), param);
        }
    }
}
