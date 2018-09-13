using ListenAndWrite.Data.Infrastructure;
using ListenAndWrite.Model.Models;

namespace ListenAndWrite.Data.Repositories
{
    public interface ITrackRepository : IRepository<Track>
    {
    }

    public class TrackRepository : RepositoryBase<Track>, ITrackRepository
    {
        public TrackRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}