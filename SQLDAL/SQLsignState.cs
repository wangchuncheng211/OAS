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
    public class signState : OAS.IDAL.IsignState
    {
        public bool InsertIntoSignState(MSignState objsignstate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into tb_signState (signstate_describe,[time]) values(@SignState,@Time)");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@SignState",SqlDbType.VarChar,50,"signstate_describe",objsignstate.Signstate_describe),
                                       SQLDbHelper.GetParameter("@SignTime",SqlDbType.DateTime,"[time]",objsignstate.Time)
                                   };
            bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
                return true;
            else
                return false;
        }

        public bool UpdateSignStateByID(MSignState objsignstate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_signState set [time]=@SignTime where signStateID=@SignID");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@SignTime",SqlDbType.DateTime,"[time]",objsignstate.Time),
                                       SQLDbHelper.GetParameter("@SignID",SqlDbType.Int,4,"ID",objsignstate.ID)
                                   };
            bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
                return true;
            else
                return false;
        }

        public DataTable SelectAllSignState()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_SignState");
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }
    }
}
