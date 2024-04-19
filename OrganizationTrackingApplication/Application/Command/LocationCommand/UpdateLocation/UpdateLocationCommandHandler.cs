using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.Location.UpdateLocation;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.Command.LocationCommand.UpdateLocation
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, UpdateLocationOutputModel>
    {
        private readonly IGenericRepository<Location> _locationRepository;

        public UpdateLocationCommandHandler(IGenericRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public Task<UpdateLocationOutputModel> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            
            return null;
        }
    }
}