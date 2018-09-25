﻿using AutoMapper;
using ListenAndWrite.Model.Models;
using ListenAndWrite.Service;
using ListenAndWrite.Web.Infrastructure.Extensions;
using ListenAndWrite.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListenAndWrite.Web.Controllers
{
    public class AdminController : Controller
    {
        IAudioService _audioService;
        ITrackService _trackService;
        public AdminController(IAudioService audioService, ITrackService trackService)
        {
            this._trackService = trackService;
            this._audioService = audioService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListAudio()
        {
            return View();
        }
        public ActionResult AddAudio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAudio(AudioViewModel audioViewModel)
        {
            if (ModelState.IsValid)
            {
                Audio audioModel = new Audio();
                audioModel.UpdateAudio(audioViewModel);
                audioModel.CreatedDate = DateTime.Now;
                var audio = _audioService.Add(audioModel);
                _audioService.Save();
                return RedirectToAction("AddTrack", "Admin", new { audioId = audio.Id });
            }
            return View();
        }

        public ActionResult AddTrack(int audioId)
        {
            var audioViewModel = Mapper.Map<Audio, AudioViewModel>(_audioService.GetById(audioId));
            return View(audioViewModel);
        }

        public JsonResult GetTracks(int audioId)
        {
            return Json(
                    new
                    {
                        status = true,
                        data = _trackService.GetListTrackByAudioId(audioId)
                    }, JsonRequestBehavior.AllowGet
                    );
        }
        public JsonResult SaveTrack(Track track)
        {
            var num = _trackService.GetListTrackByAudioId(track.AudioId).Count() + 1;
            var audio = _audioService.GetById(track.AudioId);
            track.TrackTitle = track.AudioId + "_" + audio.AudioTitle + "_track_" + num;
            _trackService.Add(track);
            _trackService.Save();
            return Json(
                new
                {
                    status = true
                }, JsonRequestBehavior.AllowGet
                );
        }
        public JsonResult ClearTrack(int audioId)
        {
            _trackService.DeleteByAudioId(audioId);
            _trackService.Save();
            return Json(
                new
                {
                    status = true
                }, JsonRequestBehavior.AllowGet
                );
        }
    }
}