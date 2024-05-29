using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.Event.AddEventWithModelCommand;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;
using System.Data.Entity;

namespace OrganizationTrackingApplicationApi.Application.Command.EventCommand.AddEventWithModel
{
    public class AddEventWithModelCommandHandler : IRequestHandler<AddEventWithModelCommand, AddEventWithModelOutputModel>
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Location> _locationRepository;
        private readonly IGenericRepository<Event> _eventRepository;

        public AddEventWithModelCommandHandler(IGenericRepository<User> userRepository, IGenericRepository<Location> locationRepository, IGenericRepository<Event> eventRepository)
        {
            _userRepository = userRepository;
            _locationRepository = locationRepository;
            _eventRepository = eventRepository;
        }

        public async Task<AddEventWithModelOutputModel> Handle(AddEventWithModelCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var locationToBeAdded = new Location(request.AddressDescription, request.FormattedAddressName, request.Latitude, request.Longitude);

                var userSet = await _userRepository.GetSet();

                var user = userSet.Include(u => u.Organizator).FirstOrDefault(a => a.Id.Equals(request.CreatedById));

                DateTime eventDate = DateTime.Parse(request.EventTime, null, System.Globalization.DateTimeStyles.RoundtripKind);

                var eventToBeAdded = new Event(request.EventName, eventDate, locationToBeAdded.Id, request.EventTypeId, user.Organizator.Id, request.TicketPrice, request.TicketNumber);

                await _eventRepository.Insert(eventToBeAdded);

                return new AddEventWithModelOutputModel
                {
                    IsSuccess = true,
                    Message = "Event has been added successfully"
                };
            }
            catch (Exception ex)
            {
                return new AddEventWithModelOutputModel
                {
                    IsSuccess = true,
                    Message = ex.Message
                };
            }
        }
    }
}