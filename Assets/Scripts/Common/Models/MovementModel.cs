using Spaceship.Interfaces;
using System;
using UnityEngine;

namespace Spaceship.Models
{
    public sealed class MovementModel : IMovable
    {
        public event Action<float, float> OnSpeedChanged;
        private float _horizontalSpeed = 0f;
        private float _verticalSpeed = 0f;
        private float _maxSpeed = 10f;
        private float _accelerationCoeff = .1f;

        public void Accelerate(Vector3 accel)
        {
            _horizontalSpeed += accel.x * _accelerationCoeff;
            _verticalSpeed += accel.y * _accelerationCoeff;
            _horizontalSpeed = Mathf.Clamp(_horizontalSpeed, -_maxSpeed, _maxSpeed);
            _verticalSpeed = Mathf.Clamp(_verticalSpeed, -_maxSpeed, _maxSpeed);
            OnSpeedChanged?.Invoke(_horizontalSpeed, _verticalSpeed);
        }
    }
}

