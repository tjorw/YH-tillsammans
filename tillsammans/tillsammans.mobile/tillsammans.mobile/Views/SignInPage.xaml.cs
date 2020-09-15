using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tillsammans.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tillsammans.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        IAuthService authService;

        public SignInPage()
        {
            InitializeComponent();

            authService = DependencyService.Get<IAuthService>();

        }

        private async void OnSignInClicked(object sender, EventArgs e)
        {
            var request = new SignInRequest() { Name = usernameEntry.Text, Password = passwordEntry.Text };

            try
            {
                var response = await authService.SignIn(request);


                if (response.Session != null)
                {
                    messageLabel.Text = $"Logged in as {response.Session.UserId}";
                }
                else
                {
                    messageLabel.Text = "Not logged in";
                }

            } catch (Exception ex)
            {
                messageLabel.Text = ex.Message;
            }

        }
    }
}