using Spaceship.Models;
using Spaceship.Player;
using UnityEngine;

namespace Spaceship.Controllers
{
    public class EnemyMovementController
    {
        private MovementModel _enemyMovementModel;
        private Rigidbody _rb;
        private PlayerManager _playerManager;

        public EnemyMovementController(MovementModel enemyMovementModel, Rigidbody rb, ProjectEntrance projectEntrance)
        {
            _playerManager = projectEntrance.PlayerManager;
            _enemyMovementModel = enemyMovementModel;
            _rb = rb;
            _playerManager.OnPlayerUpdatePosition += ChangeSpeed;
            _enemyMovementModel.OnSpeedChanged += MoveEnemy;
        }

        public void ChangeSpeed(Vector3 playerPos)
        {
            Vector3 direction = _rb.position - playerPos;
            direction = direction.normalized;
            _enemyMovementModel.Accelerate(direction);
        }

        void MoveEnemy(float horizontalSpeed, float verticalSpeed)
        {
            Vector3 direction = new Vector3(horizontalSpeed, verticalSpeed, 0);
            _rb.velocity = direction;

        }
    }
}

