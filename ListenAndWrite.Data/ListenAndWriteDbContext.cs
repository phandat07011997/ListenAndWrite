using ListenAndWrite.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListenAndWrite.Data
{
    public class ListenAndWriteDbContext : DbContext
    {
        public ListenAndWriteDbContext() : base("ListenAndWriteConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Audio> Audios { set; get; }
        public DbSet<Track> Tracks { set; get; }
        public DbSet<Score> Scores { set; get; }

        public static ListenAndWriteDbContext Create()
        {
            return new ListenAndWriteDbContext();
        }
        
    }
}
