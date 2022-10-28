using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HermitageGuide
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exhibitions : ContentPage
    {
        public Exhibitions()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private async void ExhibitionPageOpen(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Exhibition());
        }
    }
}