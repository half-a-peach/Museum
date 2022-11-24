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
    public partial class Exhibition : ContentPage
    {
        public List<ExhibitionPage> jsonContents { get; set; }
        public List<ItemCard> ItemCards { get; set; }

        public Exhibition(int id)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Exhibition)).Assembly;
            var stream = assembly.GetManifestResourceStream("HermitageGuide.exhibition.json");

            using (StreamReader sr = new StreamReader(stream, Encoding.ASCII))
            {
                var content = sr.ReadToEnd();
                var data = JsonConvert.DeserializeObject<RootProjects>(content);
                jsonContents = data.ExhibitionPages;
            }

            ExhibitionPage page = jsonContents.Find(a => a.Id == id);
            ItemCards = page.ItemCardList;

            Grid BigGrid = new Grid 
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                }
            };

            Grid ImGrid = new Grid { };

            ImGrid.Children.Add(
                    new Image
                    {
                        Source = page.ExhibitPagePict,
                        Aspect = Aspect.AspectFill
                    });

            Image mainimage = new Image { };
            mainimage.BackgroundColor = Color.FromHex("#34000000");

            ImGrid.Children.Add(mainimage);

            ImGrid.Children.Add(new Label
            {
                Text = page.ExhibitPageName,
                FontSize = 24,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.End,
                Margin = new Thickness(30, 10)
            });

            BigGrid.Children.Add(
                    new Frame
                    {
                        Content = ImGrid,
                        HeightRequest = 170,
                        HasShadow = false,
                        Margin = new Thickness(10, 12),
                        Padding = new Thickness(0),
                        CornerRadius = 5
                    }, 0, 0
                    );

            SearchBar searchBar = new SearchBar
            {
                Placeholder = "Поиск",
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                BackgroundColor = Color.FromHex("#ECF4F5")
            };

            Grid ListGrid = new Grid { };

            searchBar.SearchButtonPressed += (s, e) => {
                ItemSearch(s, e, ListGrid);
            };

            BigGrid.Children.Add(
                    new Frame
                    {
                        Content = searchBar,
                        HasShadow = false,
                        Margin = new Thickness(14, 12),
                        Padding = new Thickness(0),
                        CornerRadius = 10
                    }, 0, 1
                    );

            BigGrid.Children.Add(ListGrid, 0, 2 );

            int x = 0, y = 0, row = 0;
            bool help = false, col = false;

            foreach (ItemCard card in ItemCards)
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
                        Source = card.ItemCardPict,
                        Aspect = Aspect.AspectFill
                    }
                    );

                TapGestureRecognizer tap = new TapGestureRecognizer
                {
                    NumberOfTapsRequired = 1
                };

                tap.Tapped += (s, e) => {
                    ItemPageOpen(s, e, card.Id);
                };

                Image image = new Image { };
                image.BackgroundColor = Color.FromHex("#34000000");
                image.GestureRecognizers.Add(tap);

                grid.Children.Add(image);

                grid.Children.Add(new Label
                {
                    Text = card.ItemCardName,
                    FontSize = 12,
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.End,
                    Margin = new Thickness(10)
                });

                ListGrid.Children.Add(
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

            exhigrid.Children.Add(BigGrid);
        }

        private async void ItemPageOpen(object sender, System.EventArgs e, int id)
        {
            await Navigation.PushAsync(new Item(id));
        }

        public void ItemSearch(object sender, EventArgs e, Grid ListGrid)
        {
            SearchBar searchBar = (SearchBar)sender;

            List<ItemCard> searchResults = new List<ItemCard>();

            foreach(ItemCard itemCard in ItemCards)
            {
                if(itemCard.ItemCardName.ToLower().Contains(searchBar.Text.ToLower()))
                {
                    searchResults.Add(itemCard);
                }
            }

            ListGrid.Children.Clear();

            int x = 0, y = 0, row = 0;
            bool help = false, col = false;

            foreach (ItemCard card in searchResults)
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
                        Source = card.ItemCardPict,
                        Aspect = Aspect.AspectFill
                    }
                    );

                TapGestureRecognizer tap = new TapGestureRecognizer
                {
                    NumberOfTapsRequired = 1
                };

                tap.Tapped += (s, e1) => {
                    ItemPageOpen(s, e1, card.Id);
                };

                Image image = new Image { };
                image.BackgroundColor = Color.FromHex("#34000000");
                image.GestureRecognizers.Add(tap);

                grid.Children.Add(image);

                grid.Children.Add(new Label
                {
                    Text = card.ItemCardName,
                    FontSize = 12,
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.End,
                    Margin = new Thickness(10)
                });

                ListGrid.Children.Add(
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

            if(ListGrid.Children.Count == 0)
            {
                ListGrid.Children.Add(new Label
                {
                    Text = "По вашему запросу ничего не найдено",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    TextColor = Color.LightGray,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Margin = new Thickness(15, 15, 15, 15)
                });
            }

        }
    }
}