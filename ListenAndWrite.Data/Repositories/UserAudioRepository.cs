using ListenAndWrite.Data.Infrastructure;
using ListenAndWrite.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace ListenAndWrite.Data.Repositories
{
    public interface IUserAudioRepository : IRepository<UserAudio>
    {
        
    }

    public class UserAudioRepository : RepositoryBase<UserAudio>, IUserAudioRepository
    {
        public UserAudioRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        
    }

    
}