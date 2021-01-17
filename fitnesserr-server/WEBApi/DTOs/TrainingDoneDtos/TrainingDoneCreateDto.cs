using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.DTOs
{
    public class TrainingDoneCreateDto
    {
        public Guid UserId { get; set; }
        public Guid TrainingId { get; set; }
        public DateTime DateDone { get; set; } = DateTime.Now;
        public int TimeDone { get; set; }
    }
}
