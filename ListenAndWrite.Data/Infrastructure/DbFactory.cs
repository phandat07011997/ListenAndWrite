using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListenAndWrite.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ListenAndWriteDbContext dbContext;

        public ListenAndWriteDbContext Init()
        {
            return dbContext ?? (dbContext = new ListenAndWriteDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
