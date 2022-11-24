using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;

namespace HermitageGuide
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Events : ContentPage
    {
        public List<EventCard> jsonContents { get; set; }

        public Events()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Events)).Assembly;
            var stream = assembly.GetManifestResourceStream("HermitageGuide.events.json");

            using (StreamReader sr = new StreamReader(stream, Encoding.ASCII))
            {
                var content = sr.ReadToEnd();
                var data = JsonConvert.DeserializeObject<RootProjects>(content);
                jsonContents = data.EventCards;
            }

            int y = 0;

            foreach (EventCard card in jsonContents)
            {
                Grid BigGrid = new Grid 
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                    }
                };

                Grid grid = new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition { Height = new GridLength(3, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                    }
                };

                BigGrid.Children.Add(grid, 0, 0);

                BigGrid.Children.Add(
                    new Frame
                    {
                        Content = new Image
                        {
                            Source = card.EventCardPict,
                            Aspect = Aspect.AspectFill
                        },
                        Padding = new Thickness(0),
                        CornerRadius = 8,
                        Margin = new Thickness(16, 0, 0, 0)
                    }, 1, 0
                    );

                grid.Children.Add(new Label
                {
                    Text = card.EventCardTitle,
                    FontSize = 15,
                    TextColor = Color.FromHex("#263238"),
                }, 0, 0);

                grid.Children.Add(new Label
                {
                    Text = card.EventCardDate.ToShortDateString(),
                    FontSize = 12,
                    TextColor = Color.FromHex("#8A263238")
                }, 0, 1);

                Frame frame = new Frame
                {
                    Content = BigGrid,
                    Padding = new Thickness(16),
                    CornerRadius = 4,
                    HeightRequest = 118,
                    WidthRequest = 330,
                    Margin = new Thickness(14),
                    BackgroundColor = Color.FromHex("#DBEAEC")
                };

                TapGestureRecognizer tap = new TapGestureRecognizer
                {
                    NumberOfTapsRequired = 1
                };

                tap.Tapped += (s, e) => {
                    EventPageOpen(s, e, card.Id);
                };

                frame.GestureRecognizers.Add(tap);

                evgrid.Children.Add( frame, 0, y);

                y++;
            }
        }

        private async void EventPageOpen(object sender, System.EventArgs e, int id)
        {
            await Navigation.PushAsync(new Event(id));
        }
    }
}