using Avalonia.Controls;

namespace Monsalma_AvaloniaNativeVideoPlayer.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        InitMediaPlayer();
    }

    private void InitMediaPlayer()
    {
        Control mediaPlayerControl = App.AppNativeVideoPlayerService.CreateControl();

        mediaPlayerControl.Width = 400;
        mediaPlayerControl.Height = 300;

        VideoContainer.Children.Clear();
        VideoContainer.Children.Add(mediaPlayerControl);
    }

    private void Button_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        App.AppNativeVideoPlayerService.Play(MediaURI.Text);
    }
}
