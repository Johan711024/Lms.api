using Lms.Client.Clients;
using Lms.Client.Models;
using Lms.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lms.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IGameClient gameClient;
        private readonly HttpClient HttpClient;
        

        public HomeController(IHttpClientFactory httpClientFactory, IGameClient gameClient)
        {
            this.httpClientFactory = httpClientFactory;
            this.gameClient = gameClient;
        }

        public async Task<IActionResult> Index()
        {
            var res = await gameClient.GetAsync<IEnumerable<GameDto>>("api/events");
            var res2 = await gameClient.GetAsync<GameDto>("api/events/NewName");
            var res3 = await gameClient.GetAsync<GameDto>("api/events/NewName/lectures/1");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}