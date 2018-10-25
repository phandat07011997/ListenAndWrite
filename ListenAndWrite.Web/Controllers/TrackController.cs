using AutoMapper;
using ListenAndWrite.Model.Models;
using ListenAndWrite.Service;
using ListenAndWrite.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListenAndWrite.Web.Controllers
{
    public class TrackController : Controller
    {
        IAudioService _audioService;
        ITrackService _trackService;
        public TrackController(ITrackService trackService,IAudioService audioService)
        {
            this._audioService = audioService;
            this._trackService = trackService;
        }
        [HttpGet]
        public JsonResult LoadTrack(int audioId, int track)
        {
            var trackModel = _trackService.GetTrackByAudioId(track, audioId);
            var trackVM = Mapper.Map<Track, TrackViewModel>(trackModel);
            return Json(new
            {
                Item = trackVM,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}