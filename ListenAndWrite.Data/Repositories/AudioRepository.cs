using ListenAndWrite.Data.Infrastructure;
using ListenAndWrite.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListenAndWrite.Data.Repositories
{
    public interface IAudioRepository : IRepository<Audio>
    {
        IEnumerable<int> GetListLevel();
    }
    public class AudioRepository : RepositoryBase<Audio>, IAudioRepository
    {
        public AudioRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<int> GetListLevel()
        {
            var query = from a in DbContext.Audios
                        where a.Status == true
                        orderby a.Level descending
                        select a.Level;
            return query.ToList().Distinct();
        }
    }
}
