namespace TrackUs.Data.Models.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TrackUs.Data.Common.Models;

    public class Log : BaseDeletableModel<int>
    {
        public virtual int RequestId { get; set; }

        public virtual Request Request { get; set; }

        public virtual int ResponseId { get; set; }

        public virtual Response Response { get; set; }
    }
}
