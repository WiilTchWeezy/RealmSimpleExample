using Prism.Commands;
using Prism.Mvvm;
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
        public CreatePageViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
        }

        private void Save()
        {
            var RealmDb = Realms.Realm.GetInstance();
            var FunciId = RealmDb.All<Realm.Enterprise>().Count() + 1;

            var funcionario = new Realm.Enterprise()
            {
                Id = FunciId,
                Name = Name,
                Address = Address
            };

            RealmDb.Write(() =>
            {
                funcionario = RealmDb.Add(funcionario);
            });

        }
    }
}
