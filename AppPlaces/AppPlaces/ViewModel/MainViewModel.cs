using AppPlaces.Model;
using AppPlaces.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppPlaces.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Place> Places { get; set; } = new ObservableCollection<Place>();

        public MainViewModel() : base("AppPlaces")
        {
            RefreshCommand = new Command(async () => await LoadData(), () => !IsBusy);
            ItemClickCommand = new Command<Place>(async (place) => await ItemClickCommandExecuteAsync(place));
        }

        public override async Task Initialize(object parameters = null) => await LoadData();

        async Task ItemClickCommandExecuteAsync(Place place)
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;
                var placePage = new PlacePage();
                await placePage.ViewModel.Initialize(place);

                await Navigation.PushAsync(placePage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await ShowAlertAsync("Error!", error.Message, "OK");
        }

        async Task LoadData()
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;

                var places = await Api.GetAllPlacesAsync();

                Places.Clear();
                foreach (var place in places)
                    Places.Add(place);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await ShowAlertAsync("Error!", error.Message, "OK");
        }

    }
}
