using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using LibVLCSharp.Shared;
using System;

namespace Monsalma_AvaloniaAudioTest.Views;

public partial class MainView : UserControl
{
    private LibVLC MainLibVLC { get; set; }
    private MediaPlayer MainMediaPlayer { get; set; }

    public MainView()
    {
        InitializeComponent();
        InitMediaPlayer();
    }

    private void InitMediaPlayer()
    {
        MainLibVLC = new(enableDebugLogs: true);
        
        MainMediaPlayer = new(MainLibVLC);
        MainMediaPlayer.TimeChanged += MediaPlayer_TimeChanged;
    }

    public void ClickHandler(object sender, RoutedEventArgs args)
    {
        Media media = new(MainLibVLC, new Uri(MediaURI.Text));
        MainMediaPlayer.Media = media;
        MainMediaPlayer.Play();
    }

    private void MediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
    {
        Dispatcher.UIThread.Invoke(
            new Action(
                () =>
                {
                    PlaybackStatus.Text = $"{MainMediaPlayer.Time / 1000.0} / {MainMediaPlayer.Length / 1000.0}";
                }
            )
        );
    }
}
