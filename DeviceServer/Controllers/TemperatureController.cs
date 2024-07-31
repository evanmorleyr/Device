using Meadow; 
using Meadow.Foundation.Sensors.Temperature;
using Meadow.Peripherals.Sensors;
using Meadow.Units;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DeviceServer.Models;
using DeviceShared.Models;

namespace DeviceServer.Controllers;
public class TemperatureController
{
    ITemperatureSensor analogTemperature;

    private static readonly Lazy<TemperatureController> instance =
        new Lazy<TemperatureController>(() => new TemperatureController());
    public static TemperatureController Instance => instance.Value;

    public ObservableCollection<TelemetryModel> TemperatureLogs { get; private set; }

    private TemperatureController() { }

    public void Initialize()
    {
        TemperatureLogs = new ObservableCollection<TelemetryModel>();

        analogTemperature = new AnalogTemperature(MeadowApp.Device.Pins.A01,
            AnalogTemperature.KnownSensorType.LM35);
        analogTemperature.Updated += AnalogTemperatureUpdated;
        analogTemperature.StartUpdating(TimeSpan.FromSeconds(30));
    }

    private void AnalogTemperatureUpdated(object sender, Meadow.IChangeResult<Meadow.Units.Temperature> e)
    {
        int TIMEZONE_OFFSET = -8;

        LedController.Instance.SetColor(Color.Magenta);

        var telemetryModel = new TelemetryModel(
            new TemperatureData()
            {
                Temperature = e.New.Fahrenheit.ToString("00"),
                TemperatureUnits = TemperatureUnitsEnum.fahrenheit
            }
        );
        TemperatureLogs.Add(telemetryModel);    

        LedController.Instance.SetColor(Color.Green);
    }
}
