using System;
using System.Collections.Generic;

namespace StackOverflowAPI.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public string Answer1 { get; set; }
        public int QuestionId { get; set; }
        public string AnsweredBy { get; set; }
        public string AnsweredByName { get; set; }

        public Question Question { get; set; }
    }
}
