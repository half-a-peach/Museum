using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using HermitageGuide.Model;
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

        public List<EventPage> EventPages { get; set; }

        public List<ExcursionPage> ExcursionPages { get; set; }

        public List<ItemInfo> ItemInfos { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            App.Database.CreateTable();
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
