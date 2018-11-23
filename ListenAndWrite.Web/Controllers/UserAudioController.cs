using AutoMapper;
using ListenAndWrite.Model.Models;
using ListenAndWrite.Service.Properties;
using ListenAndWrite.Web.Infrastructure.Extensions;
using ListenAndWrite.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListenAndWrite.Web.Controllers
{
    [Authorize]
    public class UserAudioController : Controller
    {
        private IUserAudioService _userAudioService;

        public UserAudioController(IUserAudioService userAudioService)
        {
            this._userAudioService = userAudioService;
        }
        // GET: UserAudio
        public ActionResult Index()
        {
            var userAudioModels = _userAudioService.GetAll(User.Identity.GetUserId());
            var userAudioViewModels = Mapper.Map<IEnumerable<UserAudio>, IEnumerable<UserAudioViewModel>>(userAudioModels);
            return View(userAudioViewModels);
        }
        
        public ActionResult Delete(int id)
        {
            _userAudioService.Delete(id);
            _userAudioService.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userAudioViewModel = Mapper.Map<UserAudio, UserAudioViewModel>(_userAudioService.GetById(id));
            return View(userAudioViewModel);
        }
        [HttpPost]
        public ActionResult Edit(UserAudioViewModel userAudioViewModel)
        {
            UserAudio userAudioModel = new UserAudio();
            userAudioModel.UpdateUserAudio(userAudioViewModel);
            _userAudioService.Update(userAudioModel);
            _userAudioService.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserAudioViewModel userAudioViewModel)
        {
            if (ModelState.IsValid)
            {
                UserAudio userAudioModel = new UserAudio();
                userAudioModel.UpdateUserAudio(userAudioViewModel);
                userAudioModel.CreatedDate = DateTime.Now;
                userAudioModel.UserId = User.Identity.GetUserId();
                _userAudioService.Add(userAudioModel);
                _userAudioService.Save();
                return RedirectToAction("Index");
            }
            return View();


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
                    file.SaveAs(Server.MapPath("~/UserUpload/" + file.FileName));
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

                if (!string.IsNullOrEmpty(Server.MapPath("~/UserUpload/" + file.FileName)))
                {
                    if (System.IO.File.Exists(Server.MapPath("~/UserUpload/" + file.FileName)))
                        System.IO.File.Delete(Server.MapPath("~/UserUpload/" + file.FileName)); //here is the error
                }
            }
            return "/UserUpload/" + file.FileName;
        }
    }
}