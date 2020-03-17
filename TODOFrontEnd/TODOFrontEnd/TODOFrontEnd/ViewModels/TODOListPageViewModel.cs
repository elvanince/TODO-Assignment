using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TODOFrontEnd.ViewModels
{

    public class TODOListPageViewModel : ViewModelBase
    {

        public DelegateCommand NavigateToDetail { get; set; } //It will hold the nivgation 
        private INavigationService _navigationService; //To get the navigationservice
       
        public TODOListPageViewModel(INavigationService navigationService)
       : base(navigationService)
        {
            Title = "Main Page";

            _navigationService = navigationService;
            NavigateToDetail = new DelegateCommand(NavigateToDetailPage);
        }

        public void NavigateToDetailPage()
        {
            _navigationService.NavigateAsync("TODOItemPage");
        }

       
    }
}
