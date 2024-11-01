using Avalonia.Controls;
using Monsalma_AvaloniaNativeVideoPlayer.Services;

namespace Monsalma_AvaloniaNativeVideoPlayer.Views;

public partial class MainView : UserControl
{
    private INativeMediaPlayerService MediaPlayerService { get; set; }

    public MainView()
    {
        InitializeComponent();
        InitMediaPlayer();
    }

    private void InitMediaPlayer()
    {
        MediaPlayerService = new NativeMediaPlayerService(App.AppNativeVideoPlayerService);
        Control mediaPlayerControl = MediaPlayerService.CreateControl();

        mediaPlayerControl.Width = 400;
        mediaPlayerControl.Height = 300;

        VideoContainer.Children.Clear();
        VideoContainer.Children.Add(mediaPlayerControl);
    }

    private void Button_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MediaPlayerService.Play(MediaURI.Text);
    }
}
