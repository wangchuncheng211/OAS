using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAS.MODEL;
using System.Data;

namespace OAS.IDAL
{
    public interface Ivote
    {
        bool InsertIntoVote(MVote objvote);
        DataTable SelectAllVote();
        DataTable SelectVoteByID(MVote objvote);
        bool UpdateVoteAgreeQtyByID(MVote objvote);
        bool UpdateVoteDisagreeQtyByID(MVote objvote);
        void DeleteVoteByID(MVote objvote);
    }
}
