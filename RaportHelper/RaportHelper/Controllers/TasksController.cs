using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RaportHelper.Models;

namespace RaportHelper.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext context;

        public TaskController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet("api/task/{id}")]
        public IEnumerable<Tasks> GetTasks(int id)
        {
            return context.Tasks.Where(t => t.SessionId == id).AsEnumerable();
        }

        [HttpPost("api/task")]
        public void AddTask([FromBody] Tasks task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
        }

        [HttpGet("api/task/edit/{Id}")]
        public void EditTask(int Id, Tasks NewTask)
        {
            var vrlOldTask = context.Tasks.Where(x => x.Id == Id).FirstOrDefault();
            if (vrlOldTask!=null)
            {
                vrlOldTask.Ready = NewTask.Ready;
                vrlOldTask.SessionId = NewTask.SessionId;
                vrlOldTask.AssignedTo = NewTask.AssignedTo;
            }
            context.Entry(vrlOldTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        [HttpDelete("api/task/delete/{Id}")]
        public void DeleteTask(int Id)
        {
            var Task = context.Tasks.Where(x => x.Id == Id).FirstOrDefault();
            context.Remove(Task);
            context.SaveChanges();
        }
    }
}