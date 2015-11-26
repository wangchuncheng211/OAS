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
    public class signState : OAS.IDAL.IsignState
    {
        public bool InsertIntoSignState(MSignState objsignstate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into tb_signState (signstate_describe,[time]) values(@SignState,@Time)");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@SignState",OleDbType.VarWChar,50,"signstate_describe",objsignstate.Signstate_describe),
                                       OleDbHelper.GetParameter("@SignTime",OleDbType.Date,"[time]",objsignstate.Time)
                                   };
            bool is_succeed = OleDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
                return true;
            else
                return false;
        }

        public bool UpdateSignStateByID(MSignState objsignstate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_signState set [time]=@SignTime where signStateID=@SignID");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@SignTime",OleDbType.Date,"[time]",objsignstate.Time),
                                       OleDbHelper.GetParameter("@SignID",OleDbType.Integer,4,"ID",objsignstate.ID)
                                   };
            bool is_succeed = OleDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
                return true;
            else
                return false;
        }

        public DataTable SelectAllSignState()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_SignState");
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }
    }
}
