namespace TrackUs.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TrackUs.Data.Models.Services;
    using TrackUs.Services.Mapping;

    public class LogViewModel :IMapFrom<Service>
    {
        public virtual int ServiceRequestsRequestId { get; set; }

        public virtual Request Request { get; set; }

        public virtual int ServiceResponsesResponseId { get; set; }

        public virtual Response Response { get; set; }

        public DateTime ServiceResponsesResponseDate { get; set; }
    }
}
