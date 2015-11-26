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
    public class note : OAS.IDAL.Inote
    {
        public DataTable SelectNoteByUserName(MNote objNote)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_note where notePerson =@NotePerson order by noteTime desc");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@NotePerson",OleDbType.VarWChar,20,"notePerson",objNote.NotePerson)
                                   };
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public void DeleteNoteByID(MNote objNote)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from tb_note where ID=@ID");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"ID",objNote.ID)
                                   };
            OleDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public bool InsertIntoNote(MNote objNote)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO tb_note (title, noteContent, noteTime, notePerson) VALUES(@Title,@NoteContent,@NoteTime,@NotePerson)");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@Title",OleDbType.VarWChar,50,"title",objNote.Title),
                                       OleDbHelper.GetParameter("@NoteContent",OleDbType.LongVarWChar,"noteContent",objNote.NoteContent),
                                       OleDbHelper.GetParameter("@NoteTime",OleDbType.Date,"noteTime",objNote.NoteTime),
                                       OleDbHelper.GetParameter("@NotePerson",OleDbType.VarWChar,20,"notePerson",objNote.NotePerson)
                                   };
            bool is_succeed = OleDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
                return true;
            else
                return false;
        }

        public DataTable SelectAllNotesByNotePerson(MNote objNote)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_note where notePerson =@NotePerson order by noteTime desc");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@NotePerson",OleDbType.VarWChar,20,"notePerson",objNote.NotePerson)
                                   };
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }
    }
}
