using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform;
using Avalonia.Threading;
using LibVLCSharp.Shared;
using System;
using System.IO;

namespace Monsalma_AvaloniaAudioTest_Resource.Views;

public partial class MainView : UserControl
{
    private LibVLC MainLibVLC { get; set; }
    private MediaPlayer MainMediaPlayer { get; set; }
    private Stream MediaStream { get; set; }

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
        MediaStream?.Dispose();

        MediaStream = AssetLoader.Open(new Uri(MediaURI.Text));
        using var media = new Media(MainLibVLC, new StreamMediaInput(MediaStream));

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
