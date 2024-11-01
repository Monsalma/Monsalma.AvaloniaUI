using Monsalma_AvaloniaNativeVideoPlayer.Services;
using AndroidX.Media3.ExoPlayer;
using AndroidX.Media3.Common;
using Avalonia.Controls;
using Monsalma_AvaloniaNativeVideoPlayer.Android.Controls;

namespace Monsalma_AvaloniaNativeVideoPlayer.Android.Services;

public class ExoPlayerService : INativeMediaPlayerService
{
    private IExoPlayer MainExoPlayer { get; set; }

    public Control CreateControl()
    {
        ExoPlayerControl exoPlayerControl = new();
        exoPlayerControl.AttachedToVisualTree += ExoPlayerControl_AttachedToVisualTree;

        return exoPlayerControl;
    }

    private void ExoPlayerControl_AttachedToVisualTree(object sender, Avalonia.VisualTreeAttachmentEventArgs e)
    {
        if (sender is ExoPlayerControl exoPlayerControl)
        {
            MainExoPlayer = exoPlayerControl.MainExoPlayer;
        }
    }

    public void Play(string uri)
    {
        // Create media item
        MediaItem mediaItem = MediaItem.FromUri(uri);

        // Play media item
        MainExoPlayer.ClearMediaItems();
        MainExoPlayer.AddMediaItem(mediaItem);
        MainExoPlayer.Prepare();
        MainExoPlayer.Play();
    }
}