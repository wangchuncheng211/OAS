using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAS.MODEL;
using System.Data;

namespace OAS.IDAL
{
    public interface Inote
    {
        DataTable SelectNoteByUserName(MNote objNote);
        void DeleteNoteByID(MNote objNote);
        bool InsertIntoNote(MNote objNote);
        DataTable SelectAllNotesByNotePerson(MNote objNote);
    }
}
