namespace TrackUs.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TrackUs.Services.Data;

    public class TrackAppController : Controller
    {

        private readonly ITrackAppService trackAppService;

        public TrackAppController(ITrackAppService trackAppService)
        {
            this.trackAppService = trackAppService;
        }

        public async Task<IActionResult> AddService()
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
        public async Task<IActionResult> AddService(string service, string serviceName)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.trackAppService.AddServiceByUserId(userId, serviceName, service);

            return this.RedirectToAction(nameof(this.MyServices));
        }

        public async Task<IActionResult> MyServices()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = await this.trackAppService.GetUserServices(userId);

            return this.View(viewModel);
        }

    }
}
