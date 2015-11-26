using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAS.MODEL
{
    public class MRule
    {
        private int id;
        /// <summary>
        /// 制度id
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string ruleContent;
        /// <summary>
        /// 制度内容
        /// </summary>
        public string RuleContent
        {
            get { return ruleContent; }
            set { ruleContent = value; }
        }
    }
}
