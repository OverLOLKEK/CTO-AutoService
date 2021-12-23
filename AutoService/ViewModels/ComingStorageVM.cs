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
    class ComingStorageVM : BaseViewModel, INotifyPropertyChanged
    {
        Entities entities;
        private Warehouse selectedWarehouse;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Warehouse> Warehouses { get; set; }
        public ObservableCollection<Warehouse> ComingWarehouses { get; set; }

        public Warehouse SelectedWarehouse
        {
            get => selectedWarehouse;
            set { selectedWarehouse = value; SignalChanged(); }
        }
        public CustomCommand AddWarehouse { get; set; }
        //public CustomCommand SaveCheck { get; set; }
        public ComingStorageVM()
        {

            entities = DB.GetDB();
            LoadClients();
            //AddCheck = new CustomCommand(() =>
            //{
            //    SelectedCheck = new Check { Date = DateTime.Now };
            //    entities.Check.Add(SelectedCheck);
            //    LoadClients();
            //});
            //SaveCheck = new CustomCommand(() =>
            //{
            //    try
            //    {
            //        entities.SaveChanges();
            //        LoadClients();
            //        MainWindow.MainNavigate(new ComingCashbox());
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Windows.MessageBox.Show(ex.Message);
            //    }
            //});
        }

        private void LoadClients()
        {
            ComingWarehouses = SortWarehouses();/*new ObservableCollection<Check>(entities.Check);*///Clients вот та шляпа создана в Model.Context.cs
            SignalChanged("Warehouses");
        }
        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private ObservableCollection<Warehouse> SortWarehouses()
        {
            for (int i = 0; i < Warehouses.Count; i++)
            {
                if (Warehouses[i].id/*здесь поле которое проверяем*/ != 0/*здесь то что должно содержать поле*/) /*та проверка которая тут есть сделана чтобы избежать ошибок и не является рабочей*/
                {
                    ComingWarehouses.Add(Warehouses[i]);
                }
            }
            return ComingWarehouses;
        }
    }
}
