namespace TrackUs.Data.Models.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TrackUs.Data.Common.Models;

    public class Service : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public virtual string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string URL { get; set; }

        public virtual ICollection<ServiceResponse> ServiceResponses { get; set; }

        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
