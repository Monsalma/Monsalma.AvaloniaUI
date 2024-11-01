using Avalonia.Controls;

namespace Monsalma_AvaloniaNativeVideoPlayer.Services
{
    public class NativeMediaPlayerService(INativeMediaPlayerService nativeVideoPlayerService) : INativeMediaPlayerService
    {
        public Control CreateControl()
        {
            return nativeVideoPlayerService.CreateControl();
        }

        public void Play(string uri)
        {
            nativeVideoPlayerService.Play(uri);
        }
    }
}
