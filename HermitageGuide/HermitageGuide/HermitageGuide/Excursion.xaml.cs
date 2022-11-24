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
    public partial class Excursion : ContentPage
    {
        public List<ExcursionPage> jsonContents { get; set; }

        public Excursion(int id)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Excursion)).Assembly;
            var stream = assembly.GetManifestResourceStream("HermitageGuide.excursion.json");

            using (StreamReader sr = new StreamReader(stream, Encoding.ASCII))
            {
                var content = sr.ReadToEnd();
                var data = JsonConvert.DeserializeObject<RootProjects>(content);
                jsonContents = data.ExcursionPages;
            }

            ExcursionPage page = jsonContents.Find(a => a.Id == id);

            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }
                }
            };

            grid.Children.Add(new Label
            {
                Text = page.ExcursionPageName,
                FontSize = 30,
                TextColor = Color.Black,
                Margin = new Thickness(20, 20, 20, 7),
                FontAttributes = FontAttributes.Bold
            }, 0, 0);

            Grid InfoGrid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }
                },

                ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) }
            }
            };

            grid.Children.Add(InfoGrid, 0, 1);

            InfoGrid.Children.Add(new Image
            {
                Source = "calendar.png",
                Aspect = Aspect.AspectFit,
                Margin = new Thickness(18, -10, 18, 0)
            }, 0, 0);

            InfoGrid.Children.Add(new Image
            {
                Source = "place.png",
                Aspect = Aspect.AspectFit,
                Margin = new Thickness(18, -10, 18, 0)
            }, 0, 1);

            InfoGrid.Children.Add(new Image
            {
                Source = "time.png",
                Aspect = Aspect.AspectFit,
                Margin = new Thickness(18, -10, 18, 0)
            }, 0, 2);

            InfoGrid.Children.Add(new Label
            {
                Text = page.ExcursionSchedule,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(0, 20, 20, 0)
            }, 1, 0);

            InfoGrid.Children.Add(new Label
            {
                Text = page.ExcursionPlace,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(0, 20, 20, 0)
            }, 1, 1);

            InfoGrid.Children.Add(new Label
            {
                Text = page.ExcursionDuration,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(0, 20, 20, 0)
            }, 1, 2);

            grid.Children.Add(new Frame
            {
                Content = new Image
                {
                    Source = page.ExcursionPagePict,
                    Aspect = Aspect.AspectFill
                },
                HasShadow = false,
                Margin = new Thickness(10, 5),
                Padding = new Thickness(0),
                CornerRadius = 5
            }, 0, 2);

            grid.Children.Add(new Label
            {
                Text = page.ExcursionPageCaption,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = Color.FromHex("#053D39"),
                Margin = new Thickness(15, 5)
            }, 0, 3);

            grid.Children.Add(new Label
            {
                Text = page.ExcursionsPageText,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.Black,
                Margin = new Thickness(15, 5)
            }, 0, 4);

            excgrid.Children.Add(grid);
        }
    }
}