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
        public ActionResult AddTrack(int audioId)
        {
            var audioViewModel = Mapper.Map<Audio, AudioViewModel>(_audioService.GetById(audioId));
            return View(audioViewModel);
        }
    }
}