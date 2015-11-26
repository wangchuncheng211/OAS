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
    class notice : OAS.IDAL.Inotice
    {
        public bool InsertIntoNotice(MNotice objNotice)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into tb_notice (noticeTitle,noticeTime,noticePerson,noticeContent,noticeHtmlName) values(@Title,@Datetime,@NoticePerson,@NoticeContent,@NoticeHtmlName)");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@Title",OleDbType.VarWChar,40,"noticeTitle",objNotice.NoticeTitle),
                                       OleDbHelper.GetParameter("@Datetime",OleDbType.Date,"noticeTime",objNotice.NoticeTime),
                                       OleDbHelper.GetParameter("@NoticePerson",OleDbType.VarWChar,20,"noticePerson",objNotice.NoticePerson),
                                       OleDbHelper.GetParameter("@NoticeContent",OleDbType.LongVarWChar,"noticeContent",objNotice.NoticeContent),
                                       OleDbHelper.GetParameter("@NoticeHtmlName",OleDbType.VarWChar,50,"noticeHtmlName",objNotice.NoticeHtmlName)
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

        public DataTable SelectAllNotice()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_notice order by noticeID desc");
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public bool DeleteNoticeByID(MNotice objNotice)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from tb_notice where noticeID=@ID");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"noticeID",objNotice.ID)
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

        public bool UpdateNoticeByID(MNotice objNotice)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_notice set noticeTitle=@Title,noticePerson=@NoticePerson,noticeContent=@NoticeContent where noticeID=@ID");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@Title",OleDbType.VarWChar,40,"noticeTitle",objNotice.NoticeTitle),
                                       OleDbHelper.GetParameter("@NoticePerson",OleDbType.VarWChar,20,"noticePerson",objNotice.NoticePerson),
                                       OleDbHelper.GetParameter("@NoticeContent",OleDbType.LongVarWChar,"noticeContent",objNotice.NoticeContent),
                                       OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"noticeID",objNotice.ID)
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

        public DataTable SelectNoticeByID(MNotice objNotice)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_notice where noticeID=@ID");
            OleDbParameter[] param = {
                                        OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"noticeID",objNotice.ID)
                                   };
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString(),param);
            return dt;
        }
    }
}
