namespace TrackUs.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TrackUs.Data.Models.Services;
    using TrackUs.Services.Mapping;

    public class ServiceViewModel : IMapFrom<Service>
    {
        public string ApplicationUserName { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }
    }
}
