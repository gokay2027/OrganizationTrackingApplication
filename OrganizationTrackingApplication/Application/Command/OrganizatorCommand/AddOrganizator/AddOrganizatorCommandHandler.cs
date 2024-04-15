using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.Organizator.AddOrganizator;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.Command.OrganizatorCommand.AddOrganizator
{
    public class AddOrganizatorCommandHandler : IRequestHandler<AddOrganizatorCommand, AddOrganizatorOutputModel>
    {
        private readonly IGenericRepository<Organizator> _organizatorRepository;

        public AddOrganizatorCommandHandler(IGenericRepository<Organizator> organizatorRepository)
        {
            _organizatorRepository = organizatorRepository;
        }

        public async Task<AddOrganizatorOutputModel> Handle(AddOrganizatorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _organizatorRepository.Insert(new Organizator(request.Name));
                return new AddOrganizatorOutputModel
                {
                    IsSuccess = true,
                    Message = "Organiztor has been added successfully",
                };
            }
            catch (Exception ex)
            {

                return new AddOrganizatorOutputModel
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }

        }
    }
}
