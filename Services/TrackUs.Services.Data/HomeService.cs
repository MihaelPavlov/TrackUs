namespace TrackUs.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TrackUs.Data.Common.Repositories;
    using TrackUs.Data.Models.Services;

    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<Service> serviceRepository;

        public HomeService(IDeletableEntityRepository<Service> serviceRepository)
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
    }
}
