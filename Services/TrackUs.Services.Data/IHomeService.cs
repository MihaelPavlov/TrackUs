namespace TrackUs.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TrackUs.Data.Models.Services;
    using TrackUs.Web.ViewModels;

    public interface IHomeService
    {
        Service GetServiceByUserIdAndName(string userId, string serviceName);

        Task AddServiceByUserId(string userId, string serviceName, string service);

        Task<IEnumerable<ServiceViewModel>> GetUserServices(string userId);
    }
}