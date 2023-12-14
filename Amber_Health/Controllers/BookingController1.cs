using Amber_Health.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Amber_Health.Controllers
{
    public class BookingController1 : Controller
    {
        private readonly HttpClient _httpClient;
        public BookingController1()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7291/api/Booking");

        }
        public IActionResult Index()
        {
            //Tells it where to get the response from
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress).Result;
            List<BookingVM> LstBookings = new List<BookingVM>();
            if (response.IsSuccessStatusCode)
            {
                //send over a list of Booking and accepts it as a string
                var data = response.Content.ReadAsStringAsync().Result;
                //Deserialization
                LstBookings = JsonConvert.DeserializeObject<List<BookingVM>>(data);
                return View(LstBookings);
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            //Accepts an ID and find the Student with api
            BookingVM booking = new BookingVM();
            HttpResponseMessage response = _httpClient.GetAsync($"{_httpClient.BaseAddress}/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                //Deserialzation
                booking = JsonConvert.DeserializeObject<BookingVM>(data);
                return View(booking);

            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            BookingVM bookingVM = new BookingVM();

            return View(bookingVM);
        }
        [HttpPost]
        //Accept Information
        public async Task<IActionResult> Create(BookingVM bookingVM)
        {
            string jsonContent = JsonConvert.SerializeObject(bookingVM);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(bookingVM);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Accepts an ID and find the product with api
            BookingVM booking = new BookingVM();
            HttpResponseMessage response = _httpClient.GetAsync($"{_httpClient.BaseAddress}/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                //Deserialzation
                booking = JsonConvert.DeserializeObject<BookingVM>(data);
                return View(booking);

            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(BookingVM model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync($"{_httpClient.BaseAddress}", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            BookingVM booking = new BookingVM();
            HttpResponseMessage response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                booking = JsonConvert.DeserializeObject<BookingVM>(data);

            }
            return View(booking);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_httpClient.BaseAddress}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
