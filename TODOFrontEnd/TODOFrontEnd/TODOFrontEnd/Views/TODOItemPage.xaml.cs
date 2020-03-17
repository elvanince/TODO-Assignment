using System;
using TODOFrontEnd.Models;
using Xamarin.Forms;

namespace TODOFrontEnd.Views
{
    public partial class TODOItemPage : ContentPage
    {
        public TODOItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TODOItem)BindingContext;
            await App.TodoManager.SaveTaskAsync(todoItem, string.IsNullOrEmpty(todoItem.ID));
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TODOItem)BindingContext;
            await App.TodoManager.DeleteTaskAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
