using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Meadow;

namespace DeviceShared.Models;

public class TelemetryModel
{
    /// <summary>
    /// Constuctor to use to create an instance for serialization
    /// </summary>
    /// <param name="telemetryData"></param>
    public TelemetryModel(ITelemetryData telemetryData)
    {
        Created = DateTime.Now;
        Version = telemetryData.GetVersion();
        TypeOfData = telemetryData.GetType().FullName;
        TelemetryDataString = new MicroJsonSerializer().Serialize(telemetryData);
    }

    /// <summary>
    /// Constructor to use to create an instance for deserialization.
    /// </summary>
    public TelemetryModel() {}

    public string? Version { get; set; }
    public DateTime? Created { get; set; }
    public string? TypeOfData { get; set; }
    public string? TelemetryDataString { get; set; }
}
