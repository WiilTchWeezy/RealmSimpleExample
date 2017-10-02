using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealmApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand CreateCommand { get; set; }
        public DelegateCommand ListCommand { get; set; }
        private INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {
            Title = "Realm App";
            _navigationService = navigationService;
            CreateCommand = new DelegateCommand(Create);
            ListCommand = new DelegateCommand(List);
        }

        private void Create()
        {
            _navigationService.NavigateAsync("CreatePage");
        }

        private void List()
        {
            _navigationService.NavigateAsync("ListPage");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }
    }
}
