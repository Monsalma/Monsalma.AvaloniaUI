using Avalonia;
using Avalonia.Controls;

namespace Monsalma_AvaloniaUserControlDataContext.Controls;

public partial class RuntimeDataContextUserControl : UserControl
{
    public static readonly DirectProperty<RuntimeDataContextUserControl, string> GreetingProperty = AvaloniaProperty.RegisterDirect<RuntimeDataContextUserControl, string>(nameof(Greeting), o => o.Greeting, (o, v) => o.Greeting = v);

    private string greeting;
    public string Greeting
    {
        get => greeting;
        set => SetAndRaise(GreetingProperty, ref greeting, value);
    }

    public RuntimeDataContextUserControl()
    {
        InitializeComponent();

        DataContext = this;
    }
}