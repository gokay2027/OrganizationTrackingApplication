using MediatR;

namespace OrganizationTrackingApplicationApi.Model.Ticket.BuyTicket
{
    //Check if there is an available ticket and does the user have the ticket already
    //Get Event By Id and Get User by id and check if there in an available ticket for
    //the event by id

    public class BuyTicketCommand : IRequest<BuyTicketOutputModel>
    {
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
    }
}