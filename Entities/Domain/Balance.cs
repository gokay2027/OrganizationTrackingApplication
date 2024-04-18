using Entities.BaseAggregate.Concrete;

namespace Entities.Domain
{
    public class Balance : BaseEntity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public float Credit { get; private set; } = 1000;

        public Balance()
        {
        }

        public Balance(Guid userId)
        {
            UserId = userId;
        }

        public void AddCredit(float Amount)
        {
            Credit += Amount;
        }

        public void SpendCredit(float Amount)
        {
            if (Credit >= 0)
            {
                Credit -= Amount;
            }
        }

        public void UpdateCredit(float Amount)
        {
            Credit = Amount;
        }
    }
}