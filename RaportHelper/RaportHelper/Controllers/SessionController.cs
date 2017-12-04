using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RaportHelper.Models;
namespace RaportHelper.Controllers
{
    public class SessionController : Controller
    {
        private readonly AppDbContext context;
        public SessionController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("api/session/{SessionToken}")]
        public Sessions GetSession(string SessionToken)
        {
            return context.Sessions.Where(x => x.Token == SessionToken).FirstOrDefault();
        }

        [HttpPost("api/session")]
        public void AddSession(Sessions session)
        {
            context.Sessions.Add(session);
        }

        [HttpGet("api/session/{SessionToken}/{IsReady}")]
        public void SetSessionReady(string SessionToken, int IsReady)
        {
            bool vrlReady = Convert.ToBoolean(IsReady);
            var vrlNewSession = context.Sessions.Where(x => x.Token == SessionToken).FirstOrDefault();
            if (vrlNewSession != null) 
            {
                vrlNewSession.Ready = vrlReady;
            }
            context.Entry(vrlNewSession).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}