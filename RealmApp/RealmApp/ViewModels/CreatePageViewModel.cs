using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealmApp.ViewModels
{
    public class CreatePageViewModel : BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _addres;
        public string Address
        {
            get { return _addres; }
            set { SetProperty(ref _addres, value); }
        }

        public DelegateCommand SaveCommand { get; set; }
        private INavigationService _navigationService;
        public CreatePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SaveCommand = new DelegateCommand(Save);
        }

        private void Save()
        {
            var RealmDb = Realms.Realm.GetInstance();
            var enterpriseId = RealmDb.All<Realm.Enterprise>().Count() + 1;

            var enterprise = new Realm.Enterprise()
            {
                Id = enterpriseId,
                Name = Name,
                Address = Address
            };

            RealmDb.Write(() =>
            {
                enterprise = RealmDb.Add(enterprise);
            });
            _navigationService.GoBackAsync();
        }
    }
}
