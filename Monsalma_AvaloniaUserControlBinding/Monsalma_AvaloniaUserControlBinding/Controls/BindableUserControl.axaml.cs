using Avalonia;
using Avalonia.Controls;

namespace Monsalma_AvaloniaUserControlBinding.Controls;

public partial class BindableUserControl : UserControl
{
    public static readonly DirectProperty<BindableUserControl, string> GreetingProperty = AvaloniaProperty.RegisterDirect<BindableUserControl, string>(nameof(Greeting), o => o.Greeting, (o, v) => o.Greeting = v);

    private string greeting;
    public string Greeting
    {
        get => greeting;
        set => SetAndRaise(GreetingProperty, ref greeting, value);
    }

    public BindableUserControl()
    {
        InitializeComponent();
    }
}