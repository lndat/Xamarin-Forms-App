using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMitAlles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public string storedUsername = "Hans";
        public string storedPassword = "1234";

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Loginer_Click(object sender, EventArgs e)
        {
            saveRoutine();
        }

        private void loginSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (loginSwitch.IsToggled == true)
            {

                if (userLogin.Text == storedUsername && passLogin.Text == storedPassword)
                {
                    userLogin.Text = storedUsername;
                    passLogin.Text = storedPassword;
                    loginText.Text = "Logindata saved!";
                }
                else
                {
                    loginText.Text = "Cant save wrong data!";
                }

            }
            else
            {
                loginText.Text = "Save logindata";
            }

        }
        private void saveRoutine()
        {
            if (userLogin.Text != storedUsername || passLogin.Text != storedPassword)
            {
                StatusText.Text = "Falscher Username/Passwort";
            }
            else
            {
                StatusText.Text = "Willkommen!";
                App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
        }

    }
}