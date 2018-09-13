using ListenAndWrite.Data.Infrastructure;
using ListenAndWrite.Data.Repositories;
using ListenAndWrite.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListenAndWrite.Service
{
    public interface IAudioService
    {
        Audio Add(Audio audio);

        void Update(Audio audio);

        Audio Delete(int id);

        Audio GetById(int id);

        IEnumerable<string> GetListAudioByTitle(string name);

        IEnumerable<Audio> GetLastestAudio(int page, int pageSize, out int totalRow);

        IEnumerable<Audio> GetListAudioByLevel(int level, int page, int pageSize, out int totalRow);

        IEnumerable<Audio> Search(string keyword, int page, int pageSize, out int totalRow);

        void Save();
    }
    public class AudioService : IAudioService
    {
        private IAudioRepository _audioRepository;
        private IUnitOfWork _unitOfWork;

        public AudioService(IAudioRepository audioRepository, IUnitOfWork unitOfWork)
        {
            this._audioRepository = audioRepository;
            this._unitOfWork = unitOfWork;
        }

        public Audio Add(Audio audio)
        {
            return _audioRepository.Add(audio);
        }

        public Audio Delete(int id)
        {
            return _audioRepository.Delete(id);
        }

        public Audio GetById(int id)
        {
            return _audioRepository.GetSingleById(id);
        }

        public IEnumerable<Audio> GetLastestAudio(int page, int pageSize, out int totalRow)
        {
            var query = _audioRepository.GetMulti(x => x.Status == true).OrderByDescending(y=>y.CreatedDate);
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Audio> GetListAudioByLevel(int level, int page, int pageSize, out int totalRow)
        {
            var query = _audioRepository.GetMulti(x => x.Status == true && x.Level==level).OrderByDescending(y => y.CreatedDate);
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<string> GetListAudioByTitle(string title)
        {
            return _audioRepository.GetMulti(x => x.Status == true && x.AudioTitle.Contains(title)).Select(y => y.AudioTitle);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Audio> Search(string keyword, int page, int pageSize, out int totalRow)
        {
            var query = _audioRepository.GetMulti(x => x.Status == true && x.AudioTitle.Contains(keyword)).OrderByDescending(y => y.CreatedDate);
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public void Update(Audio audio)
        {
            _audioRepository.Update(audio);
        }
    }
}
