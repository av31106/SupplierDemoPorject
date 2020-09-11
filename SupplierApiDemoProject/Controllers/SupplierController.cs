using BusinessLogicLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SupplierApiDemoProject.Controllers
{
    public class SupplierController : ApiController
    {
        ISupplier supplier;
        public SupplierController()
        {
            supplier = new Supplier();
        }

        /// <summary>
        /// Return suppliers and suppliers rate list.
        /// </summary>
        /// <param name="supplierNumber">Optional: supplier Number</param>
        /// <returns>List of supplier(s)</returns>
        [HttpGet]
        public List<SupplierModel> GetSuppliers(int? supplierNumber = null)
        {
            return supplier.GetSuppliers(supplierNumber);
        }

    }
}
