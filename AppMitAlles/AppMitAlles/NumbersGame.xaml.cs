using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMitAlles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NumbersGame : ContentPage
    {
        int counter = 0;
        public NumbersGame()
        {
            InitializeComponent();
        }

        private void plusButton_Clicked(object sender, EventArgs e)
        {
            counter++;
            viewZahl.Text = counter.ToString();
            if (counter == 10)
            {
                Vibration.Vibrate();
            }
        }
        private void minusButton_Clicked(object sender, EventArgs e)
        {
            counter--;
            viewZahl.Text = counter.ToString();
            if (counter == -10)
            {
                Vibration.Vibrate();
            }
        }

        private void resetButton_Clicked(object sender, EventArgs e)
        {
            counter = 0;
            viewZahl.Text = counter.ToString();
        }
    }
}