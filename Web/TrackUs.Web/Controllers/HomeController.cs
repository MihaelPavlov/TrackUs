namespace TrackUs.Web.Controllers
{
    using System.Diagnostics;

    using TrackUs.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using System;
    using System.Net.Http;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            // Create a new 'Uri' object with the specified string.
            Uri myUri = new Uri("https://cyberwars.azurewebsites.net/");
            // Create a new request to the above mentioned URL. 
            WebRequest myWebRequest = WebRequest.Create(myUri);
            myWebRequest.Timeout = 5;

            // Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            //   WebResponse myWebResponse = myWebRequest.GetResponse();

            try
            {
                using (HttpWebResponse webresponse = (HttpWebResponse)myWebRequest.GetResponse())
                {
                    this.ViewBag.result = webresponse.StatusCode.ToString();
                }

            }
            catch (Exception ex )
            {
                this.ViewBag.result = ex.Message;
            }
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
