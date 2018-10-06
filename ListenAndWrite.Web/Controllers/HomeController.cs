﻿using AutoMapper;
using ListenAndWrite.Model.Models;
using ListenAndWrite.Service;
using ListenAndWrite.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ListenAndWrite.Web.Controllers
{
    public class HomeController : Controller
    {
        private IAudioService _audioService;

        public HomeController(IAudioService audioService)
        {
            this._audioService = audioService;
        }

        public ActionResult Index(int? level)
        {
            if (level != null)
                ViewBag.Level = level;
            return View();
        }

        [HttpGet]
        public JsonResult LoadAudio(int page, int pageSize, int? level)
        {
            int totalRow = 0;
            var audioModel =_audioService.GetLastestActiveAudio(level, page, pageSize, out totalRow);
            var audioViewModel = Mapper.Map<IEnumerable<Audio>, IEnumerable<AudioViewModel>>(audioModel);
            return Json(new
            {
                Items = audioViewModel,
                TotalCount = totalRow,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}