using Meadow;
using Meadow.Foundation.Web.Maple.Routing;
using Meadow.Foundation.Web.Maple;
using System;
using System.Collections.Generic;
using System.Text;
using DeviceServer.Controllers;

namespace DeviceServer.MapleRequestHandlers;

public class MapleRequestHandler : RequestHandlerBase
{
    public MapleRequestHandler() { }

    [HttpGet("/gettemperaturelogs")]
    public IActionResult GetTemperatureLogs()
    {
        LedController.Instance.SetColor(Color.Cyan);

        var data = TemperatureController.Instance.TemperatureLogs;

        LedController.Instance.SetColor(Color.Green);
        return new JsonResult(data);
    }
}
