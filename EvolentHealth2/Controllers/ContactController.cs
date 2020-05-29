using EvolentHealth2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace EvolentHealth2.Controllers
{
    public class ContactController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:55862/");
        HttpClient client;

        public ContactController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: Contact
        public ActionResult Index()
        {
            List<ContactViewModel> modelList = new List<ContactViewModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "api/user").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<ContactViewModel>>(data);
            }
            return View("Index", modelList);
        }
       
        public ActionResult Create(ContactViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "api/user", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            ContactViewModel model = new ContactViewModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "api/user/"+ id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<ContactViewModel>(data);
                //return RedirectToAction("Index");
            }
            return View("Create", model);
        }
        [HttpPost]
        public ActionResult Edit(ContactViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "api/user/" + model.UserID, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create", model);
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "api/user/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}