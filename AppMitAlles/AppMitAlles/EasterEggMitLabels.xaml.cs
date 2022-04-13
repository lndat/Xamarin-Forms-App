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
    public partial class EasterEggMitLabels : ContentPage
    {
        int clickCounter = 0;
        public EasterEggMitLabels()
        {
            InitializeComponent();
        }
        void RandomWordGen()
        {
            var rndWord = new Random();
            string[] rndWordsArray = new string[] { "BBRZ", "Xamarin", "Test", "Apple", "Microsoft", "Gut", "Hmm..", "Hallo", "AP05", "OK", "Android", "Pause", "RGB" };
            int randomIndexer = rndWord.Next(rndWordsArray.Length);
            randomTextLabel.Text = rndWordsArray[randomIndexer];
        }

        private void randomButton_Clicked(object sender, EventArgs e)
        {
            RandomWordGen();
        }

        private void easterEggButton_Clicked(object sender, EventArgs e)
        {
            MyEasterEgg();
        }
        void MyEasterEgg()
        {
            clickCounter++;
            if (clickCounter == 5)
            {
                GridColor.BackgroundColor = Color.FromRgb(197, 210, 236);
                easterEggButton.BackgroundColor = Color.FromRgb(234, 255, 201);
                easterEggButton.Text = "EASTER EGG!";
            }
        }
    }

}