﻿using ListenAndWrite.Model.Models;
using ListenAndWrite.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListenAndWrite.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateAudio(this Audio audio, AudioViewModel audioVM)
        {
            audio.Id = audioVM.Id;
            audio.AudioTitle = audioVM.AudioTitle;
            audio.Path = audioVM.Path;
            audio.Level = audioVM.Level;
            audio.Duration = audioVM.Duration;
            audio.Description = audioVM.Description;
            audio.CreatedBy = audioVM.CreatedBy;
            audio.CreatedDate = audioVM.CreatedDate;
            audio.UpdateBy = audioVM.UpdateBy;
            audio.UpdateDate = audioVM.UpdateDate;
            audio.Status = audioVM.Status;
            audio.NumTrack = audioVM.NumTrack;

        }
        public static void UpdateTrack(this Track track , TrackViewModel trackVM)
        {
            track.Id = trackVM.Id;
            track.AudioId = trackVM.AudioId;
            track.Answer = trackVM.Answer;
            track.TrackTitle = trackVM.TrackTitle;
            track.TimeStart = trackVM.TimeStart;
            track.Duration = trackVM.Duration;
        }

    }
}
