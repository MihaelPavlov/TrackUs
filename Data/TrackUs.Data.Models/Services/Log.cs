namespace TrackUs.Data.Models.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TrackUs.Data.Common.Models;

    public class Log : BaseDeletableModel<int>
    {
        public virtual string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual int ServiceId { get; set; }

        public virtual Service Service { get; set; }

        public virtual int RequestId { get; set; }

        public virtual Request Request { get; set; }

        public virtual int ResponseId { get; set; }

        public virtual Response Response { get; set; }
    }
}
