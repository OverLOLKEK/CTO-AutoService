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
    class СonsumptCashboxVM : BaseViewModel, INotifyPropertyChanged
    {
        Entities entities;
        private Check selectedCheck;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Check> Checks { get; set; }
        public ObservableCollection<Check> СonsumptChecks { get; set; }

        public Check SelectedCheck
        {
            get => selectedCheck;
            set { selectedCheck = value; SignalChanged(); }
        }
        public CustomCommand AddCheck { get; set; }

        public СonsumptCashboxVM()
        {
            entities = DB.GetDB();
            LoadChecks();
        }
        private void LoadChecks()
        {
            Checks = SortChecks(); /*new ObservableCollection<Check>(entities.Check)*///Clients вот та шляпа создана в Model.Context.cs
            SignalChanged("Checks");
        }
        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private ObservableCollection<Check> SortChecks()
        {
            for (int i = 0; i < Checks.Count; i++)
            {
                if (Checks[i].id/*здесь поле которое проверяем*/ !=  0/*здесь то что должно содержать поле*/) /*та проверка которая тут есть сделана чтобы избежать ошибок и не является рабочей*/
                {
                    СonsumptChecks.Add(Checks[i]);
                }
            }
            return СonsumptChecks;
        }
    }
}
