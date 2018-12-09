using System;
using System.Collections.Generic;

namespace StackOverflowAPI.Models
{
    public partial class Question
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
        }

        public int QuestionId { get; set; }
        public string Question1 { get; set; }

        public ICollection<Answer> Answer { get; set; }
    }
}
