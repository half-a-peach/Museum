using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace HermitageGuide
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //по непонятной причине не работает, вылезает ошибка System.IO.FileNotFoundException: 'Could not find file "/data.json"
            //var jsonFile = "data.json";
            //var jsonString = System.IO.File.ReadAllText(jsonFile);
            //var data = JsonConvert.DeserializeObject<List<object>>(jsonString);
        }

        private async void ExhibitionPageOpen(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Exhibitions());
        }

        private async void EventsPageOpen(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Events());
        }

        private async void ExcursionsPageOpen(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Excursions());
        }
    }
}
