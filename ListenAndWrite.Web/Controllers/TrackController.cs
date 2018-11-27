using AutoMapper;
using ListenAndWrite.Common;
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
        [HttpGet]
        public JsonResult CompareInput(string input, string answer)
        {
            int[,] F = new int[256, 256];
            String[] inputs = input.ToLower().Split(' ');
            String[] subStrs = answer.ToLower().Split(' ');
            String[] saves = new String[256];
            for (int i = 0; i <= subStrs.Length; i++)
            {
                F[i, 0] = 0;
            }
            for (int i = 0; i <= inputs.Length; i++)
            {
                F[0, i] = 0;
            }

            for (int i = 0; i < subStrs.Length; i++)
            {
                for (int j = 0; j < inputs.Length; j++)
                {
                    if (inputs[j] == subStrs[i])
                    {
                        F[i + 1, j + 1] = F[i, j] + 1;
                        saves[F[i + 1, j + 1] - 1] = inputs[j];
                    }
                    else
                    {
                        F[i + 1, j + 1] = Math.Max(F[i + 1, j], F[i, j + 1]);
                    }
                }
            }

            String save = String.Join(" ", saves, 0, F[subStrs.Length, inputs.Length]);
            
            
            return Json(new
            {
                SameWords = save

              
            }, JsonRequestBehavior.AllowGet);
        }
    }
}