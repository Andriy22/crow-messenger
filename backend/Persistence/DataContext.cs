using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext, IDataContext
    {
        public new DbSet<AppUser> Users { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<PrivateChat> PrivateChats { get; set; }
        public DbSet<GroupChat> GroupChats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatBase> Chats { get; set; }
        public DbSet<ChatRole> ChatRoles { get; set; }
        public DbSet<UserChat> UserChats { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserChat>()
                   .HasKey(t => new { t.UserId, t.ChatId });

            base.OnModelCreating(builder);
        }
    }
}