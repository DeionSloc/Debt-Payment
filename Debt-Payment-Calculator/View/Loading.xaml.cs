using Debt_Payment_Calculator.Service;

namespace Debt_Payment_Calculator.View;

public partial class Loading : ContentPage
{
    private readonly AuthService _authService;
    public Loading(AuthService authservice)
	{
		InitializeComponent();
        _authService = authservice;
    }
    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (await _authService.IsAuthenticatedAsync())
        {
            //User is logged in and redirected to the home page, or 'dashboard'
        }
        else
        {
            //User is not logged in and is redirected to login page
            await Shell.Current.GoToAsync($"//{nameof(Dashboard)}");
        }
    }

}