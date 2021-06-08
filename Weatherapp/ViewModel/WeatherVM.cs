using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Weatherapp.Model;
using Weatherapp.ViewModel.Command;
using Weatherapp.ViewModel.Helper;

namespace Weatherapp.ViewModel
{
  public  class WeatherVM : INotifyPropertyChanged
    {
        private string query;

        public String Query
        {
            get { return query; }
            set {
                query = value;
                OnPropertyChanged("Query");
            }
        }
        private Currentcondition weather;

        public Currentcondition Weather
        {
            get { return weather; }
            set
            {
                weather = value;
                OnPropertyChanged("Weather");
            }
        }
        private Currentcondition weatherIcon;

        public Currentcondition WeatherIcon 
        {
            get { return weatherIcon; }
            set { weatherIcon = value; }
        }


        public ObservableCollection<City> Cities { get; set; }


        private Currentcondition currentContn;

        public Currentcondition CurrentContn
        {
            get { return currentContn; }
            set {
                currentContn = value;
                OnPropertyChanged("CurrentContn");
            }
        }
        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set {
                selectedCity = value;
               // OnPropertyChanged("SelectedCity");
               // GetCurrentCondition();
                if (selectedCity != null)
                {
                    OnPropertyChanged("SelectedCity");
                    GetCurrentCondition();
                }
            }
        }

        public SearchCommand SearchCommand { get; set; }
        //setting static values from constructor
        public WeatherVM(){
           if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) 
            {
                SelectedCity = new City
                {
                    LocalizedName = "New Delhi"
                };
                CurrentContn = new Currentcondition
                {
                    WeatherText = "Cloudly weather",
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = "11"
                        }
                    }
                };
            }
            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
        }
        private async void GetCurrentCondition()
        {
            query = string.Empty;
           // if (Cities.Count != 0)
              
            CurrentContn = await AccuWeatherHelper.GetCurrentCondition(selectedCity.Key);
            Cities.Clear();
        }

        public async void MakeQuery()
        {
           
            var cities = await AccuWeatherHelper.GetCities(Query);
           //if(Cities.Count!=0)
            Cities.Clear();
            foreach(var city in cities)
            {
                Cities.Add(city);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged( string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
