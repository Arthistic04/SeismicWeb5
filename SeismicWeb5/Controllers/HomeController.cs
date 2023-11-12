using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeismicWeb5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Firebase.Database;
using Firebase.Database.Query;
using FirebaseAdmin.Auth;
using Newtonsoft.Json;


namespace SeismicWeb5.Controllers
{
    public class HomeController : Controller
    {
        private readonly FirebaseClient firebaseClient;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, FirebaseClient firebaseClient)
        {
            _logger = logger;
            this.firebaseClient = firebaseClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Earthquake()
        {
            return View();
        }

        public IActionResult Monitor()
        {
            return View();
        }

        public async Task<IActionResult> GetDataFromFirebase()
        {
            try
            {
                Console.WriteLine("Fetching data from Firebase...");
                var data = await FetchDataFromFirebaseAsync();
                if (data != null)
                {
                    Console.WriteLine("Data fetched successfully.");
                    return Json(data);
                }
                else
                {
                    Console.Error.WriteLine("Error fetching data from Firebase.");
                    return StatusCode(500, "Internal Server Error");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"HomeController Error fetching data from Firebase: {ex.Message}");
                Console.Error.WriteLine($"StackTrace: {ex.StackTrace}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        private async Task<DataModel> FetchDataFromFirebaseAsync()
        {
            try
            {
                var dataSnapshot = await firebaseClient.Child("User001").OnceSingleAsync<DataModel>();
                return dataSnapshot;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error fetching data from Firebase: {ex.Message}");
                return null;
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class DataModel
    {
        [JsonProperty("gyroX")]
        public float gyroX { get; set; }

        [JsonProperty("gyroY")]
        public float gyroY { get; set; }

        [JsonProperty("gyroZ")]
        public float gyroZ { get; set; }

        [JsonProperty("accX")]
        public float accX { get; set; }

        [JsonProperty("accY")]
        public float accY { get; set; }

        [JsonProperty("accZ")]
        public float accZ { get; set; }
    }
}
