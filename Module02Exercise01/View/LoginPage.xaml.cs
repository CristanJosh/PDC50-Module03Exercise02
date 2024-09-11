using System.Windows.Input;
using Module02Exercise01.Services;

namespace Module02Exercise01.View;

public partial class LoginPage : ContentPage
{
    private readonly IMyService _myService; //Field for the service

	public LoginPage(IMyService myService)
	{
        InitializeComponent();
        _myService = myService;

        var message = _myService.GetMessage();
        MyLabel.Text = message;

        BindingContext = new LoginViewModel(this);
    }

    // para gumana yung login entries
    public string Username => UsernameEntry.Text;
    public string Password => PasswordEntry.Text;
}

public class LoginViewModel
{
    private readonly LoginPage _loginPage;

    public LoginViewModel(LoginPage loginPage)
    {
        _loginPage = loginPage;
        LoginCommand = new Command(OnLogin);
    }

    public ICommand LoginCommand { get; }

    private void OnLogin()
    {
        var username = _loginPage.Username;
        var password = _loginPage.Password;

        // to check if both 'admin' ang nilagay sa user at pass
        if (username == "admin" && password == "admin")
        {
            // if tama,da-direct sila sa EmployeePage
            Application.Current.MainPage = new NavigationPage(new EmployeePage());
        }
        else
        {
            // else, magdidisplay ng alert message
            _loginPage.DisplayAlert("Login Failed", "Invalid username or password. Please try again.", "OK");
        }
    }
}