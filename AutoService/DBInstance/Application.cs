//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoService.DBInstance
{
    using System;
    using System.Collections.Generic;
    
    public partial class Application
    {
        public int id { get; set; }
        public Nullable<int> id_Client { get; set; }
        public Nullable<System.DateTime> Date_Acceptance { get; set; }
        public Nullable<System.DateTime> Date_Start { get; set; }
        public Nullable<System.DateTime> Date_End { get; set; }
        public Nullable<System.DateTime> Date_Issue { get; set; }
        public string Note { get; set; }
        public Nullable<int> id_Work { get; set; }
        public Nullable<int> id_Detail { get; set; }
        public Nullable<int> id_Сheck { get; set; }
        public Nullable<int> id_Worker { get; set; }
        public string Status { get; set; }
    
        public virtual Check Check { get; set; }
        public virtual Client Client { get; set; }
        public virtual Detail Detail { get; set; }
        public virtual Work Work { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
