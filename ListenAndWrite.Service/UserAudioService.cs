using ListenAndWrite.Data.Infrastructure;
using ListenAndWrite.Data.Repositories;
using ListenAndWrite.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListenAndWrite.Service.Properties
{
    public interface IUserAudioService
    {
        UserAudio Add(UserAudio userAudio);

        void Update(UserAudio userAudio);

        UserAudio Delete(int id);

        UserAudio GetById(int id);

        IEnumerable<UserAudio> GetAll(string userId);

        void Save();
    }
    public class UserAudioService : IUserAudioService
    {
        private IUserAudioRepository _userAudioRepository;
        private IUnitOfWork _unitOfWork;
        public UserAudioService(IUserAudioRepository userAudioRepository, IUnitOfWork unitOfWork)
        {
            this._userAudioRepository = userAudioRepository;
            this._unitOfWork = unitOfWork;
        }
        public UserAudio Add(UserAudio userAudio)
        {
            return _userAudioRepository.Add(userAudio);
        }

        public UserAudio Delete(int id)
        {
            return _userAudioRepository.Delete(id);
        }

        public UserAudio GetById(int id)
        {
            return _userAudioRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(UserAudio userAudio)
        {
            _userAudioRepository.Update(userAudio);
        }
        public IEnumerable<UserAudio> GetAll(string userId)
        {
            return _userAudioRepository.GetMulti(x => x.UserId == userId).OrderByDescending(y=>y.CreatedDate);
        }
    }
}
