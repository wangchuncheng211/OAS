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
    public class rule : OAS.IDAL.Irule
    {
        public DataTable SelectAllRules()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_rule");
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public bool UpdateRuleContentByID(MRule objrules)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_rule set content=@RuleContent where id=@ID");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@RuleContent",SqlDbType.Text,"content",objrules.RuleContent),
                                       SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"id",objrules.ID)
                                   };
            bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
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
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"id",objrules.ID),
                                       SQLDbHelper.GetParameter("@RuleContent",SqlDbType.Text,"content",objrules.RuleContent)
                                   };
            bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
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
