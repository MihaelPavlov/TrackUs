namespace TrackUs.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using TrackUs.Data.Common.Repositories;
    using TrackUs.Web.ViewModels;
    using TrackUs.Services.Mapping;
    using TrackUs.Data.Models.Services;

    using Microsoft.EntityFrameworkCore;
    using TrackUs.Data.Models;
    using System.Net;

    public class TrackAppService : ITrackAppService
    {
        private readonly IDeletableEntityRepository<Service> serviceRepository;
        private readonly IDeletableEntityRepository<Log> logRepository;
        //private readonly IDeletableEntityRepository<ServiceRequest> logRepository;
        //private readonly IDeletableEntityRepository<Log> logRepository;


        public TrackAppService(IDeletableEntityRepository<Service> serviceRepository, IDeletableEntityRepository<Log> logRepository)
        {
            this.serviceRepository = serviceRepository;

        }

        public async Task AddServiceByUserId(string userId, string serviceName, string service)
        {
            var newService = new Service
            {
                ApplicationUserId = userId,
                Name = serviceName,
                URL = service,
            };

            await this.serviceRepository.AddAsync(newService);

            await this.serviceRepository.SaveChangesAsync();
        }

        public Service GetServiceByUserIdAndName(string userId, string serviceName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ServiceViewModel>> GetUserServices(string userId)
        {
            return await this.serviceRepository.All().Where(x => x.ApplicationUserId == userId).To<ServiceViewModel>().ToListAsync();

        }

        public async Task<IEnumerable<LogViewModel>> GetLogs(int serviceId)
        {
            return await this.serviceRepository.All().Where(x => x.Id == serviceId).To<LogViewModel>().ToListAsync();
        }
    }
}
