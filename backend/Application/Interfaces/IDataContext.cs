using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IDataContext
    {
        DbSet<AppUser> Users { get; set; }
        DbSet<Attachment> Attachments { get; set; }
        DbSet<PrivateChat> PrivateChats { get; set; }
        DbSet<GroupChat> GroupChats { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<ChatBase> Chats { get; set; }
        DbSet<ChatRole> ChatRoles { get; set; }
        DbSet<UserChat> UserChats { get; set; }
        DbSet<AuthorizedDevice> AuthorizedDevices { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
