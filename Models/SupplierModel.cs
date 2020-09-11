using System;
using System.Collections.Generic;

namespace Models
{
    public class SupplierModel
    {
        public int SupplierNumber { get; set; }
        public List<SupplierRateModel> SupplierRateList { get; set; }
    }
}
