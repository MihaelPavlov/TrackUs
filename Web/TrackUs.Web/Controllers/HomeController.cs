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
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            // Create a new 'Uri' object with the specified string.
            Uri myUri = new Uri("https://getbootstrap.com/docs/4.0/content/tables/");// user => services => request, response => 
            // Create a new request to the above mentioned URL. 
            WebRequest myWebRequest = WebRequest.Create(myUri);
            myWebRequest.Timeout = 500;

            // Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            //   WebResponse myWebResponse = myWebRequest.GetResponse();

            try
            {
                using (HttpWebResponse webresponse = (HttpWebResponse)myWebRequest.GetResponse())
                {
                    this.ViewBag.result = webresponse.StatusCode.ToString();

                }

            }
            catch (Exception ex)
            {
                this.ViewBag.result = ex.Message;
            }
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string service, string serviceName)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.homeService.AddServiceByUserId(userId, serviceName, service);

            return this.Redirect("/");
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
