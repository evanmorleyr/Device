using DeviceShared.Models;


namespace DeviceClient.Views;

public partial class TelemetryModelsPage : ContentPage
{
    public TelemetryModelsPage()
    {
        InitializeComponent();

        BindingContext = new Models.TelemetryModels();
    }

    protected override void OnAppearing()
    {
        _ = ((Models.TelemetryModels)BindingContext).LoadTelemetryModels();
    }

    private async void telemetryModelCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var telemetryModel = (TelemetryModel)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            //await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.FullyQualifiedFileName}");

            await Shell.Current.GoToAsync($"{nameof(TelemetryModelPage)}", true, new Dictionary<string, object>
            {
                {
                    "telemetryModel",
                    telemetryModel
                }
            });
            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}