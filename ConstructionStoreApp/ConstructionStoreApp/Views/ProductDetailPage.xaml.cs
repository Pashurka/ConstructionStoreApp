using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ConstructionStoreApp.ViewModels;

namespace ConstructionStoreApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        public ProductDetailPage()
        {
            InitializeComponent();
        }
        public ProductDetailPage(ProductDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}