using ListenAndWrite.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ListenAndWrite.Data
{
    public class ListenAndWriteDbContext : IdentityDbContext<ApplicationUser>
    {
        public ListenAndWriteDbContext() : base("ListenAndWriteConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<UserAudio> UserAudios { set; get; }
        public DbSet<Audio> Audios { set; get; }
        public DbSet<Track> Tracks { set; get; }
        public DbSet<Score> Scores { set; get; }

        public static ListenAndWriteDbContext Create()
        {
            return new ListenAndWriteDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}