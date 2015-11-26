using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAS.MODEL
{
    public class MVote
    {
        private int id;
        /// <summary>
        /// 投票id
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string voteTitle;
        /// <summary>
        /// 投票标题
        /// </summary>
        public string VoteTitle
        {
            get { return voteTitle; }
            set { voteTitle = value; }
        }

        private string voteContent;
        /// <summary>
        /// 投票内容
        /// </summary>
        public string VoteContent
        {
            get { return voteContent; }
            set { voteContent = value; }
        }

        private int agreeQty;
        /// <summary>
        /// 咱晨票数量
        /// </summary>
        public int AgreeQty
        {
            get { return agreeQty; }
            set { agreeQty = value; }
        }

        private int disagreeQty;
        /// <summary>
        /// 咱晨票数量
        /// </summary>
        public int DisagreeQty
        {
            get { return disagreeQty; }
            set { disagreeQty = value; }
        }
    }
}
