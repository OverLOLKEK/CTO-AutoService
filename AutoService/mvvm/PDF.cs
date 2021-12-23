using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.mvvm
{
    internal class Program
    {
        private static iTextSharp.text.Font helvetica;
        private static BaseFont helveticaBase;
        //private ObservableCollection<Auto> Autos;
       // string ModelAuto;
         //ModelAuto.WriteLine(ToString.Auto.Model;
        static void PDF(string[] args)
        {
            ;

            var document = new iTextSharp.text.Document();
            using (var writer = PdfWriter.GetInstance(document, new FileStream("result.pdf", FileMode.Create)))

            {
                document.Open();

                // изменения внешнего вида докумена 
                writer.DirectContent.MoveTo(35, 780);
                writer.DirectContent.LineTo(430, 780);
                helvetica = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12);
                helveticaBase = helvetica.GetCalculatedBaseFont(false);
                writer.DirectContent.BeginText();
                writer.DirectContent.SetFontAndSize(helveticaBase, 12f);
                writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, "Hello world!", 35, 766, 0);
                //writer.DirectContent.ShowTextAligned(iTextSharp.text.Element.ALIGN_LEFT, Autos);
                writer.DirectContent.EndText();

                document.Close();
                writer.Close();
            }
        }
    }
}
