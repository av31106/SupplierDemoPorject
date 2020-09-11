using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Text;
namespace BusinessLogicLayer
{
    //tightly coupled with DataAccessLayer
    public class Supplier : ISupplier
    {
        readonly IDataStorage _dataStorage;
        public Supplier()
        {
            _dataStorage = new DataStorage();
        }

        /// <summary>
        /// Get Suppliers list
        /// </summary>
        /// <param name="supplierNumber">Optional: Supplier Number</param>
        /// <returns>List of suppliers</returns>
        public List<SupplierModel> GetSuppliers(int? supplierNumber = null)
        {
            List<SupplierModel> list = new List<SupplierModel>();
            IEnumerable<IGrouping<int, DataRow>> result;
            DataTable resultDataTbl;
            
            //Getting static data from data access layer.
            resultDataTbl = _dataStorage.GetData();

            if (supplierNumber.HasValue) // Result base on supplier number
                result = resultDataTbl.AsEnumerable().Where(c => c.Field<Int32>("SupplierNumber") == supplierNumber).GroupBy(c => c.Field<Int32>("SupplierNumber"));
            else // All result 
                result = resultDataTbl.AsEnumerable().GroupBy(c => c.Field<Int32>("SupplierNumber"));

            //Converting into list.
            foreach (var group in result)
            {
                list.Add(new SupplierModel()
                {
                    SupplierNumber = group.Key,
                    SupplierRateList = group.Select(c => new SupplierRateModel()
                    {
                        Rate = c.Field<decimal>("Rate"),
                        StartDate = c.Field<DateTime>("StartDate"),
                        EndDate = c.Field<DateTime?>("EndDate")

                    }).ToList()
                });
            }
            return list;
        }
    }
}
