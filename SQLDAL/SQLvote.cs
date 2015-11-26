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
    public class vote : OAS.IDAL.Ivote
    {
       public bool InsertIntoVote(MVote objvote)
       {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO tb_vote (voteTitle, voteContent,agreeQty,disagreeQty) VALUES (@VoteTitle,@VoteContent,0,0)");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@VoteTitle",SqlDbType.VarChar,50,"voteTitle",objvote.VoteTitle),
                                       SQLDbHelper.GetParameter("@VoteContent",SqlDbType.Text,"voteContent",objvote.VoteContent)
                                   };
            bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
                return true;
            else
                return false;
       }

       public DataTable SelectAllVote()
       {
           StringBuilder sb = new StringBuilder();
           sb.Append("select * from tb_vote");
           DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString());
           return dt;
       }

       public DataTable SelectVoteByID(MVote objvote)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append("select * from tb_vote where ID=@ID");
           SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"ID",objvote.ID)
                                   };
           DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString(), param);
           return dt;
       }

       public bool UpdateVoteAgreeQtyByID(MVote objvote)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append("update tb_vote set agreeQty=@AgreeQty where ID=@ID");
           SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@AgreeQty",SqlDbType.Int,4,"agreeQty",objvote.AgreeQty),
                                       SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"ID",objvote.ID)
                                   };
           bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
           if (is_succeed)
               return true;
           else
               return false;
       }

       public bool UpdateVoteDisagreeQtyByID(MVote objvote)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append("update tb_vote set disagreeQty=@DisagreeQty where ID=@ID");
           SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@DisagreeQty",SqlDbType.Int,4,"agreeQty",objvote.DisagreeQty),
                                       SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"ID",objvote.ID)
                                   };
           bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
           if (is_succeed)
               return true;
           else
               return false;
       }

       public void DeleteVoteByID(MVote objvote)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append("delete  from tb_vote where ID=@ID");
           SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"ID",objvote.ID)
                                   };
           SQLDbHelper.ExecuteSql(sb.ToString(), param);
       }
    }
}
