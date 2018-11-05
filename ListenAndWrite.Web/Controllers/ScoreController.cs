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
    public class ScoreController : Controller
    {
        // GET: Score
        IScoreService _scoreService;
        public ScoreController (IScoreService scoreService)
        {
            this._scoreService = scoreService;
        }
        [HttpPost]
        public JsonResult AddScore(Score score)
        {
            score.CreateDate = DateTime.Now;

            _scoreService.Add(score);
            _scoreService.Save();
            return Json(new
            {
                Status = true
            });
        }
        [HttpPost]
        public JsonResult GetLastScores(Score score)
        {
            var scoreModels=_scoreService.GetListScoreByUserIdAndAudioId(score.AudioId, score.UserId);
            var scoreViewModels = Mapper.Map<IEnumerable<Score>, IEnumerable<ScoreViewModel>>(scoreModels);
            return Json(new
            {
                Items = scoreViewModels,
                Status = true
            });
        }
    }
}