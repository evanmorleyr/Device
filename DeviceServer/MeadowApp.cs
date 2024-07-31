using Meadow;
using Meadow.Devices;
using Meadow.Foundation.Leds;
using Meadow.Foundation.Web.Maple;
using Meadow.Hardware;
using Meadow.Peripherals.Leds;
using System;
using System.Threading.Tasks;
using DeviceServer.Controllers;
using DeviceServer.Models;

namespace DeviceServer;
public class MeadowApp : App<F7FeatherV2>
{
    MapleServer mapleServer;

    public override async Task Initialize()
    {
        try
        {
            LedController.Instance.SetColor(Color.Red);

            TemperatureController.Instance.Initialize();

            var wifi = Device.NetworkAdapters.Primary<IWiFiNetworkAdapter>();
            wifi.NetworkConnected += NetworkConnected;

            await wifi.Connect(WifiConfig.WIFI_NAME, WifiConfig.WIFI_PASSWORD, TimeSpan.FromSeconds(45));

            Resolver.Log.Info("Initialize completed successfully");
        }
        catch (Exception ex)
        {
            Resolver.Log.Error($"Initialize throw exception: {ex.ToString()}");
        }
    }

    private void NetworkConnected(INetworkAdapter sender, NetworkConnectionEventArgs args)
    {
        mapleServer = new MapleServer(sender.IpAddress, 5417, true, logger: Resolver.Log);
        mapleServer.Start();
        Resolver.Log.Info($@"IP Address: 
            {(sender.IpAddress.IsIPv4MappedToIPv6 ? 
                sender.IpAddress.MapToIPv4() : 
                sender.IpAddress)}");
        LedController.Instance.SetColor(Color.Green);
    }
}