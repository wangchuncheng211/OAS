using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAS.MODEL
{
    public class MNote
    {
        private int id;
        /// <summary>
        /// 记事id
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string title;
        /// <summary>
        /// 记事标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string noteContent;
        /// <summary>
        /// 记事内容
        /// </summary>
        public string NoteContent
        {
            get { return noteContent; }
            set { noteContent = value; }
        }

        private DateTime noteTime;
        /// <summary>
        /// 记事时间
        /// </summary>
        public DateTime NoteTime
        {
            get { return noteTime; }
            set { noteTime = value; }
        }

        private string notePerson;
        /// <summary>
        /// 记事人
        /// </summary>
        public string NotePerson
        {
            get { return notePerson; }
            set { notePerson = value; }
        }
    }
}
