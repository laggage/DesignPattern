using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern.Sample.Player
{
    public class MediaPlayer
    {
        public List<Media> _playList;

        public List<Media> PlayList => _playList;

        public IPlayMode PlayMode { get; set; }

        public Media PlayingMedia { get; private set; }


        public MediaPlayer():this(null)
        {
        }

        public MediaPlayer(IEnumerable<Media> mediaList)
        {
            _playList = mediaList == null ? new List<Media>() : new List<Media>(mediaList);
            PlayMode = new OrderPlayMode();
        }

        public void PlayNext()
        {
            PlayingMedia = NextMedia();
            PlayMedia(PlayingMedia);
        }

        protected void PlayMedia(Media media)
        {
            Console.WriteLine($"start to play media, {media.Name}, {media.Duration.Minutes}:{media.Duration.Seconds}");
        }

        protected Media NextMedia()
        {
            return PlayMode.NextMedia(this);
        }
    }
}
