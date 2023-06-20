using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserChat
    {
        public required string UserId { get; set; }
        [ForeignKey("UserId")] public required AppUser User { get; set; }
        public required int ChatId { get; set; }
        [ForeignKey("ChatId")] public required ChatBase Chat { get; set; }
        public virtual required ChatRole Role { get; set; }
    }
}
