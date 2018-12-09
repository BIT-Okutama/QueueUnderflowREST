using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateQuestionAsync([FromBody]AskQuestion quest)
        {
            try
            {
                Question question = new Question();
                question.Question1 = quest.question;
                question.AskedBy = quest.askedBy;
                question.AskedByName = quest.askedByName;

                db.Question.Add(question);
                await db.SaveChangesAsync();
                return Ok("Success");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestions()
        {
            try
            {
                return await db.Question.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("hash/{hash}")]
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestionsByHash(string hash)
        {
            try
            {
                var question = await db.Question.Where(x => x.AskedBy == hash).ToListAsync();
                if (question == null)
                {
                    return NotFound();
                }

                return question;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Question>> GetQuestionById(int id)
        {

            try
            {
                var question = await db.Question.FindAsync(id);
                if (question == null)
                {
                    return NotFound();
                }

                return question;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



    }
}
