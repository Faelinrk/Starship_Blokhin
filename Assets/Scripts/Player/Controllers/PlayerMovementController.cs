using Spaceship.Models;
using System;
using UnityEngine;

namespace Spaceship.Controllers
{
    public class PlayerMovementController : IDisposable
    {
        private ProjectEntrance _projectEntrance;
        private MovementModel _playerMovementModel;
        private Rigidbody _rb;

        public PlayerMovementController(MovementModel playerMovementModel, Rigidbody rb, ProjectEntrance projectEntrance)
        {
            _projectEntrance = projectEntrance;
            _playerMovementModel = playerMovementModel;
            _rb = rb;
            projectEntrance.OnMovementInputChanged += ChangeSpeed;
            _playerMovementModel.OnSpeedChanged += MovePlayer;
        }

        public void ChangeSpeed(Vector3 accel)
        {
            _playerMovementModel.Accelerate(accel);
        }


        void MovePlayer(float horizontalSpeed, float verticalSpeed)
        {
            Vector3 direction = new Vector3(horizontalSpeed, verticalSpeed, 0);
            _rb.velocity = direction;
            
        }

        public void Dispose()
        {
            _projectEntrance.OnMovementInputChanged -= ChangeSpeed;
            _playerMovementModel.OnSpeedChanged -= MovePlayer;
        }
    }

}
