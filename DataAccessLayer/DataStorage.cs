using System;
using System.Data;
using System.Globalization;

namespace DataAccessLayer
{
    public class DataStorage : IDataStorage
    {
        readonly DataTable _supplierRateData;
        public DataStorage()
        {
            //creating datatable structure.
            _supplierRateData = new DataTable();
            _supplierRateData.Columns.Add(new DataColumn("SupplierNumber", typeof(int)));
            _supplierRateData.Columns.Add(new DataColumn("Rate", typeof(decimal)));
            _supplierRateData.Columns.Add(new DataColumn("StartDate", typeof(DateTime)));
            _supplierRateData.Columns.Add(new DataColumn("EndDate", typeof(DateTime)));

            //Adding data rows.
            _supplierRateData.Rows.Add(new object[] {
                1,
                10,
                DateTime.ParseExact("01/01/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateTime.ParseExact("31/03/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture)
            });
            _supplierRateData.Rows.Add(new object[] {
                1,
                20,
                DateTime.ParseExact("01/04/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateTime.ParseExact("01/05/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture)
            });
            _supplierRateData.Rows.Add(new object[] {
                1,
                10,
                DateTime.ParseExact("30/05/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateTime.ParseExact("25/06/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture)
            });
            _supplierRateData.Rows.Add(new object[] {
                1,
                25,
                DateTime.ParseExact("01/10/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                null
            });

            _supplierRateData.Rows.Add(new object[] {
                2,
                100,
                DateTime.ParseExact("01/11/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                null
            });

            _supplierRateData.Rows.Add(new object[] {
                3,
                30,
                DateTime.ParseExact("01/12/2016", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateTime.ParseExact("01/01/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture)
            });
            _supplierRateData.Rows.Add(new object[] {
                3,
                30,
                DateTime.ParseExact("02/01/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                null
            });
        }

        /// <summary>
        /// Get stored data.
        /// </summary>
        /// <returns>Data</returns>
        public DataTable GetData()
        {
            return _supplierRateData;
        }
    }
}
