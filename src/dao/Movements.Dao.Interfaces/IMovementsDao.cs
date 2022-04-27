using Movements.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movements.Dao.Interfaces
{
    public interface IMovementsDao
    {
        IList<Movement> getMovements();

        Movement getMovement(Guid id);

        void saveMovement(Movement movement);

        void deleteMovement(Guid id);

        void updateMovement(Movement movement, Guid id);
    }
}
