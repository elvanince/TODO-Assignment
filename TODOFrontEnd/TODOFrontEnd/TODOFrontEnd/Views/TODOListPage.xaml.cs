using System.Net.Http;
using TODOFrontEnd.Models;
using Xamarin.Forms;

namespace TODOFrontEnd.Views
{
    public partial class TODOListPage : ContentPage
    {
        public TODOListPage()
        {
            InitializeComponent();
        }

        
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TODOItemPage
                {
                    BindingContext = e.SelectedItem as TODOItem
                });
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.TodoManager.GetTasksAsync();
        }
    }
}
