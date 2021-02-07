using System;
using System.ComponentModel.DataAnnotations;

namespace CallLogger.Shared.Models
{
    public class Call : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public string Platform { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [Required]
        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
