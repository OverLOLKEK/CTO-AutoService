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
     class AutoVM : BaseViewModel
    {
        Entities entities;
        public ObservableCollection<Auto> Autos { get; set; }
        public CustomCommand AddAuto { get; set; }
        public CustomCommand SaveAuto { get; set; }

        public CustomCommand RemoveAuto { get; set; }

        private Auto selectedAuto;

        public Auto SelectedAuto
        {
            get => selectedAuto;
            set
            {
                selectedAuto = value;
                SignalChanged();
            }
        }

        public AutoVM()
        {

            var entities = DB.GetDB();
            LoadAutos();
            Autos = new ObservableCollection<Auto>(entities.Autos);
            //Autos = new ObservableCollection<Auto>(entities.Autoes);
            AddAuto = new CustomCommand(() =>
            {
                var auto = new Auto { Model = "Модель", VIN = "VIN номер", Engine = "Двигатель", Body = "Двигатель", Chassis = "Шасси" };
                entities.Autos.Add(auto);
               // Autos.Add(auto);
                SelectedAuto = auto;
            });
            SaveAuto = new CustomCommand(() =>
            {
                try
                {
                    entities.SaveChanges();
                    LoadAutos();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });

            RemoveAuto = new CustomCommand(() =>
            {
                if (SelectedAuto == null)
                {
                    System.Windows.MessageBox.Show("Для удаления авто нужно его выбрать в списке");
                    return;
                }

                DB.GetDB().Autos.Remove(SelectedAuto);
                DB.GetDB().SaveChanges();
                Autos.Remove(SelectedAuto);

            });

        }
        private void LoadAutos()
        {
            var entities = DB.GetDB();
            Autos = new ObservableCollection<Auto>(entities.Autos);
            SignalChanged("Auto");
        }
    }
}