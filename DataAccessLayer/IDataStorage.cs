using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccessLayer
{
    public interface IDataStorage
    {
        /// <summary>
        /// Get stored data.
        /// </summary>
        /// <returns>Data</returns>
        DataTable GetData();
    }
}
