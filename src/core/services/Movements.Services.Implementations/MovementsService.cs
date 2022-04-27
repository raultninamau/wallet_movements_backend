using Movements.Dao.Interfaces;
using Movements.Domain;
using Movements.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Movements.Services.Implementations
{
    public class MovementsService : IMovementsService
    {
        private readonly IMovementsDao movementsDao;

        public MovementsService(IMovementsDao movementsDao)
        {
            this.movementsDao = movementsDao;
        }

        public void deleteMovement(Guid id)
        {
            this.movementsDao.deleteMovement(id);
        }

        public Movement getMovement(Guid id)
        {
            return this.movementsDao.getMovement(id);
        }

        public IList<Movement> getMovements()
        {
            return this.movementsDao.getMovements();
        }

        public void saveMovement(Movement movement)
        {
            this.movementsDao.saveMovement(movement);
        }

        public void updateMovement(Movement movement, Guid id)
        {
            this.movementsDao.updateMovement(movement, id);
        }
    }
}
