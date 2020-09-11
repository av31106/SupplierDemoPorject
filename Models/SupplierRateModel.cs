using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class SupplierRateModel
    {
        public decimal Rate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
