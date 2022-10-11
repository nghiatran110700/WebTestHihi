using Newtonsoft.Json;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public ActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            //vi du thoi
            List<string> course = new List<string>() { "c#","Java"};
            student.Courses = course;
            //doan nay la call api get
            var content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
            var httpResponseMessage = clinet.PostAsync(bassAddress,content).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetStudent");
            }
            else 
                return View();
        }

        public ActionResult EditStudent(Guid id)
        {
            HttpResponseMessage httpResponseMessage = clinet.GetAsync($"{bassAddress}/{id}").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var Result = JsonConvert.DeserializeObject<Student>(data);
                return View(Result);
            }
            return View();
        }
        [HttpPut]
        public ActionResult EditStudent(Guid id, Student student)
        {
            var content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
            var httpResponseMessage = clinet.PutAsync($"{bassAddress}/{id}", content).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetStudent");
            }
            else
                return View();
        }

        public ActionResult DeleteStudent(Guid id)
        {
            HttpResponseMessage httpResponseMessage = clinet.GetAsync($"{bassAddress}/{id}").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var Result = JsonConvert.DeserializeObject<Student>(data);
                return View(Result);
            }
            return View();
        }
        public ActionResult DeleteConfirmed(Guid id)
        {
            HttpResponseMessage httpResponseMessage = clinet.DeleteAsync($"{bassAddress}/{id}").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetStudent");
            }
            return View();
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