using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyShellApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void slidAndPopup()
        {
            subGrid.Opacity = 0;
            subGrid.IsVisible = true;

            var animation = new Animation();

            var menuTranslate = new Animation(v => subGrid.TranslationX = v, 300, 0);
            var menuChangeWidth = new Animation(v => subGrid.WidthRequest = v, 0, 300);
            var menuChangeOpacity = new Animation(v => subGrid.Opacity = v, 0, 1);

            animation.Add(0, 1, menuTranslate);
            animation.Add(0, 1, menuChangeWidth);
            animation.Add(0, 0.2, menuChangeOpacity);
            animation.Commit(this, "Slide", 2, 350, Easing.Linear);
        }

        private void Ctgrylist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            slidAndPopup();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            subGrid.IsVisible = false;
        }

        private void SubCtgrylist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
            subGrid.IsVisible = false;
        }
    }
}