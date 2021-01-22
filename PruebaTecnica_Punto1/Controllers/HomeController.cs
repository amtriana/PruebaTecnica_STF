using Newtonsoft.Json.Linq;
using PruebaTecnica_Punto1.Models;
using PruebaTecnica_Punto1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica_Punto1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public HomeController()
        {
            System.Diagnostics.Trace.TraceInformation("Invoking Controller - Traceinformation");
        }
        public ActionResult Index()
        {
            return View();
        }
        public async System.Threading.Tasks.Task<ActionResult> FormularioConsulta()
        {
            List<QueryProducts> QueryInfo = new List<QueryProducts>();
            string prdId = "";
            string prdnombre = "";
            string cateId = "";
            if (Request.Form["_productId"]!=null)
                prdId = Request.Form["_productId"].ToString();
            if(Request.Form["_productName"]!=null)
                prdnombre = Request.Form["_productName"].ToString();
            if (Request.Form["_categoryId"] != null)
                cateId = Request.Form["_categoryId"].ToString();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://qastudiof.myvtex.com/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/api/catalog_system/pub/products/search");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    JToken jObj = JToken.Parse(EmpResponse);
                    QueryInfo = JsonHandler.ConvertToList(jObj, prdId, prdnombre, cateId);
                }
                return View(QueryInfo);
            }

        }

      

    }
}