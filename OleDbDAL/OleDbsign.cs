using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OAS.MODEL;
using OAS.DBUtility;
using System.Data;
using System.Data.OleDb;

namespace OAS.OleDbDAL
{
    public class sign : OAS.IDAL.Isign
    {
        public void InsertIntoSign(MSign objsign)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO tb_sign ([datetime], employeeName, late, quit) values (@Datetime,@EmployeeName,@Late,@Quit)");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@Datetime",OleDbType.Date,"datetime",objsign.Datetime),
                                       OleDbHelper.GetParameter("@EmployeeName",OleDbType.VarWChar,20,"employeeName",objsign.EmployeeName),
                                       OleDbHelper.GetParameter("@Late",OleDbType.Boolean,"late",objsign.Late),
                                       OleDbHelper.GetParameter("@Quit",OleDbType.Boolean,"quit",objsign.Quit)
                                   };
            OleDbHelper.ExecuteSql(sb.ToString(), param);
        }
    }
}
