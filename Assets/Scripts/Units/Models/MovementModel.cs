using Spaceship.Interfaces;
using System;
using UnityEngine;

namespace Spaceship.Models
{
    public sealed class MovementModel
    {
        public event Action<Vector3> OnSpeedChanged;
        private float _horizontalSpeed = 0f;//TODO: Push out from model to unit View
        private float _verticalSpeed = 0f;
        private float _maxSpeed = 10f;
        private float _accelerationCoeff = .1f;

        public void Accelerate(Vector3 accel)
        {
            _horizontalSpeed += accel.x * _accelerationCoeff;
            _verticalSpeed += accel.y * _accelerationCoeff;
            _horizontalSpeed = Mathf.Clamp(_horizontalSpeed, -_maxSpeed, _maxSpeed);
            _verticalSpeed = Mathf.Clamp(_verticalSpeed, -_maxSpeed, _maxSpeed);
            OnSpeedChanged?.Invoke(new Vector3(_horizontalSpeed, _verticalSpeed,0));
        }
    }
}

