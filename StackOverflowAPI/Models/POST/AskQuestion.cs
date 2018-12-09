using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowAPI.Models.POST
{
    public class AskQuestion
    {
        public string question { set; get; }
        public string askedBy { set; get; }
        public string askedByName { set; get; }
    }
}
