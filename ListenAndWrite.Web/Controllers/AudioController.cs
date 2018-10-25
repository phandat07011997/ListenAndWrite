using AutoMapper;
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
    public class AudioController : Controller
    {
        IAudioService _audioService;
        public AudioController(IAudioService audioService)
        {
            this._audioService = audioService;
        }
        public ActionResult Level(int? level)
        {
            var listLevel = _audioService.GetListLevel();
            if (level != null)
                ViewBag.Level = level;
            return View(listLevel);
        }
        public ActionResult Choose(int id)
        {
            var audioModel=_audioService.GetById(id);
            audioModel.NumTrack = _audioService.GetTotalTrack(id);
            var audioViewModel = Mapper.Map<Audio,AudioViewModel>(audioModel);
            return View(audioViewModel);
        }
        [HttpGet]
        public JsonResult LoadAudio(int page, int pageSize, int? level)
        {
            int totalRow = 0;
            var audioModel = _audioService.GetLastestActiveAudio(level, page, pageSize, out totalRow);
            var audioViewModel = Mapper.Map<IEnumerable<Audio>, IEnumerable<AudioViewModel>>(audioModel);
            return Json(new
            {
                Items = audioViewModel,
                TotalCount = totalRow,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}