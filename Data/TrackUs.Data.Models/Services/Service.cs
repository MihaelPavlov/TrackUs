namespace TrackUs.Data.Models.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TrackUs.Data.Common.Models;

    public class Service : BaseDeletableModel<int>
    {
        public virtual string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string URL { get; set; }
    }
}
