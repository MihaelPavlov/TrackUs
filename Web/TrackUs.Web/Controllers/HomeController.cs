namespace TrackUs.Web.Controllers
{
    using System.Diagnostics;

    using TrackUs.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using System;
    using System.Net.Http;
    using TrackUs.Services.Data;
    using System.Threading.Tasks;
    using System.Security.Claims;

    public class HomeController : BaseController
    {
       
        public async Task<IActionResult> Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
