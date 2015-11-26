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
    public class rule
    {
        private static readonly Irule rules = DataAccess.Createrule();

        public DataTable SelectAllRules()
        {
            return rules.SelectAllRules();
        }

        public bool UpdateRuleContentByID(MRule objrules)
        {
            return rules.UpdateRuleContentByID(objrules);
        }

        public bool InsertIntoRule(MRule objrules)
        {
            return rules.InsertIntoRule(objrules);
        }
    }
}
