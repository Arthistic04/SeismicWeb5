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
                var data = await FetchDataFromFirebaseAsync();
                return Json(data);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"Error fetching data from Firebase: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        private async Task<List<DataModel>> FetchDataFromFirebaseAsync()
        {
            var dataSnapshot = await firebaseClient.Child("User001").OnceAsync<DataModel>();
            return dataSnapshot.Select(dataSnap => dataSnap.Object).ToList();

            /*
            var data = new List<DataModel>();

            foreach (var dataSnap in dataSnapshot)
            {
                var timestamp = dataSnap.Object.Timestamp;
                var x = dataSnap.Object.gyroX;
                var y = dataSnap.Object.gyroY;
                var z = dataSnap.Object.gyroZ;

                data.Add(new DataModel { Timestamp = timestamp, gyroX = x, gyroY = y, gyroZ = z });
            }

            return data;*/
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class DataModel
    {
        public DateTime Timestamp { get; set; }
        public float gyroX { get; set; }
        public float gyroY { get; set; }
        public float gyroZ { get; set; }
    }
}
