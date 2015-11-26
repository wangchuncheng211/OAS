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
    public class vote : OAS.IDAL.Ivote
    {
        public bool InsertIntoVote(MVote objvote)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO tb_vote (voteTitle, voteContent,agreeQty,disagreeQty) VALUES (@VoteTitle,@VoteContent,0,0)");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@VoteTitle",OleDbType.VarWChar,50,"voteTitle",objvote.VoteTitle),
                                       OleDbHelper.GetParameter("@VoteContent",OleDbType.LongVarWChar,"voteContent",objvote.VoteContent)
                                   };
            bool is_succeed = OleDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
                return true;
            else
                return false;
        }

        public DataTable SelectAllVote()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_vote");
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public DataTable SelectVoteByID(MVote objvote)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_vote where ID=@ID");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"ID",objvote.ID)
                                   };
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public bool UpdateVoteAgreeQtyByID(MVote objvote)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_vote set agreeQty=@AgreeQty where ID=@ID");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@AgreeQty",OleDbType.Integer,4,"agreeQty",objvote.AgreeQty),
                                       OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"ID",objvote.ID)
                                   };
            bool is_succeed = OleDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
                return true;
            else
                return false;
        }
        public bool UpdateVoteDisagreeQtyByID(MVote objvote)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_vote set disagreeQty=@DisagreeQty where ID=@ID");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@DisagreeQty",OleDbType.Integer,4,"disagreeQty",objvote.DisagreeQty),
                                       OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"ID",objvote.ID)
                                   };
            bool is_succeed = OleDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
                return true;
            else
                return false;
        }
        public void DeleteVoteByID(MVote objvote)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete  from tb_vote where ID=@ID");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"ID",objvote.ID)
                                   };
            OleDbHelper.ExecuteSql(sb.ToString(), param);
        }
    }
}
