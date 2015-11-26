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
    public class rule : OAS.IDAL.Irule
    {
        public DataTable SelectAllRules()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_rule");
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public bool UpdateRuleContentByID(MRule objrules)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_rule set content=@RuleContent where id=@ID");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@RuleContent",OleDbType.LongVarWChar,"content",objrules.RuleContent),
                                       OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"id",objrules.ID)
                                   };
            bool is_succeed = OleDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InsertIntoRule(MRule objrules)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into tb_rule (id,content) values(@ID,@RuleContent)");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"id",objrules.ID),
                                       OleDbHelper.GetParameter("@RuleContent",OleDbType.LongVarWChar,"content",objrules.RuleContent)
                                   };
            bool is_succeed = OleDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
