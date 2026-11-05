using System.Windows.Input;
using Xamarin.Forms;


namespace ConstructionStoreApp.ViewModels
{

    public class ProductDetailViewModel : BaseViewModel
    {
        private Product _product;


        public ProductDetailViewModel()
        {
            // Ініціалізація за замовчуванням (якщо потрібно)
        }

        public Product Product
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        public string AvailabilityStatus =>
            Product.StockQuantity > 0 ? $"В наявності ({Product.StockQuantity} шт.)" : "Немає в наявності";

        public Color AvailabilityColor =>
            Product.StockQuantity > 0 ? Color.Green : Color.Red;

        public ICommand GoBackCommand { get; }
        public ICommand AddToCartCommand { get; }

        public ProductDetailViewModel(Product product)
        {
            Product = product;

            GoBackCommand = new Command(async () =>
                await Application.Current.MainPage.Navigation.PopAsync());

            AddToCartCommand = new Command(AddToCart);
        }

        private void AddToCart()
        {
            // Логіка додавання до кошика
            Application.Current.MainPage.DisplayAlert("Кошик",
                $"{Product.Name} додано до кошика", "OK");
        }
    }
}