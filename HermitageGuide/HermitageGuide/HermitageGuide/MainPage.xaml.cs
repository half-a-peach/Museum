using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Reflection;

namespace HermitageGuide
{
    public class RootProjects
    {
        public List<ExhibitionCard> ExhibitionCards { get; set; }

        public List<ExcursionCard> ExcursionCards { get; set; }

        public List<EventCard> EventCards { get; set; }

        public List<ExhibitionPage> ExhibitionPages { get; set; }

        public List<ItemCard> ItemCards { get; set; }

        public List<EventPage> EventPages { get; set; }

        public List<ExcursionPage> ExcursionPages { get; set; }

        public List<ItemPage> ItemPages { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //вылезает ошибка System.IO.FileNotFoundException: 'Could not find file "/data.json"
            //var jsonFile = "HermitageGuide.data.json";
            //var jsonString = System.IO.File.ReadAllText(jsonFile);
            //var data = JsonConvert.DeserializeObject<List<object>>(jsonString);

            //Label l = (Label)FindByName("label1");
            //l.Text += data;

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
