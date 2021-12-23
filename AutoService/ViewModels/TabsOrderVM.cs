using AutoService.DBInstance;
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
    class TabsOrderVM : BaseViewModel
    {
        Entities entities;
        private Application selectedApplication;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Application> Applications { get; set; }
        public ObservableCollection<Auto> Autos { get; set; }
        public ObservableCollection<Check> Checks { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Detail> Details { get; set; }
        public ObservableCollection<Work> Works { get; set; }
        public ObservableCollection<Worker> Workers { get; set; }
        public CustomCommand Order { get; set; }
       // public CustomCommand Auto { get; set; }
        public CustomCommand Products { get; set; }
        public CustomCommand Service { get; set; }
        public CustomCommand Payment { get; set; }
        public CustomCommand AddApplication { get; set; }
        public CustomCommand SaveApplication { get; set; }
        

        public Application SelectedApplication
        {
            get => selectedApplication;
            set
            {
                selectedApplication = value;
                SignalChanged();
            }
        }

        public TabsOrderVM()
        {
            entities = DB.GetDB();
            LoadApplications();
            Clients = new ObservableCollection<Client>(entities.Clients);
            Autos = new ObservableCollection<Auto>(entities.Autos);
            Works = new ObservableCollection<Work>(entities.Works);
            Workers = new ObservableCollection<Worker>(entities.Workers);
            Details = new ObservableCollection<Detail>(entities.Details);
            Checks = new ObservableCollection<Check>(entities.Checks);
            AddApplication = new CustomCommand(() => {
                var order = new Application { Status = "Не начат", Note="", Date_Acceptance=DateTime.Today };
                entities.Applications.Add(order);
                SelectedApplication = order;
            });
            SaveApplication = new CustomCommand(() => {
                try
                {
                    entities.SaveChanges();
                    LoadApplications();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });
        }

        private void LoadApplications()
        {
            Applications = new ObservableCollection<Application>(entities.Applications);
            SignalChanged("Groups");
        }
        
        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
