
using SupplierDemoPorject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SupplierDemoPorject.Controllers
{
    public class SupplierController : Controller
    {
        readonly string _apiBaseUrl;
        public SupplierController()
        {
            //Getting base url from web config file.
            _apiBaseUrl = WebConfigurationManager.AppSettings["BaseApiUrl"];
        }

        [HttpGet]
        public ActionResult Index(int? supplierNumber)
        {
            IEnumerable<SupplierModel> Suppliers = null;
            try
            {
                //Api URL
                string apiUrl = "Supplier/GetSuppliers" + (supplierNumber.HasValue ? "?supplierNumber=" + supplierNumber : "");

                //Call Web API for result with accept header of json data.
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_apiBaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var responseTask = client.GetAsync(apiUrl);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<SupplierModel>>();
                        readTask.Wait();
                        Suppliers = readTask.Result;
                    }
                    else
                    {
                        Suppliers = Enumerable.Empty<SupplierModel>();
                        ViewBag.Error = "Server error. Please contact administrator.";
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
            }

            return View(Suppliers);
        }
    }
}