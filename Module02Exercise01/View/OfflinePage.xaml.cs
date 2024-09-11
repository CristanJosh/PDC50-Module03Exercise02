using System.Windows.Input;
using Module02Exercise01.Services;

namespace Module02Exercise01.View;

public partial class OfflinePage : ContentPage
{
    private readonly IMyService _myService; //Field for the service
    public OfflinePage(IMyService myService)
	{
        InitializeComponent();
        _myService = myService;

        var message = _myService.GetMessage();
        MyLabel1.Text = message;

        BindingContext = new OfflineViewModel();
    }
}

public class OfflineViewModel
{
    public ICommand RetryCommand { get; }
    public ICommand CloseCommand { get; }

    public OfflineViewModel()
    {
        RetryCommand = new Command(() => Application.Current.MainPage = new AppShell());
        CloseCommand = new Command(() => System.Diagnostics.Process.GetCurrentProcess().Kill());
    }
}
