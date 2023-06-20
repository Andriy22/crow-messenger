using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PrivateChat : ChatBase
    {
        public PrivateChat()
        {
            Participants = new HashSet<AppUser>();
        }
        public virtual HashSet<AppUser> Participants { get; set; }
    }
}
