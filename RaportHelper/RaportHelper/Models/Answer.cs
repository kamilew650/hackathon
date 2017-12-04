using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RaportHelper.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string AnswerDetails { get; set; }
        public Files File { get; set; }
    }
}
