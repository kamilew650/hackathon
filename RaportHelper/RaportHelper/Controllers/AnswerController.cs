using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RaportHelper.Models;

namespace RaportHelper.Controllers
{
    public class AnswerController : Controller
    {
        private readonly AppDbContext context;
        public AnswerController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("api/answer")]
        public void AddAnswer([FromBody] Answer Answer)
        {
            context.Answer.Add(Answer);
            context.SaveChanges();
        }

        [HttpGet("api/answer/ByTask/{TaskId}")]
        public Answer GetAnswerByTaskId(int TaskId)
        {
            return context.Answer.Where(x => x.TaskId == TaskId).FirstOrDefault();
        }
        [HttpGet("api/answer/ById/{Id}")]
        public Answer  GetAnswerById(int Id)
        {
            return context.Answer.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}