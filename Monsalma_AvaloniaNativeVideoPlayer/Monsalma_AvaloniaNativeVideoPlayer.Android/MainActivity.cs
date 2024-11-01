using Android.App;
using Android.Content.PM;

using Avalonia;
using Avalonia.Android;
using Monsalma_AvaloniaNativeVideoPlayer.Android.Services;

namespace Monsalma_AvaloniaNativeVideoPlayer.Android;

[Activity(
    Label = "Monsalma_AvaloniaNativeVideoPlayer.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        App.AppNativeVideoPlayerService = new ExoPlayerService();

        return base.CustomizeAppBuilder(builder)
            .WithInterFont();
    }
}
