using AutoService.DBInstance;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.mvvm
{
    internal class PDF: INotifyPropertyChanged
    {
        Entities entities;
        private Client selectedClient;        
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Client> Clients { get; set; }
        private static iTextSharp.text.Font helvetica;
        private static BaseFont helveticaBase;       
      public  CustomCommand CreatePDF { get; set; }        
        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                SignalChanged();
            }
        }

        public PDF()
        {
            entities = DB.GetDB();
            LoadClients();
            Clients = new ObservableCollection<Client>(entities.Clients);


            CreatePDF = new CustomCommand(() =>
            {
                entities = DB.GetDB();
                LoadClients();
                Clients = new ObservableCollection<Client>(entities.Clients);
               
            

                var document = new iTextSharp.text.Document();
                using (var writer = PdfWriter.GetInstance(document, new FileStream("result.pdf", FileMode.Create)))

                {
                    document.Open();

                    var client = new Client()
                    {
                        Firstname = "LOL"
                    };

                    // изменения внешнего вида докумена 
                    writer.DirectContent.MoveTo(35, 780);
                    writer.DirectContent.LineTo(430, 780);
                    helvetica = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12);
                    helveticaBase = helvetica.GetCalculatedBaseFont(false);
                    writer.DirectContent.BeginText();
                    writer.DirectContent.SetFontAndSize(helveticaBase, 12f);
                    writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, ($"Client :{client.Firstname}"), 35, 766, 0);
                    //writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, Autos);
                    writer.DirectContent.EndText();

                    document.Close();
                    writer.Close();
                }
            })
            {

            };
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

