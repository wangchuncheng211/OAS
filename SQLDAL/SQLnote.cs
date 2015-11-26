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
    public class note : OAS.IDAL.Inote
    {
        public DataTable SelectNoteByUserName(MNote objNote)
        {
           StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_note where notePerson =@NotePerson order by noteTime desc");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@NotePerson",SqlDbType.VarChar,20,"notePerson",objNote.NotePerson)
                                   };
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public void DeleteNoteByID(MNote objNote)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from tb_note where ID=@ID");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"ID",objNote.ID)
                                   };
            SQLDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public bool InsertIntoNote(MNote objNote)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO tb_note (title, noteContent, noteTime, notePerson)VALUES(@Title,@NoteContent,@NoteTime,@NotePerson)");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@Title",SqlDbType.VarChar,50,"title",objNote.Title),
                                       SQLDbHelper.GetParameter("@NoteContent",SqlDbType.Text,"noteContent",objNote.NoteContent),
                                       SQLDbHelper.GetParameter("@NoteTime",SqlDbType.DateTime,"noteTime",objNote.NoteTime),
                                       SQLDbHelper.GetParameter("@NotePerson",SqlDbType.VarChar,20,"notePerson",objNote.NotePerson)
                                   };
            bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
                return true;
            else
                return false;
        }

        public DataTable SelectAllNotesByNotePerson(MNote objNote)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_note where notePerson =@NotePerson order by noteTime desc");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@NotePerson",SqlDbType.VarChar,20,"notePerson",objNote.NotePerson)
                                   };
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }
    }
}
