using Xamarin.Essentials;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMitAlles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoList : ContentPage
    {
        public ObservableCollection<ShoppingItemModel> listItem = new ObservableCollection<ShoppingItemModel>();

        public ToDoList()
        {
            InitializeComponent();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            einkaufsListe.ItemsSource = listItem;

            ShoppingItemModel newItem = new ShoppingItemModel();
            newItem.Name = this.prdEingabe.Text;
            newItem.Quantity = 1;

            if (this.prdEingabe.Text != "")
            {
                listItem.Add(newItem);
                Task tasker = SpeakNow("Produkt " + newItem.Name + " hinzugefügt!");
            }
            else
            {
                DisplayAlert("no text", "No empty pls", "ok");
                Task tasker = SpeakNow("Sie müssen schon etwas eingeben!");
            }

            prdEingabe.Text = string.Empty;
        }

        public async Task SpeakNow(string speak)
        {
            await TextToSpeech.SpeakAsync(speak);
        }

        async void einkaufsListe_ItemTapped_2(object sender, ItemTappedEventArgs e)
        {
            var dalert = await DisplayAlert("Delete", "Delete " + listItem[e.ItemIndex].Name + "?", "Yes", "No");
            if (dalert)
            {
                listItem.RemoveAt(e.ItemIndex);
                Task tasker = SpeakNow("Produkt gelöscht!");
            }
            else
            {
                return;
            }
        }
    }
}