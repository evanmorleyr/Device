using DeviceShared.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DeviceClient.Models;

internal class TelemetryModels
{
    public ObservableCollection<TelemetryModel> TelemetryModelCollection { get; set; } = new ObservableCollection<TelemetryModel>();

    public TelemetryModels() =>
        LoadTelemetryModels();

    public void LoadTelemetryModels()
    {
        TelemetryModelCollection.Clear();

        var telemetryModelsString =
        """
        [
            {
                "Version": "1",
                "Created": "2024-06-10T21:23:07.03437Z",
                "TypeOfData": "DeviceServer.Models.TemperatureData",
                "TelemetryDataString": "{\"created\":\"06/10/2024 21:23:08\",\"temperature\":\"75\",\"temperatureUnits\":0}"
            },
            {
                "Version": "1",
                "Created": "2024-06-10T21:23:39.12837Z",
                "TypeOfData": "DeviceServer.Models.TemperatureData",
                "TelemetryDataString": "{\"created\":\"06/10/2024 21:23:39\",\"temperature\":\"75\",\"temperatureUnits\":0}"
            }
        ]
        """;

        JsonSerializer.Deserialize<IEnumerable<TelemetryModel>>(telemetryModelsString)
            ?.Select(telemetryModel =>
            {
                TelemetryModelCollection.Add(telemetryModel);
                return telemetryModel;
            })
            .ToList();
    }
}
