using System.Diagnostics;
using Module02Exercise01.View;
using Microsoft.Maui.Networking;
using Module02Exercise01.Services;

namespace Module02Exercise01
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            MainPage = new AppShell();
            _serviceProvider = serviceProvider;

        }

        protected override void OnStart()
        {
            base.OnStart();
            CheckNetworkConnectivity();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            Debug.WriteLine("The app is in sleep mode.");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Debug.WriteLine("The app has resumed.");
            CheckNetworkConnectivity();
        }

        private async void CheckNetworkConnectivity()
        {
            var current = Connectivity.Current;

            if (current.NetworkAccess == NetworkAccess.Internet)
            {
                //Attempt I-ping yung website if its accessible ig? whahaha
                try
                {
                    using var httpClient = new HttpClient();
                    var result = await httpClient.GetAsync("https://google.com");

                    if (result.IsSuccessStatusCode)
                    {
                        // Navigate to LoginPage if connected
                        //MainPage = new NavigationPage(new LoginPage());
                        MainPage = _serviceProvider.GetRequiredService<LoginPage>();
                    }
                    else
                    {
                        // Navigate to OfflinePage if ping fails
                        //MainPage = new OfflinePage();
                        MainPage = _serviceProvider.GetRequiredService<OfflinePage>();
                    }
                }
                catch
                {

                    MainPage = _serviceProvider.GetRequiredService<OfflinePage>();

                }
            }
            else
            {

                MainPage = _serviceProvider.GetRequiredService<OfflinePage>();

            }
        }
    }
}