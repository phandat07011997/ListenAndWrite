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
        [HttpGet]
        public JsonResult LoadAudio(int page, int pageSize)
        {
            int totalRow = 0;
            var audioModel = _audioService.GetLastestAudio(page, pageSize, out totalRow);
            var audioViewModel = Mapper.Map<IEnumerable<Audio>, IEnumerable<AudioViewModel>>(audioModel);
            
            return Json(new
            {
                Items = audioViewModel,
                TotalCount = totalRow,
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteAudio(int audioId)
        {
            _audioService.Delete(audioId);
            _audioService.Save();
            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Upload(HttpPostedFileBase file)
        {
            //file.SaveAs(Server.MapPath("~/Upload/" + file.FileName));
            //file.InputStream.Close();
            //file.InputStream.Dispose();
            //file.InputStream = null;

            
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath("~/Upload/" + file.FileName));
                    file.InputStream.Close();
                    file.InputStream.Dispose();
                    GC.Collect();

                    // other operations, where can occur an exception 
                    // (because the uploaded file can have a bad content etc.)
                }
            }
            catch (Exception e)
            {
                if (file.InputStream != null)
                    file.InputStream.Dispose();

                GC.Collect();

                if (!string.IsNullOrEmpty(Server.MapPath("~/Upload/" + file.FileName)))
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Upload/" + file.FileName)))
                        System.IO.File.Delete(Server.MapPath("~/Upload/" + file.FileName)); //here is the error
                }
            }
            return "/Upload/" + file.FileName;
        }
    }
}