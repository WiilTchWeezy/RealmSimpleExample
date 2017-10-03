using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealmApp.ViewModels
{
    public class EditPageViewModel : BindableBase, INavigationAware
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        private Realm.Enterprise _selectedEnterprise;
        private INavigationService _navigationService;
        public EditPageViewModel(INavigationService navigationService)
        {
            SaveCommand = new DelegateCommand(Save);
            DeleteCommand = new DelegateCommand(Delete);
            _navigationService = navigationService;
        }

        private void Save()
        {
            var RealmDb = Realms.Realm.GetInstance();
            RealmDb.Write(() => RealmDb.Add(new Realm.Enterprise {Id = _selectedEnterprise.Id, Address = Address, Name = Name }, update: true));
            _navigationService.GoBackAsync();
        }

        private void Delete()
        {
            var RealmDb = Realms.Realm.GetInstance();
            using (var trans = RealmDb.BeginWrite())
            {
                RealmDb.Remove(_selectedEnterprise);
                trans.Commit();
            }
            _navigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("selectedEnterprise"))
            {
                _selectedEnterprise = (Realm.Enterprise)parameters["selectedEnterprise"];
                Name = _selectedEnterprise.Name;
                Address = _selectedEnterprise.Address;
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }
    }
}
