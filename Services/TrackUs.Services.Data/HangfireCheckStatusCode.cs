namespace TrackUs.Services.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using TrackUs.Data.Common.Repositories;
    using TrackUs.Data.Models;
    using TrackUs.Data.Models.Services;

    public class HangfireCheckStatusCode
    {

        private readonly IDeletableEntityRepository<Service> serviceReposiotry;
        private readonly IDeletableEntityRepository<Request> requestReposiotry;
        private readonly IDeletableEntityRepository<Response> responseReposiotry;
        private readonly IDeletableEntityRepository<ServiceRequest> serviceRequestReposiotry;
        private readonly IDeletableEntityRepository<ServiceResponse> serviceResponseReposiotry;
        private readonly IDeletableEntityRepository<Header> headersReposiotry;

        public HangfireCheckStatusCode(
                 IDeletableEntityRepository<Service> serviceReposiotry,
                 IDeletableEntityRepository<Request> requestReposiotry,
                 IDeletableEntityRepository<Response> responseReposiotry,
                 IDeletableEntityRepository<ServiceRequest> serviceRequestReposiotry,
                 IDeletableEntityRepository<ServiceResponse> serviceResponseReposiotry,
                 IDeletableEntityRepository<Header> headersReposiotry)
        {
            this.serviceReposiotry = serviceReposiotry;
            this.requestReposiotry = requestReposiotry;
            this.responseReposiotry = responseReposiotry;
            this.serviceRequestReposiotry = serviceRequestReposiotry;
            this.serviceResponseReposiotry = serviceResponseReposiotry;
            this.headersReposiotry = headersReposiotry;
        }

        public async Task CheckStatus()
        {
            var getAllServices = await this.serviceReposiotry.All().ToListAsync();

            foreach (var service in getAllServices)
            {
                await this.Track(service.URL, service.Id);
            }
        }

        public async Task Track(string url, int serviceId)

        {
            Uri myUri = new Uri(url);

            // Create a new request to the above mentioned URL.
            WebRequest myWebRequest = WebRequest.Create(myUri);

            // Set Timeout From 5 sec.
            myWebRequest.Timeout = 500;

            // Assign the response object of 'WebRequest' to a 'WebResponse' variable.

            var newServiceResponse = new ServiceResponse
            {
                ServiceId = serviceId,
            };



            var headers = new List<Header>();

            try
            {
                using (HttpWebResponse webresponse = (HttpWebResponse)myWebRequest.GetResponse())
                {
                    var newResponse = new Response
                    {
                        Date = DateTime.UtcNow,
                        // replaced 232 OK with 200 to be more userFriendly
                        StatusCode = webresponse.StatusCode.ToString() == "OK" ? "200 OK" : " ",
                        IsTimeout = false,
                    };



                    //for (int i = 0; i < webresponse.Headers.Count; i++)
                    //{
                    //    var newHeader = new Header
                    //    {
                    //        Key = webresponse.Headers.Keys[i],
                    //        Value = webresponse.Headers[i],
                    //    };
                    //    newResponse.Headers.Add(newHeader);
                    //}
                    newServiceResponse.ResponseId = newResponse.Id;
                    await this.responseReposiotry.AddAsync(newResponse);
                }
            }
            catch (WebException ex)
            {
                var newResponse = new Response
                {
                    Date = DateTime.UtcNow,
                    StatusCode = (int)((HttpWebResponse)ex.Response).StatusCode + " " + ((HttpWebResponse)ex.Response).StatusCode.ToString(),
                    IsTimeout = true,
                };
                await this.responseReposiotry.AddAsync(newResponse);
                newServiceResponse.Response = newResponse;
                newServiceResponse.ResponseId = newResponse.Id;
            }

            await this.serviceResponseReposiotry.AddAsync(newServiceResponse);
            await this.responseReposiotry.SaveChangesAsync();
            await this.serviceResponseReposiotry.SaveChangesAsync();

        }
    }
}
