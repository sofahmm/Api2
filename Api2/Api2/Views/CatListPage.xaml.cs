using Api2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Api2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatListPage : ContentPage
    {
        public CatListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CatLV.ItemsSource = await App.CatManager.GetCatItemModels();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateOrEditCatPage(true)
            {
                BindingContext = new CatItemModel()
                {
                    Id = Guid.NewGuid().ToString(),
                }
            });
        }

        private void CatLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new CreateOrEditCatPage()
            {
                BindingContext = e.SelectedItem as CatItemModel
            });
        }
    }
}