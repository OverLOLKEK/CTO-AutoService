﻿using AutoService.DBInstance;
using AutoService.mvvm;
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
     class ClientVM : BaseViewModel, INotifyPropertyChanged
    {
        Entities entities;
        private Client selectedApplication;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Auto> Autos { get; set; }
        public CustomCommand RemoveClients { get; set; }
        public CustomCommand AddClients { get; set; }
        public CustomCommand SaveClients { get; set; }


        public Client SelectedApplication
        {
            get => selectedApplication;
            set
            {
                selectedApplication = value;
                SignalChanged();
            }
        }

        public ClientVM()
        {
            entities = DB.GetDB();
            LoadClients();
            Clients = new ObservableCollection<Client>(entities.Clients);
            Autos = new ObservableCollection<Auto>(entities.Autos);
            AddClients = new CustomCommand(() =>
            {
                var client = new Client { Firstname = "Иван", Lastname = "Иванов"};
                entities.Clients.Add(client);
                SelectedApplication = client;
            });
            SaveClients = new CustomCommand(() =>
            {
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

            RemoveClients = new CustomCommand(() =>
            {
                if (SelectedApplication == null)
                {
                    System.Windows.MessageBox.Show("Для удаления клиента нужно его выбрать в списке");
                    return;
                }

                DB.GetDB().Clients.Remove(SelectedApplication);
                DB.GetDB().SaveChanges();
                Clients.Remove(SelectedApplication);

            });
        }

        private void LoadClients()
        {
            Clients = new ObservableCollection<Client>(entities.Clients);
            SignalChanged("Clients");
        }

        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}