using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OAS.MODEL;
using OAS.IDAL;
using OAS.DALFactory;
using System.Data;

namespace OAS.BLL
{
    public class note
    {
        private static readonly Inote notes = DataAccess.Createnote();

        public DataTable SelectNoteByUserName(MNote objNote)
        {
            return notes.SelectNoteByUserName(objNote);
        }

        public void DeleteNoteByID(MNote objNote)
        {
            notes.DeleteNoteByID(objNote);
        }

        public bool InsertIntoNote(MNote objNote)
        {
            return notes.InsertIntoNote(objNote);
        }

        public DataTable SelectAllNotesByNotePerson(MNote objNote)
        {
            return notes.SelectAllNotesByNotePerson(objNote);
        }
    }
}
