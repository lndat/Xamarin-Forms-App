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
    public partial class TxtToSpeech : ContentPage
    {
        public TxtToSpeech()
        {
            InitializeComponent();
        }

        private void speechButton_Clicked(object sender, EventArgs e)
        {
            Task tasker = SpeakNow(textInput.Text);

        }

        public async Task SpeakNow(string speak)
        {
            await TextToSpeech.SpeakAsync(speak);
        }
    }
}