using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class ReciboController : Controller
    {
        // GET: Recibo
        public ActionResult Index()
        {
            IEnumerable<mvcReciboModel> recibosList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Recibos").Result;
            recibosList = response.Content.ReadAsAsync<IEnumerable<mvcReciboModel>>().Result;
            return View(recibosList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new mvcReciboModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Recibos/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcReciboModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcReciboModel rec)
        {
            if(rec.ReciboID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Recibos", rec).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Recibos/" + rec.ReciboID, rec).Result;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Recibos/"+id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}