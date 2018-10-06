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
                return RedirectToAction("AddTrack", "Track", new { audioId = audio.Id });
            }
            return View();
        }
    }
}