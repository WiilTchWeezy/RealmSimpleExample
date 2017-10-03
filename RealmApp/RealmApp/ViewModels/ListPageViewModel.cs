using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Realms;

namespace RealmApp.ViewModels
{
    public class ListPageViewModel : BindableBase, INavigationAware
    {
        private Realm.Enterprise _selectedEnterprise;
        public Realm.Enterprise SelectedEnterprise
        {
            get { return _selectedEnterprise; }
            set
            {
                if (SetProperty(ref _selectedEnterprise, value))
                {
                    if (value != null)
                    {
                        var navParams = new NavigationParameters();
                        navParams.Add("selectedEnterprise", value);
                        _navigationService.NavigateAsync("EditPage", navParams);
                    }
                }
            }
        }

        public ObservableCollection<Realm.Enterprise> Enterprises { get; set; }
        private INavigationService _navigationService;
        public ListPageViewModel(INavigationService navigationService)
        {
            Enterprises = new ObservableCollection<Realm.Enterprise>();
            _navigationService = navigationService;
        }

        private async Task LoadDataAsync()
        {
            var RealmDb = Realms.Realm.GetInstance();
            var listaFuncionarios = RealmDb.All<Realm.Enterprise>();
            Enterprises.Clear();
            foreach (var item in listaFuncionarios)
            {
                Enterprises.Add(item);
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            LoadDataAsync();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}
