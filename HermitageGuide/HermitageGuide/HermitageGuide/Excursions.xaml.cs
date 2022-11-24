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
    public partial class Excursions : ContentPage
    {
        public List<ExcursionCard> jsonContents { get; set; }

        public Excursions()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Excursions)).Assembly;
            var stream = assembly.GetManifestResourceStream("HermitageGuide.excursions.json");

            using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
            {
                var content = sr.ReadToEnd();
                var data = JsonConvert.DeserializeObject<RootProjects>(content);
                jsonContents = data.ExcursionCards;
            }

            int x = 0, y = 0, row = 0;
            bool help = false, col = false;

            foreach (ExcursionCard card in jsonContents)
            {
                if (!help)
                {
                    x = row;
                    help = true;
                }
                else if (help)
                {
                    x = row;
                    help = false;
                    row++;
                }

                if (!col)
                {
                    y = 0;
                    col = true;
                }
                else if (col)
                {
                    y = 1;
                    col = false;
                }

                Grid grid = new Grid { };

                grid.Children.Add(
                    new Image
                    {
                        Source = card.ExcursCardPict,
                        Aspect = Aspect.AspectFill
                    }
                    );

                TapGestureRecognizer tap = new TapGestureRecognizer
                {
                    NumberOfTapsRequired = 1
                };

                tap.Tapped += (s, e) => {
                    ExcursionPageOpen(s, e, card.Id);
                };

                Image image = new Image { };
                image.BackgroundColor = Color.FromHex("#34000000");
                image.GestureRecognizers.Add(tap);

                grid.Children.Add(image);

                grid.Children.Add(new Label
                {
                    Text = card.ExcursCardName,
                    FontSize = 12,
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.End,
                    Margin = new Thickness(10)
                });

                excgrid.Children.Add(
                    new Frame
                    {
                        Content = grid,
                        HeightRequest = 150,
                        WidthRequest = 150,
                        Margin = new Thickness(15, 14),
                        Padding = new Thickness(0),
                        CornerRadius = 8
                    }, y, x
                    );
            }
        }

        private async void ExcursionPageOpen(object sender, System.EventArgs e, int id)
        {
            await Navigation.PushAsync(new Excursion(id));
        }
    }
}