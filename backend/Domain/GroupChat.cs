using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GroupChat : ChatBase
    {
        public GroupChat()
        {
            Participants = new HashSet<AppUser>();
        }
        public HashSet<AppUser> Participants { get; set; }
    }
}
