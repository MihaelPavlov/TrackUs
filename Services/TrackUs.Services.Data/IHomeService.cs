namespace TrackUs.Services.Data
{
    using System.Threading.Tasks;
    using TrackUs.Data.Models.Services;

    public interface IHomeService
    {
        Service GetServiceByUserIdAndName(string userId, string serviceName);

        Task AddServiceByUserId(string userId, string serviceName, string service);
    }
}