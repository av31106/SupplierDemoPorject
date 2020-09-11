using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public interface ISupplier
    {
        /// <summary>
        /// Get Suppliers list
        /// </summary>
        /// <param name="supplierNumber">Optional: Supplier Number</param>
        /// <returns>List of suppliers</returns>
        List<SupplierModel> GetSuppliers(int? supplierNumber = null);
    }
}
