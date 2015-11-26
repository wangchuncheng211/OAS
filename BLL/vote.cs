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
    public class vote
    {
        private static readonly Ivote votes = DataAccess.Createvote();

        public bool InsertIntoVote(MVote objvote)
        {
            return votes.InsertIntoVote(objvote);
        }

        public DataTable SelectAllVote()
        {
            return votes.SelectAllVote();
        }

        public DataTable SelectVoteByID(MVote objvote)
        {
            return votes.SelectVoteByID(objvote);
        }

        public bool UpdateVoteAgreeQtyByID(MVote objvote)
        {
            return votes.UpdateVoteAgreeQtyByID(objvote);
        }

        public bool UpdateVoteDisagreeQtyByID(MVote objvote)
        {
            return votes.UpdateVoteDisagreeQtyByID(objvote);
        }

        public void DeleteVoteByID(MVote objvote)
        {
            votes.DeleteVoteByID(objvote);
        }
    }
}
