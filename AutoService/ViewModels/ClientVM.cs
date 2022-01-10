using AutoService.DBInstance;
using AutoService.mvvm;
using AutoService.ViewPage.Directory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.ViewModels
{
    internal class ClientVM : INotifyPropertyChanged
    {
        Entities entities;
        private Client selectedClient;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Auto> Autos { get; set; }
        public CustomCommand RemoveClients { get; set; }
        public CustomCommand AddClients { get; set; }
        public CustomCommand SaveClients { get; set; }
        public CustomCommand GOClient { get; set; }


        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                SignalChanged();
            }
        }

        public ClientVM()
        {
            //GOClient = new CustomCommand(() => { new EditClientsDir().Show(); });
            entities = DB.GetDB();
            LoadClients();
            LoadAutos();
            Clients = new ObservableCollection<Client>(entities.Clients);
           Autos = new ObservableCollection<Auto>(entities.Autos);
            AddClients = new CustomCommand(() =>
            {
               // new EditClientsDir().Show();
                var client = new Client { Firstname = "Иван", Lastname = "Иванов"};
                entities.Clients.Add(client);
                SelectedClient = client;
            });
            SaveClients = new CustomCommand(() =>
            {
                try
                {
                    LoadAutos();
                    entities.SaveChanges();
                    LoadClients();
                    //GOClient = new CustomCommand(() => { new ClientList(); });
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });

            RemoveClients = new CustomCommand(() =>
            {
                if (SelectedClient == null)
                {
                    System.Windows.MessageBox.Show("Для удаления клиента нужно его выбрать в списке");
                    return;
                }

                DB.GetDB().Clients.Remove(SelectedClient);
                DB.GetDB().SaveChanges();
                Clients.Remove(SelectedClient);

            });
        }

        private void LoadClients()
        {
            Clients = new ObservableCollection<Client>(entities.Clients);
            SignalChanged("Clients");
        }
        private void LoadAutos()
        {
            var entities = DB.GetDB();
            Autos = new ObservableCollection<Auto>(entities.Autos);
            SignalChanged("Auto");
        }

        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}