namespace TrackUs.Data.Models.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TrackUs.Data.Common.Models;

    public class Request : BaseDeletableModel<int>
    {
        public Request()
        {
            this.Headers = new HashSet<Header>();
            this.Logs = new HashSet<Log>();
        }

        public string RequestType { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Header> Headers { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}
