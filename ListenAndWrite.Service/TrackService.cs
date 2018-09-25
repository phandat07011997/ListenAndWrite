using ListenAndWrite.Data.Infrastructure;
using ListenAndWrite.Data.Repositories;
using ListenAndWrite.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ListenAndWrite.Service
{
    public interface ITrackService
    {
        Track Add(Track track);

        void Update(Track track);

        Track Delete(int id);

        void DeleteByAudioId(int audioId);

        Track GetTrackByTitle(string trackTitle);

        IEnumerable<Track> GetListTrackByAudioId(int audioId);

        void Save();
    }

    public class TrackService : ITrackService
    {
        private ITrackRepository _trackRepository;
        private IUnitOfWork _unitOfWork;

        public TrackService(ITrackRepository trackRepository, IUnitOfWork unitOfWork)
        {
            this._trackRepository = trackRepository;
            this._unitOfWork = unitOfWork;
        }

        public Track Add(Track track)
        {
            return _trackRepository.Add(track);
        }

        public Track Delete(int id)
        {
            return _trackRepository.Delete(id);
        }

        public void DeleteByAudioId(int audioId)
        {
            _trackRepository.DeleteMulti(x => x.AudioId == audioId);
        }

        public IEnumerable<Track> GetListTrackByAudioId(int audioId)
        {
            return _trackRepository.GetMulti(x => x.AudioId == audioId).OrderBy(y => y.TimeStart);
        }

        public Track GetTrackByTitle(string trackTitle)
        {
            return _trackRepository.GetSingleByCondition(x => x.TrackTitle == trackTitle);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Track track)
        {
            _trackRepository.Update(track);
        }
    }
}