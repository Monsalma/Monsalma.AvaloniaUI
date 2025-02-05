using Avalonia;
using Avalonia.Controls;

namespace Monsalma_AvaloniaUserControlDataContext.Controls;

public partial class XAMLDataContextUserControl : UserControl
{
    public static readonly DirectProperty<XAMLDataContextUserControl, string> GreetingProperty = AvaloniaProperty.RegisterDirect<XAMLDataContextUserControl, string>(nameof(Greeting), o => o.Greeting, (o, v) => o.Greeting = v);

    private string greeting;
    public string Greeting
    {
        get => greeting;
        set => SetAndRaise(GreetingProperty, ref greeting, value);
    }

    public XAMLDataContextUserControl()
    {
        InitializeComponent();
    }
}