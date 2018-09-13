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

    }
    public class AudioRepository : RepositoryBase<Audio>, IAudioRepository
    {
        public AudioRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
