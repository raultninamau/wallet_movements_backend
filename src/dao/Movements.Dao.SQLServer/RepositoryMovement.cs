using Movements.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movements.Dao.SQLServer
{
    public class RepositoryMovements : IRepositoryMovements
    {
        private readonly IContextDatabase contextDatabase;
        private readonly Guid defaultId = new Guid("00000000-0000-0000-0000-000000000000");
        private readonly DateTime deafultDateTime = DateTime.MinValue;

        public RepositoryMovements(IContextDatabase contextDatabase)
        {
            this.contextDatabase = contextDatabase;
        }

        public void deleteMovement(Guid id)
        {
            Movement movement = contextDatabase.Movement.Find(id);
            contextDatabase.Movement.Remove(movement);
            contextDatabase.SaveChanges();
        }

        public Movement getMovement(Guid id)
        {
            Movement movement = contextDatabase.Movement.Find(id);
            contextDatabase.SaveChanges();
            return movement;
        }

        public IList<Movement> getMovements()
        {
            return this.contextDatabase.Movement.ToList();
        }

        public void saveMovement(Movement movement)
        {
            this.contextDatabase.Movement.Add(movement);
            this.contextDatabase.SaveChanges();
        }
         
        public void updateMovement(Movement movement, Guid id)
        {
            Movement current_movement = this.contextDatabase.Movement.First(item => item.Id == id);
            if (movement.IdCategory != defaultId) current_movement.IdCategory = movement.IdCategory;
            if (movement.IdGroup != defaultId) current_movement.IdGroup = movement.IdGroup;
            if (movement.Description != null) current_movement.Description = movement.Description;
            if (movement.Image != null) current_movement.Image = movement.Image;
            if (movement.Amount != 0) current_movement.Amount = movement.Amount;
            if (movement.Date != deafultDateTime) current_movement.Date = movement.Date;
            this.contextDatabase.SaveChanges();
        }
    }
}
