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
    public partial class Item : ContentPage
    {
        public List<ItemPage> jsonContents { get; set; }

        public Item(int id)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Item)).Assembly;
            var stream = assembly.GetManifestResourceStream("HermitageGuide.item.json");

            using (StreamReader sr = new StreamReader(stream, Encoding.ASCII))
            {
                var content = sr.ReadToEnd();
                var data = JsonConvert.DeserializeObject<RootProjects>(content);
                jsonContents = data.ItemPages;
            }

            ItemPage page = jsonContents.Find(a => a.Id == id);

            Grid BigGrid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }
                }
            };

            Grid ImGrid = new Grid
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

            Grid InfoGrid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }
                },

                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) }
                }
            };

            BigGrid.Children.Add(ImGrid, 0, 0);
            BigGrid.Children.Add(InfoGrid, 0, 1);

            ImGrid.Children.Add(new Frame
            {
                Content = new Image
                {
                    Source = page.ItemPict,
                    Aspect = Aspect.AspectFit
                },
                HasShadow = false,
                Margin = new Thickness(10, 5),
                Padding = new Thickness(0),
                CornerRadius = 5
            }, 0, 0);

            ImGrid.Children.Add(new Label
            {
                Text = page.ItemAuthor,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.Black,
                Margin = new Thickness(30, 5)
            }, 0, 1);

            ImGrid.Children.Add(new Label
            {
                Text = page.ItemName,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(20, 5)
            }, 0, 2);

            ImGrid.Children.Add(new Label
            {
                Text = page.CreationPlace + ", " + page.CreationTime,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.Black,
                Margin = new Thickness(30, 5)
            }, 0, 3);

            ImGrid.Children.Add(new BoxView
            {
                Color = Color.LightGray,
                HeightRequest = 2,
                Margin = new Thickness(10)
            }, 0, 4);

            InfoGrid.Children.Add(new Label
            {
                Text = "Автор: ",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(20, 0, 5, 0)
            }, 0, 0);

            InfoGrid.Children.Add(new Label
            {
                Text = "Название: ",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(20, 0, 5, 0)
            }, 0, 1);

            InfoGrid.Children.Add(new Label
            {
                Text = "Место создания: ",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(20, 0, 5, 0)
            }, 0, 2);

            InfoGrid.Children.Add(new Label
            {
                Text = "Время создания: ",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(20, 0, 5, 0)
            }, 0, 3);

            InfoGrid.Children.Add(new Label
            {
                Text = "Материал: ",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(20, 0, 5, 0)
            }, 0, 4);

            InfoGrid.Children.Add(new Label
            {
                Text = "Техника: ",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(20, 0, 5, 0)
            }, 0, 5);

            InfoGrid.Children.Add(new Label
            {
                Text = "Размеры: ",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(20, 0, 5, 0)
            }, 0, 6);

            InfoGrid.Children.Add(new Label
            {
                Text = "Поступление: ",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(20, 0, 5, 0)
            }, 0, 7);

            InfoGrid.Children.Add(new Label
            {
                Text = "Инвентарный номер: ",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(20, 0, 5, 0)
            }, 0, 8);

            InfoGrid.Children.Add(new Label
            {
                Text = "Категория: ",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(20, 0, 5, 0)
            }, 0, 9);

            InfoGrid.Children.Add(new Label
            {
                Text = page.ItemAuthor,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(0, 0, 10, 0)
            }, 1, 0);

            InfoGrid.Children.Add(new Label
            {
                Text = page.ItemName,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(0, 0, 10, 0)
            }, 1, 1);

            InfoGrid.Children.Add(new Label
            {
                Text = page.CreationPlace,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(0, 0, 10, 0)
            }, 1, 2);

            InfoGrid.Children.Add(new Label
            {
                Text = page.CreationTime,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(0, 0, 10, 0)
            }, 1, 3);

            InfoGrid.Children.Add(new Label
            {
                Text = page.ItemMaterial,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(0, 0, 10, 0)
            }, 1, 4);

            InfoGrid.Children.Add(new Label
            {
                Text = page.ItemTechnique,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(0, 0, 10, 0)
            }, 1, 5);

            InfoGrid.Children.Add(new Label
            {
                Text = page.ItemSizes,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(0, 0, 10, 0)
            }, 1, 6);

            InfoGrid.Children.Add(new Label
            {
                Text = page.ItemAcquisition,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(0, 0, 10, 0)
            }, 1, 7);

            InfoGrid.Children.Add(new Label
            {
                Text = page.ItemStockNumber,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(0, 0, 10, 0)
            }, 1, 8);

            InfoGrid.Children.Add(new Label
            {
                Text = page.ItemCategory,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#263238"),
                Margin = new Thickness(0, 0, 10, 0)
            }, 1, 9);

            itemgrid.Children.Add(BigGrid);
        }
    }
}