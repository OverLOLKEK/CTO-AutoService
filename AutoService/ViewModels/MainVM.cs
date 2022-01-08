using AutoService.DBInstance;
using AutoService.mvvm;
using AutoService.ViewPage;
using AutoService.ViewPage.CashBox;
using AutoService.ViewPage.Directory;
using AutoService.ViewPage.Order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.ViewModels
{
    class MainVM : BaseViewModel
    {
        public CustomCommand GoInCachBox { get; set; }
        public CustomCommand GoOutCachBox { get; set; }
        public CustomCommand GoEditClient { get; set; }

        public CustomCommand GoInStorage { get; set; }
        public CustomCommand GoOutStorage { get; set; }

        public CustomCommand GoOrderInProg { get; set; }
        public CustomCommand GoOrderCompl { get; set; }
        public CustomCommand GoClient { get; set; }
        public CustomCommand GoAuto { get; set; }
        public CustomCommand GoWorks { get; set; }
        public CustomCommand GoProducts { get; set; }
        public CustomCommand AddClients { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        Entities entities;
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
        public MainVM()
        {
            AddClients = new CustomCommand(() =>
            {
                var client = new Client { Firstname = "Иван", Lastname = "Иванов" };
                entities.Clients.Add(client);
                SelectedClient = client;
                GoEditClient = new CustomCommand(() => { new EditClientsDir().Show(); });
            });
            GoAuto = new CustomCommand(() => { new ViewPage.Directory.Auto(); });

            GoInCachBox = new CustomCommand(() =>
            {
                MainWindow.MainNavigate(new ComingCashbox());
            });
            GoOutCachBox = new CustomCommand(() =>
            {
                MainWindow.MainNavigate(new СonsumptCashbox());
            });

            GoInStorage = new CustomCommand(() =>
            {
                MainWindow.MainNavigate(new ComingStorage());
            });
            GoOutStorage = new CustomCommand(() =>
            {
                MainWindow.MainNavigate(new СonsumptStorage());
            });

            GoOrderInProg = new CustomCommand(() =>
            {
                MainWindow.MainNavigate(new OrderInProgress());
            });
            GoOrderCompl = new CustomCommand(() =>
            {
                MainWindow.MainNavigate(new OrderCompleted());
            });
            GoClient = new CustomCommand(() =>
            {
                MainWindow.MainNavigate(new Clients());
            });
           
            GoWorks = new CustomCommand(() =>
            {
                MainWindow.MainNavigate(new Works());
            });
            GoProducts = new CustomCommand(() =>
            {
                MainWindow.MainNavigate(new Products());
            });
        }
    }
}
