using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using ConstructionStoreApp.Services;
using ConstructionStoreApp.Views;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using ConstructionStoreApp.Services.Mocks;

namespace ConstructionStoreApp.ViewModels
{
    public class CatalogViewModel : INotifyPropertyChanged
    {
        private readonly IProductService _productService;
        private string _searchText;
        private int _selectedSortingIndex = -1;
        private bool _isRefreshing;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Product> Products { get; } = new ObservableCollection<Product>();
        public ObservableCollection<Product> AllProducts { get; } = new ObservableCollection<Product>();

        public ICommand LoadProductsCommand { get; }
        public ICommand ShowDetailsCommand { get; }
        public ICommand RefreshCommand { get; }

        public CatalogViewModel()
        {
            _productService = new MockProductService(); // виклик імітаційного сервісу

            LoadProductsCommand = new Command(async () => await LoadProducts());
            ShowDetailsCommand = new Command<Product>(ShowProductDetails);
            RefreshCommand = new Command(async () => await RefreshData());
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterAndSortProducts();
            }
        }

        public int SelectedSortingIndex
        {
            get => _selectedSortingIndex;
            set
            {
                _selectedSortingIndex = value;
                OnPropertyChanged();
                FilterAndSortProducts();
            }
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        private async Task LoadProducts()
        {
            try
            {
                var products = await _productService.GetFurnitureHardwareProducts();
                AllProducts.Clear();
                foreach (var product in products)
                {
                    AllProducts.Add(product);
                }
                FilterAndSortProducts();
            }
            catch (Exception ex)
            {
                // Обробка помилок
                await Application.Current.MainPage.DisplayAlert("Помилка", ex.Message, "OK");
            }
        }

        private void FilterAndSortProducts()
        {
            var filtered = AllProducts.Where(p =>
                string.IsNullOrWhiteSpace(SearchText) ||
                p.Name.ToLower().Contains(SearchText.ToLower()) ||
                p.Description.ToLower().Contains(SearchText.ToLower()));

            switch (SelectedSortingIndex)
            {
                case 0:
                    filtered = filtered.OrderBy(p => p.Price);
                    break;
                case 1:
                    filtered = filtered.OrderByDescending(p => p.Price);
                    break;
                case 2:
                    filtered = filtered.OrderBy(p => p.Name);
                    break;
            }

            Products.Clear();
            foreach (var product in filtered)
            {
                Products.Add(product);
            }
        }

        private async Task RefreshData()
        {
            IsRefreshing = true;
            await LoadProducts();
            IsRefreshing = false;
        }

        private void ShowProductDetails(Product product)
        {
            // Логіка переходу на сторінку деталей товару
            Application.Current.MainPage.Navigation.PushAsync(
                new ProductDetailPage(new ProductDetailViewModel(product)));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Product : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }

        public string Availability => StockQuantity > 0 ? "В наявності" : "Немає в наявності";
        public Color AvailabilityColor => StockQuantity > 0 ? Color.Green : Color.Red;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}