using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBApi.DTOs
{
    public class TrainingDoneReadDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TrainingId { get; set; }
        public DateTime DateDone { get; set; }
        public int TimeDone { get; set; }
    }
}
