using AppPlaces.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPlaces.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlacePage : ContentPage
    {
        private PlaceViewModel _vm;
        public PlaceViewModel ViewModel
        {
            get
            {
                if (_vm == null)
                    _vm = new PlaceViewModel();

                BindingContext = _vm;

                return (BindingContext as PlaceViewModel);
            }
        }

        public PlacePage()
        {
            InitializeComponent();
        }
    }
}