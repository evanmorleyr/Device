using System;
using System.Collections.Generic;
using System.Text;
using DeviceShared.Models;

namespace DeviceServer.Models;
public class TemperatureData : ITelemetryData
{
    public string Temperature  { get; set; }
    public TemperatureUnitsEnum TemperatureUnits { get; set; }

    public string GetVersion()
    {
        return "1";
    }
    public string Created => DateTime.Now.ToString();
}