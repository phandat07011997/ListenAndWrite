using AutoMapper;
using ListenAndWrite.Model.Models;
using ListenAndWrite.Web.Models;

namespace ListenAndWrite.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {

            Mapper.CreateMap<UserAudio, UserAudioViewModel>();
            Mapper.CreateMap<Audio, AudioViewModel>();
            Mapper.CreateMap<Track, TrackViewModel>();
            Mapper.CreateMap<Score, ScoreViewModel>();
        }
    }
}