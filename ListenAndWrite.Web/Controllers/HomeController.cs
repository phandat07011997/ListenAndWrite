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

        public ActionResult Index(string search)
        {
            var listLevel = _audioService.GetListLevel();
            ViewBag.SearchContent = search;
            return View(listLevel);
        }

        
    }
}