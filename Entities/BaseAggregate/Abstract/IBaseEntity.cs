using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
