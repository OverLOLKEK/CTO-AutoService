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
    
     class DetailVM : BaseViewModel
    {
        Entities entities;
        private Detail selectedDetail;
        CustomCommand AddDetail { get; set; }
        CustomCommand SaveDetail { get; set; }

        public Detail SelectedDetail
        {
            get => selectedDetail;
            set
            {
                selectedDetail = value;
                SignalChanged();
            }
        }
        public DetailVM()
        {
            entities = DB.GetDB();
            LoadDetails();
            AddDetail = new CustomCommand(() =>
            {
                var detail = new Detail {  };
                entities.Details.Add(detail);
                SelectedDetail = detail;
            });
            SaveDetail = new CustomCommand(() =>
            {
                try
                {
                    entities.SaveChanges();
                    LoadDetails();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            });
        }
        public ObservableCollection<Detail> Details { get; set; }
        private void LoadDetails()
        {
            Details = new ObservableCollection<Detail>(entities.Details);
            SignalChanged("Details");
        }

        void SignalChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public event PropertyChangedEventHandler PropertyChanged;
    }
    
}
