namespace TrackUs.Data.Models.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TrackUs.Data.Common.Models;

    public class Header : BaseDeletableModel<int>
    {
        public string Key { get; set; }

        public string Value { get; set; }


    }
}
