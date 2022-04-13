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
    public partial class Sqlite : ContentPage
    {
        public Sqlite()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //Get All Persons  
            var tempCarList = await App.SQLiteDb.GetCarsAsync();
            if (tempCarList != null)
            {
                carList.ItemsSource = tempCarList;
            }
        }

        private async void addBar_Clicked(object sender, EventArgs e)
        {
            string popInput = await DisplayPromptAsync("Add Car", "Enter car name", maxLength: 20, placeholder: "Car name");

            if (!string.IsNullOrEmpty(popInput))
            {
                AutoModel auto = new AutoModel()
                {
                    Name = popInput
                };

                //Add Car  
                await App.SQLiteDb.SaveCarAsync(auto);
                popInput = string.Empty;

                await DisplayAlert("Success", "Car added successfully", "OK");
                //Get All Cars  
                var tempCarList = await App.SQLiteDb.GetCarsAsync();
                if (tempCarList != null)
                {
                    carList.ItemsSource = tempCarList;
                }
            }
            else if (popInput == null)
            {
                await DisplayAlert("Canceled", "No car was added", "OK");
            }
            else
            {
                await DisplayAlert("Required", "Please Enter name!", "OK");
            }
        }

        private async void deleteBar_Clicked(object sender, EventArgs e)
        {
            string popInput = await DisplayPromptAsync("Edit Car", "Enter car id", maxLength: 5, placeholder: "Car id");

            if (!string.IsNullOrEmpty(popInput))
            {
                var auto = await App.SQLiteDb.GetCarAsync(Convert.ToInt32(popInput));
                if (auto != null)
                {
                    await App.SQLiteDb.DeleteCarAsync(auto);
                    popInput = string.Empty;
                    await DisplayAlert("Success", "Car deleted", "OK");

                    var tempCarList = await App.SQLiteDb.GetCarsAsync();
                    if (tempCarList != null)
                    {
                        carList.ItemsSource = tempCarList;
                    }
                }
            }
            else if (popInput == null)
            {
                await DisplayAlert("Canceled", "No car was deleted", "OK");
            }
            else
            {
                await DisplayAlert("Required", "Please enter valid car Id", "OK");
            }
        }

        private async void updateBar_Clicked(object sender, EventArgs e)
        {
            string popIdInput = await DisplayPromptAsync("Update Car", "Enter car id", maxLength: 5, placeholder: "Car id");


            if (!string.IsNullOrEmpty(popIdInput))
            {
                var auto = await App.SQLiteDb.GetCarAsync(Convert.ToInt32(popIdInput));

                if (auto != null)
                {
                    string popNameInput = await DisplayPromptAsync("Update Car", "Enter car name", maxLength: 20, placeholder: "Car name");

                    if (!string.IsNullOrEmpty(popNameInput))
                    {
                        AutoModel newAuto = new AutoModel() { Id = Convert.ToInt32(popIdInput), Name = popNameInput };
                        await App.SQLiteDb.SaveCarAsync(newAuto);

                        var tempCarList = await App.SQLiteDb.GetCarsAsync();
                        if (tempCarList != null)
                        {
                            carList.ItemsSource = tempCarList;
                        }
                        popNameInput = string.Empty;
                        popIdInput = string.Empty;
                        await DisplayAlert("Success", "Car updated successfully", "OK");
                    }
                }
            }
            else if (popIdInput == null)
            {
                await DisplayAlert("Canceled", "No car was updated", "OK");
            }
            else
            {
                await DisplayAlert("Required", "Please enter valid car Id", "OK");
            }
        }
    }
}
