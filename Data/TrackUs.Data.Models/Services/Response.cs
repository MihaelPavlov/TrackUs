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
        }

        public int StatusCode { get; set; }

        public DateTime Date { get; set; }

        public bool IsTimeout { get; set; }

        public virtual ICollection<Header> Headers { get; set; }
    }
}
