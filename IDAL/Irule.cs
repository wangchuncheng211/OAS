using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAS.MODEL;
using System.Data;

namespace OAS.IDAL
{
    public interface Irule
    {
        DataTable SelectAllRules();
        bool UpdateRuleContentByID(MRule objrules);
        bool InsertIntoRule(MRule objrules);
    }
}
