using System;
using System.Collections.Generic;
using System.Linq;

namespace StatePattern.Sample.Player
{
    /// <summary>
    /// 顺序播放状态
    /// </summary>
    public class OrderPlayMode : IPlayMode
    {
        public Media NextMedia(MediaPlayer player)
        {
            Media playingMedia = player.PlayingMedia;
            Media result = null;
            if (playingMedia != null)
            {
                int index = player.PlayList.FindIndex((m) => m == playingMedia)+1;
                result = index < player.PlayList.Count ? player.PlayList[index] : result;
            }
            else
                result = player.PlayList.FirstOrDefault();
            return result;
        }

        public override string ToString()
        {
            return "顺序播放";
        }
    }

    /// <summary>
    /// 随机播放
    /// </summary>
    public class RandomPlayMode : IPlayMode
    {
        public Media NextMedia(MediaPlayer player)
        {
            IList<Media> playList = player.PlayList;
            Media playingMedia = player.PlayingMedia;
            Media result;
            if (playingMedia == null)
            {
                int index = new Random().Next(0, playList.Count);
                result = index < playList.Count ? playList[index] : null;
            }
            else
            {
                var rand = new Random();
                int index = playList.IndexOf(playingMedia);
                if (index < playList.Count-1 && index > 0)
                    index = rand.Next(0, 1) == 0 ? rand.Next(0, index-1) : rand.Next(index+1, playList.Count);
                else if (index == playList.Count) index = rand.Next(0, index-1);
                else if (index == 0) index = playList.Count > 1 ? rand.Next(1, playList.Count) : 0;
                result = playList[index];
            }
            return result;
        }

        public override string ToString()
        {
            return "随机播放";
        }
    }
}
