using ListenAndWrite.Data.Infrastructure;
using ListenAndWrite.Data.Repositories;
using ListenAndWrite.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace ListenAndWrite.Service
{
    public interface IScoreService
    {
        Score Add(Score score);

        IEnumerable<Score> GetListScoreByUserIdAndAudioId(int audioId,string userId);

        void Save();
    }

    public class ScoreService : IScoreService
    {
        private IScoreRepository _scoreRepository;
        private IUnitOfWork _unitOfWork;

        public ScoreService(IScoreRepository scoreRepository, IUnitOfWork unitOfWork)
        {
            this._scoreRepository = scoreRepository;
            this._unitOfWork = unitOfWork;
        }

        public Score Add(Score score)
        {
            return _scoreRepository.Add(score);
        }

        public IEnumerable<Score> GetListScoreByUserIdAndAudioId(int audioId, string userId)
        {
            return _scoreRepository.GetMulti(x => x.AudioId == audioId && x.UserId==userId).OrderByDescending(y => y.CreateDate).Take(10);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}