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
    public partial class Event : ContentPage
    {
        public List<EventPage> jsonContents { get; set; }
        public Event(int id)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Event)).Assembly;
            var stream = assembly.GetManifestResourceStream("HermitageGuide.event.json");

            using (StreamReader sr = new StreamReader(stream, Encoding.ASCII))
            {
                var content = sr.ReadToEnd();
                var data = JsonConvert.DeserializeObject<RootProjects>(content);
                jsonContents = data.EventPages;
            }

            EventPage page = jsonContents.Find(a => a.Id == id);

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
                Text = page.EventPageName,
                FontSize = 30,
                TextColor = Color.Black,
                Margin = new Thickness(20, 20, 20, 5),
                FontAttributes = FontAttributes.Bold
            }, 0, 0);

            grid.Children.Add(new Label
            {
                Text = page.EventPageIntro,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(20, 10)
            }, 0, 1);

            grid.Children.Add(new Frame
            {
                Content = new Image
                {
                    Source = page.EventPagePict,
                    Aspect = Aspect.AspectFill
                },
                HasShadow = false,
                Margin = new Thickness(10, 5),
                Padding = new Thickness(0),
                CornerRadius = 5
            }, 0, 2);

            grid.Children.Add(new Label
            {
                Text = page.EventPageCaption,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = Color.FromHex("#053D39"),
                Margin = new Thickness(15, 5)
            }, 0, 3);

            grid.Children.Add(new Label
            {
                Text = page.EventPageText,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.Black,
                Margin = new Thickness(15, 5)
            }, 0, 4);

            eventgrid.Children.Add(grid);
        }
    }
}