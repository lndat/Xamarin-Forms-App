using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMitAlles
{
    public partial class MainPage : ContentPage
    {
        //int contra = 0; // für das easteregg mit 5x drücken
        public MainPage()
        {
            InitializeComponent();
        }

        private void loginPageButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        private void numbersGameButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new NumbersGame());
        }

        private void bindingPageButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new BindingPage());
        }

        private void ticTacToeButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new TicTacToePage());
        }

        private void colorPickerButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ColorPicker());
        }

        private void labelTextEasterEgg_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new EasterEggMitLabels());
        }

        private void bindingTutorialButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new DataBindingTutorial());
        }

        private void toDoListeButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ToDoList());
        }

        private void jsonUebungButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new jsonUebung());
        }

        private void sqliteButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new Sqlite());
        }

        private void bruttoButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new BruttoNetto());
        }

        private void OMDbButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new OMDbAPI());
        }

        private void TxtToSpeechButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new TxtToSpeech());
        }

        private void MapsButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new Maps());
        }

        private void BluetoothButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new Bluetooth());
        }
    }
}
