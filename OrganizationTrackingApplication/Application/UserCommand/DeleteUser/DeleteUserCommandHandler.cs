using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.User.DeleteUser;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.UserCommand.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserOutputModel>
    {
        private IGenericRepository<User> _userRepository;

        public DeleteUserCommandHandler(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DeleteUserOutputModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _userRepository.Delete(request.InputModel.Id);
                return new DeleteUserOutputModel()
                {
                    IsSuccess = true,
                    Message = "User has been deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new DeleteUserOutputModel()
                {
                    IsSuccess = true,
                    Message = ex.InnerException.Message
                };
            }
        }
    }
}