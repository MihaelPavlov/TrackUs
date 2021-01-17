namespace TrackUs.Data.Models.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TrackUs.Data.Common.Models;

    public class Response : BaseDeletableModel<int>
    {
        public Response()
        {
            this.Headers = new HashSet<Header>();
            this.Errors = new HashSet<Error>();
            this.Logs = new HashSet<Log>();
        }

        public string StatusCode { get; set; }

        public DateTime Date { get; set; }

        public bool IsTimeout { get; set; }

        public virtual ICollection<Error> Errors { get; set; }

        public virtual ICollection<Header> Headers { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}
