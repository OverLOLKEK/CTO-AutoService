using AutoService.mvvm;
using AutoService.ViewPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.ViewModels
{
    class TabsStorageVM : BaseViewModel
    {
        public CustomCommand Coming { get; set; }
        public CustomCommand Consumption { get; set; }
        public TabsStorageVM()
        {

        }
    }
}
