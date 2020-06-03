using System;

namespace StatePattern.Sample.Player
{
    class PlayerSampleClient
    {
        public static void Run()
        {
            var medias = new Media[] 
            {
                new Media("爱如潮水", "张信哲", DateTime.Now, new TimeSpan(0, 3, 20)),
                new Media("吻别", "张卫健", DateTime.Now, new TimeSpan(0, 3, 5)),
                //new Media("放生", "陈阳", DateTime.Now, new TimeSpan(0, 4, 34)),
                //new Media("稻香", "周杰伦", DateTime.Now, new TimeSpan(0, 2, 20)),
                //new Media("一人愿", "沈雨轩", DateTime.Now, new TimeSpan(0, 3, 20)),
            };
            var player = new MediaPlayer(medias);   // default OrderPlayMode
            player.PlayNext();
            player.PlayMode = new RandomPlayMode();
            player.PlayNext();
        }
    }
}
