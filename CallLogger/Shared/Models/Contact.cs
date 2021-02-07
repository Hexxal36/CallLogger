using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CallLogger.Shared.Models
{
    public class Contact : BaseModel
    {
        public Contact()
        {
            this.Calls = new List<Call>();
        }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        public string DiscordName { get; set; }

        public string MessengerName { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsFavorite { get; set; }

        public virtual IEnumerable<Call> Calls { get; set; }
    }
}
