namespace DeviceClient
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.TelemetryModelPage), typeof(Views.TelemetryModelPage));
        }
    }
}
