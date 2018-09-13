using ListenAndWrite.Data.Infrastructure;
using ListenAndWrite.Model.Models;

namespace ListenAndWrite.Data.Repositories
{
    public interface IScoreRepository : IRepository<Score>
    {
    }

    public class ScoreRepository : RepositoryBase<Score>, IScoreRepository
    {
        public ScoreRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}