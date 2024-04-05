using Entities.Domain;
using OrganizationTrackingApplicationApi.Application.Query.Abstract;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.Query
{
    public class UserQuery : IUserQuery
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserQuery(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
    }
}