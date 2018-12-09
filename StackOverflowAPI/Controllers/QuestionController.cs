using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackOverflowAPI.Models;
using StackOverflowAPI.Models.POST;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StackOverflowAPI.Controllers
{
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        StackOverflowContext db;

        public QuestionController(StackOverflowContext _context)
        {
            db = _context;
        }

        // GET: api/<controller>
        [HttpPost("create")]
        public async Task<IActionResult> CreateQuestionAsync([FromBody]AskQuestion quest)
        {
            try
            {
                Question question = new Question();
                question.Question1 = quest.question;

                db.Question.Add(question);
                await db.SaveChangesAsync();
                return Ok("Success");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
