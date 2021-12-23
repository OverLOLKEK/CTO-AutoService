using AutoService.mvvm;
using AutoService.ViewPage.CashBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.ViewModels
{
    class TabsCashboxVM : BaseViewModel
    {
        public CustomCommand ComingCash { get; set; }
        public CustomCommand ConsumptionCash { get; set; }
        public TabsCashboxVM()
        {
        }
    }
}
