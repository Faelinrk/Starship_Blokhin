using Spaceship.Interfaces;
using Spaceship.Models;
using System;
using UnityEngine;

namespace Spaceship.Controllers
{
    public class UnitMovementController : IDisposable
    {
        private IMovable _movableInterface;
        private MovementModel _unitMovementModel;
        private Rigidbody _rb;
        public event Action<Vector3> OnUnitUpdatePosition;

        public UnitMovementController(MovementModel unitMovementModel, Rigidbody rb, IMovable movableInterface)
        {
            _movableInterface = movableInterface;
            _unitMovementModel = unitMovementModel;
            _rb = rb;
            _movableInterface.OnMovementInputChanged += _unitMovementModel.Accelerate;
            _unitMovementModel.OnSpeedChanged += MoveUnit;
        }


        void MoveUnit(Vector3 direction)
        {
            _rb.velocity = direction;
            
        }

        private void ActualizeUnitPosition()
        {
            OnUnitUpdatePosition?.Invoke(_rb.transform.position);
        }
        public void Dispose()
        {
            _movableInterface.OnMovementInputChanged -= _unitMovementModel.Accelerate;
            _unitMovementModel.OnSpeedChanged -= MoveUnit;
        }
    }

}
