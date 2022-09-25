using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;
using Newtonsoft.Json;
using System.Text;

namespace WebAppMVC.Controllers
{
    public class EmployeeController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:62347/api");
        HttpClient client;
        public EmployeeController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        // GET: Employees
        public ActionResult Index()
        {
            List<EmployeeViewModel> modelList = new List<EmployeeViewModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/employee").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
            }
            return View(modelList);
        }

        public ActionResult Find()
        {
            return View();
        }

        // GET: Employee by id
        [HttpPost]
        public ActionResult Find(int id)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/employee/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<EmployeeViewModel>(data);
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress + "/employee", content).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(responseMessage);
        }

        //public ActionResult Edit(int id)
        //{
        //    EmployeeViewModel model = new EmployeeViewModel();
        //    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/employee/" + id).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string data = response.Content.ReadAsStringAsync().Result;
        //        model = JsonConvert.DeserializeObject<EmployeeViewModel>(data);
        //    }
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Edit(EmployeeViewModel model)
        //{
        //    string data = JsonConvert.SerializeObject(model);
        //    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

        //    HttpResponseMessage responseMessage = client.PutAsync(client.BaseAddress + "/user/" + model.Id, content).Result;
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View("Create", model);
        //}
    }
}