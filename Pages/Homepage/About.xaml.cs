using Microsoft.Maui.Controls;
using System;

namespace RateReel.Pages.Homepage
{
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
        }

        private async void OnOkClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}