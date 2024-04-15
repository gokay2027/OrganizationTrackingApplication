using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.Location.AddLocation;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.Command.LocationCommand.AddLocation
{
    public class AddLocationCommandHandler : IRequestHandler<AddLocationCommand, AddLocationOutputModel>
    {
        private readonly IGenericRepository<Location> _locationRepository;

        public AddLocationCommandHandler(IGenericRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<AddLocationOutputModel> Handle(AddLocationCommand request, CancellationToken cancellationToken)
        {

            try
            {
                await _locationRepository.Insert(new Location(request.Description, request.FormattedName, request.Latitude, request.Longitude));
                return new AddLocationOutputModel()
                {
                    IsSuccess = true,
                    Message = "Location has been added successfully"
                };
            }
            catch (Exception ex)
            {

                return new AddLocationOutputModel()
                {
                    IsSuccess = false,
                    Message=ex.Message,
                };
            }
           


            throw new NotImplementedException();
        }
    }
}