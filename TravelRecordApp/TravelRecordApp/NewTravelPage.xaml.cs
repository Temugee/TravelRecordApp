using SQLite;
using System;
using System.Threading.Tasks;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Plugin.Geolocator;
using System.Linq;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        public Result selectedVenue;
        public Post newPost;

        public NewTravelPage()
        {
            InitializeComponent();
            venueListView.ItemSelected += VenueListView_ItemSelected;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);
                venueListView.ItemsSource = venues.results;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Failed to load venues: " + ex.Message, "OK");
            }
        }

        private void VenueListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                selectedVenue = e.SelectedItem as Result;
                newPost = new Post()
                {
                    Experience = experienceEntry.Text,
                    VenueName = selectedVenue.name
                };
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Failed to select venue: " + ex.Message, "OK");
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (selectedVenue != null)
                {
                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        conn.CreateTable<Post>();
                        int rows = conn.Insert(newPost);
                        if (rows > 0)
                        {
                            await DisplayAlert("Success", "Experience successfully inserted", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Failure", "Experience insertion failed", "OK");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Please select a venue", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Failed to insert experience: " + ex.Message, "OK");
            }
        }
    }
}
