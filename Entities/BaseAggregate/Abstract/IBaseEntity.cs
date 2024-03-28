namespace Entities.BaseAggregate.Abstract
{
    public interface IBaseEntity
    {
        /// <summary>
        /// Updates update date
        /// </summary>
        void UpdateDate();

        /// <summary>
        /// Deletes entity changes isActive to 0
        /// </summary>
        void Delete();
    }
}
