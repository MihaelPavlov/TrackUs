namespace TrackUs.Data.Models.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TrackUs.Data.Common.Models;

    public class ServiceRequest : IDeletableEntity
    {
        public virtual int ServiceId { get; set; }

        public virtual Service Service { get; set; }

        public virtual int RequestId { get; set; }

        public virtual Request Request { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
