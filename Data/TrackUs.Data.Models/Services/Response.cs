namespace TrackUs.Data.Models.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TrackUs.Data.Common.Models;

    public class Response : BaseDeletableModel<int>
    {
        public int StatusCode { get; set; }
    }
}
