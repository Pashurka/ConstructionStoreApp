using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ConstructionStoreApp.ViewModels;
using System;

namespace ConstructionStoreApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        public FilterPage()
        {
            InitializeComponent();
        }

        // Обробник зміни тексту пошуку
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (BindingContext is CatalogViewModel viewModel)
            {
                viewModel.SearchText = e.NewTextValue;
            }
        }

        // Обробник зміни сортування
        private void OnSortingChanged(object sender, EventArgs e)
        {
            if (BindingContext is CatalogViewModel viewModel && sender is Picker picker)
            {
                viewModel.SelectedSortingIndex = picker.SelectedIndex;
            }
        }
    }
}