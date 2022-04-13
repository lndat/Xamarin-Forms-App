
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
    public partial class ColorPicker : ContentPage
    {
        public ColorPicker()
        {
            InitializeComponent();
        }

        public void ColorPickera()
        {
            double er = rSlider.Value;
            double ge = gSlider.Value;
            double be = bSlider.Value;
            double ap = occuSlider.Value;

            Color cp = Color.FromRgba(er, ge, be, ap);
            colorBox.BackgroundColor = cp;

        }

        private void rSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ColorPickera();
        }

        private void gSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ColorPickera();
        }

        private void bSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ColorPickera();
        }

        private void occuSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ColorPickera();
        }

        private void rotoSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double rot = rotoSlider.Value;
            colorBox.Rotation = rot;
        }

        private void kanteRundSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double cr = kanteRundSlider.Value;
            colorBox.CornerRadius = cr;
        }
    }
}