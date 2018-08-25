using AppPlaces.Model;
using System;
using System.Threading.Tasks;

namespace AppPlaces.ViewModel
{
    public class PlaceViewModel : BaseViewModel
    {
        private Place _place;
        public Place Place
        {
            get
            {
                return _place;
            }
            set
            {
                _place = value; OnPropertyChanged();
            }
        }

        public PlaceViewModel() : base("")
        {
        }

        public override async Task Initialize(object parameters)
        {
            Place = parameters as Place;
            Title = Place.Location;
            await base.Initialize(Place);
        }
    }
}