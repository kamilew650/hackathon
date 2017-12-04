using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RaportHelper.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace RaportHelper.Controllers
{
    public class FilesController : Controller
    {
        private readonly AppDbContext context;
        public IActionResult Index()
        {
            return View();
        }
        public FilesController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost("api/file")]
        public void UploadFile([FromBody] IFormFile file)
        {
            MemoryStream ms = new MemoryStream();
            file.OpenReadStream().CopyTo(ms);

            Files filesEntity = new Files()
            {
                Name = file.Name,
                Data = ms.ToArray()
            };

            context.Files.Add(filesEntity);
            context.SaveChanges();
        }

        [HttpGet("api/file/{Id}")]
        public Files GetFiles(int Id)
        {
            Files file = context.Files.Where(x => x.Id == Id).FirstOrDefault();
            return file;
        }
    }
}E:\Hackathon\hackathon\RaportHelper\RaportHelper\wwwroot\