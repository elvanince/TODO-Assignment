using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TODOFrontEnd.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public DelegateCommand NavigateToSecond { get; set; } //It will hold the nivgation 
        private INavigationService _navigationService; //To get the navigationservice

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            _navigationService = navigationService;
            NavigateToSecond = new DelegateCommand(NavigateToSecondCall);
        }

        public void NavigateToSecondCall()
        {
            _navigationService.NavigateAsync("TODOListPage");
        }
    }
}
