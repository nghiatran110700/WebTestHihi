using Newtonsoft.Json;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        Uri bassAddress = new Uri("https://localhost:7022/api/Students");
        HttpClient clinet;
        public HomeController()
        {
            clinet = new HttpClient();
            clinet.BaseAddress = bassAddress;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetStudent()
        {
            var Result = new List<Student>();
            HttpResponseMessage httpResponseMessage = clinet.GetAsync(bassAddress).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                Result = JsonConvert.DeserializeObject<List<Student>>(data);
            }
            return View(Result);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}