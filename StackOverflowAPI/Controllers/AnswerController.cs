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
    public class AnswerController : Controller
    {
        StackOverflowContext db;

        public AnswerController(StackOverflowContext _context)
        {
            db = _context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAnswerAsync([FromBody]AnswerQuestion ans)
        {
            try
            {
                Answer answer = new Answer();
                answer.QuestionId = ans.question_id;
                answer.Answer1 = ans.answer;
                answer.AnsweredBy = ans.answeredBy;
                answer.AnsweredByName = ans.answeredByName;

                db.Answer.Add(answer);
                await db.SaveChangesAsync();
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAllAnswers()
        {
            try
            {
                return await db.Answer.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("hash/{hash}")]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAllAnswersByHash(string hash)
        {
            try
            {
                var answer = await db.Answer.Where(x => x.AnsweredBy == hash).ToListAsync();
                if (answer == null)
                {
                    return NotFound();
                }

                return answer;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("id/{id}")]
        public async Task<ActionResult<Answer>> GeAnswerById(int id)
        {

            try
            {
                var answer = await db.Answer.FindAsync(id);
                if (answer == null)
                {
                    return NotFound();
                }

                return answer;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("question/id/{id}")]
        public async Task<ActionResult<Answer>> GetAnswersByQuestionId(int id)
        {

            try
            {
                var answer = await db.Answer.Where(a => a.QuestionId == id).ToListAsync();
                if (answer == null)
                {
                    return NotFound();
                }

                return Ok(answer);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
