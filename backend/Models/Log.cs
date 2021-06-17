using backend.Models.Authentication;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string RefFileName { get; set; }
        public string OriFileName { get; set; }
        public long FileSize { get; set; }
        public double OperationTimes { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserId { get; set; }
    }
}
