using DeviceShared.Models;

namespace DeviceClient.Views;

[QueryProperty(nameof(TelemetryModel), "telemetryModel")]
public partial class TelemetryModelPage : ContentPage
{
    public TelemetryModel TelemetryModel
    {
        set { BindingContext = value; }
    }

    public TelemetryModelPage()
	{
		InitializeComponent();
    }

    private async void DoneButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
