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

        public async Task<UpdateLocationOutputModel> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var output = new UpdateLocationOutputModel();
            try
            {
                var location = await _locationRepository.GetById(request.Id);

                location.Update(request.Description, location.FormattedName, location.Latitude, location.Longitude);

                await _locationRepository.Update(location);

                output.Message = "Location updated successfully";
                output.IsSuccess = true;
                return output;
            }
            catch (Exception ex)
            {
                output.Message = ex.Message;
                output.IsSuccess = false;
                return output;
            }
        }
    }
}