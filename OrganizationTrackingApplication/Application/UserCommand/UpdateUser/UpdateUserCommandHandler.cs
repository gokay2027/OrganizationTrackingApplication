using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.User.UpdateUser;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.UserCommand.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserOutputModel>
    {
        private readonly IGenericRepository<User> _userRepository;

        public UpdateUserCommandHandler(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateUserOutputModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userToBeUpdated = await _userRepository.GetById(request.InputModel.Id);

                var inputModel = request.InputModel;

                userToBeUpdated.Update(inputModel.Name, inputModel.Surname, inputModel.Email, inputModel.Password, inputModel.Gender);

                await _userRepository.Update(userToBeUpdated);

                return new UpdateUserOutputModel
                {
                    IsSuccess = true,
                    Message = "User updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new UpdateUserOutputModel
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message
                };
            }
        }
    }
}