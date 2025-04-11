using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy
{
    internal class MultipleMovement : IMovementStrategy
    {
        private List<IMovementStrategy> movementStrategies;
        private IMovementStrategy currentMovementStrategy;
        float changeStrategyTime = 1f;
        float timeSinceLastChange;
        int currentStrategyIndex;

        public MultipleMovement(List<IMovementStrategy> movementStrategies)
        {
            this.movementStrategies = movementStrategies;
            currentMovementStrategy = this.movementStrategies.FirstOrDefault();
            currentMovementStrategy.RespawnAndSetNewPosition();
        }

        public void Move()
        {
            timeSinceLastChange += GameWorld.Instance.DeltaTime;

            if (timeSinceLastChange > changeStrategyTime)
            {
                ChangeStrategy();
                timeSinceLastChange = 0f;
            }

            if (currentMovementStrategy != null)
            {
                currentMovementStrategy.Move();
            }
        }

        public void RespawnAndSetNewPosition()
        {
            Debug.WriteLine(currentMovementStrategy);
            currentMovementStrategy.RespawnAndSetNewPosition();
        }

        private void ChangeStrategy()
        {
            currentStrategyIndex++;
            if (currentStrategyIndex >= movementStrategies.Count)
            {
                currentStrategyIndex = 0;
            }

            currentMovementStrategy = movementStrategies[currentStrategyIndex];
        }
    }
}
