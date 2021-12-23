using AutoService.DBInstance;
using AutoService.mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.ViewModels
{
    internal class ClientVM : BaseViewModel
    {
        private ObservableCollection<Client> client;

        public ObservableCollection<Client> Client { get => client; set { client = value; SignalChanged(); } }
        public ObservableCollection<Auto> Autos { get; set; }
        public CustomCommand AddClient { get; set; }

        public Auto SelectedAuto { get; set; }

        public List<Auto> Autoes { get; set; }
        public CustomCommand RemoveClient { get; set; }
        public CustomCommand SaveClient { get; set; }

        private Client selectedClient;

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

            var entities = DB.GetDB();
            LoadClients();
            Client = new ObservableCollection<Client>(entities.Clients);
            Autoes = entities.Autos.ToList();
            AddClient = new CustomCommand(() =>
            {


                var client = new Client { Firstname = "Имя", Lastname = "Фамилия", Patronymic = "Отчество"/*, Auto = SelectedAuto, id_Auto = SelectedAuto.id */};
                entities.Clients.Add(client);
                Client.Add(client);
                SelectedClient = client;
            });
            SaveClient = new CustomCommand(() =>
            {
                //if (SelectedAuto == null)
                //{
                //    MessageBox.Show("Не выбрано авто");
                //    return;
                //}

                try
                {
                    entities.SaveChanges();
                    LoadClients();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });


            RemoveClient = new CustomCommand(() =>
            {
                if (SelectedClient == null)
                {
                    System.Windows.MessageBox.Show("Для удаления клиента нужно его выбрать в списке");
                    return;
                }

                DB.GetDB().Clients.Remove(SelectedClient);
                DB.GetDB().SaveChanges();
                Client.Remove(SelectedClient);

            });

        }
        private void LoadClients()
        {
            var entities = DB.GetDB();
            Client = new ObservableCollection<Client>(entities.Clients);
            SignalChanged("Client");
        }
    }
}
