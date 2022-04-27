using Movements.Dao.Interfaces;
using Movements.Dao.SQLServer;
using Movements.Domain;
using System;
using System.Collections.Generic;

namespace Movements.Dao.Implementations
{
    public class MovementsDao : IMovementsDao
    {
        private readonly IRepositoryMovements repositoryMovements;

        public MovementsDao(IRepositoryMovements repositoryMovements)
        {
            this.repositoryMovements = repositoryMovements;
        }

        public void deleteMovement(Guid id)
        {
            this.repositoryMovements.deleteMovement(id);
        }

        public Movement getMovement(Guid id)
        {
            return this.repositoryMovements.getMovement(id);
        }

        public IList<Movement> getMovements()
        {
            return this.repositoryMovements.getMovements();
        }

        public void saveMovement(Movement movement)
        {
            this.repositoryMovements.saveMovement(movement);
        }

        public void updateMovement(Movement movement, Guid id)
        {
            this.repositoryMovements.updateMovement(movement, id);
        }
    }
}
