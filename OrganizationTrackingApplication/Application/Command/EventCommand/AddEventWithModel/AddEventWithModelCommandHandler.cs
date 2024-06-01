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
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IGenericRepository<Organizator> _organizatorRepository;
        private readonly IGenericRepository<Location> _locationRepository;

        public AddEventWithModelCommandHandler(IGenericRepository<User> userRepository, IGenericRepository<Event> eventRepository, IGenericRepository<Organizator> organizatorRepository, IGenericRepository<Location> locationRepository)
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
            _organizatorRepository = organizatorRepository;
            _locationRepository = locationRepository;
        }

        public async Task<AddEventWithModelOutputModel> Handle(AddEventWithModelCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var locationToBeAdded = new Location(request.AddressDescription, request.FormattedAddressName, request.Latitude, request.Longitude);

                await _locationRepository.Insert(locationToBeAdded);

                var organizatorSet = await _organizatorRepository.GetSet();

                var organizator = organizatorSet
                    .Include(a => a.User)
                    .FirstOrDefault(a => a.UserId.Equals(request.CreatedById));

                DateTime eventDate = DateTime.Parse(request.EventTime, null, System.Globalization.DateTimeStyles.RoundtripKind);

                var eventToBeAdded = new Event(request.EventName, eventDate, locationToBeAdded.Id, request.EventTypeId, organizator.Id, request.TicketPrice, request.TicketNumber,request.EventDescription);

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
                    IsSuccess = false,
                    Message = ex.InnerException.ToString()
                };
            }
        }
    }
}