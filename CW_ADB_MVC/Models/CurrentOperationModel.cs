using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CW_ADB_MVC.Models
{
    public class CurrentOperationModel
    {
        public int CurrentOperationID { get; set; }
        public int CurrentFuelID { get; set; }
        public int CurrentTankID { get; set; }
        public string CurrentFuelType { get; set; }
        public string CurrentTankType { get; set; }
        public int CurrentPage { get; set; }

    }
}