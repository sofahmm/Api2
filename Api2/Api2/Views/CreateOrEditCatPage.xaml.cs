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
    public partial class CreateOrEditCatPage : ContentPage
    {
        bool IsNewItem;
        public CreateOrEditCatPage(bool isNew = false)
        {
            InitializeComponent();
            IsNewItem = isNew;
        }

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            var catItem = (CatItemModel)BindingContext;
            await App.CatManager.SaveitemAsync(catItem, IsNewItem);
            await Navigation.PopAsync();
        }

        private async void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            var catItem = (CatItemModel)BindingContext;
            await App.CatManager.DeleteCatAsync(catItem);
            await Navigation.PopAsync();
        }
    }
}