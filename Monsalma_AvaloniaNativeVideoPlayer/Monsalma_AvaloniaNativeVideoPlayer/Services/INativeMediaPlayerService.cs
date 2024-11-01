using Avalonia.Controls;

namespace Monsalma_AvaloniaNativeVideoPlayer.Services
{
    public interface INativeMediaPlayerService
    {
        Control CreateControl();
        void Play(string uri);
    }
}
