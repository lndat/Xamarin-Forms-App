using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//DataBinding updatet UI bei update im CodeBehind

//Command ruft methoden im codebehind auf bei UI interaktion

// Kann auch beides gleichzeitig genutzt werden, oder einzeln (DataBinding / Command)

namespace AppMitAlles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataBindingTutorial : ContentPage
    {
        public DataBindingTutorial()
        {
            InitializeComponent();
            // BindingContext = new MainViewModel(); //MainViewModel Klasse als BindingContext festgelegt, wird aber im XAML bereits gemacht mit "<ContentPage.BindingContext>" daher auskommentiert
        }
    }
}