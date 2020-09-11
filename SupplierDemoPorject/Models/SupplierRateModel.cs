using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierDemoPorject.Models
{
    public class SupplierRateModel
    {
        //public int SupplierNumber { get; set; }
        public decimal Rate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
