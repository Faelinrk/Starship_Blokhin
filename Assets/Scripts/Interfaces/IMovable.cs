using System;
using UnityEngine;
namespace Spaceship.Interfaces
{
    public interface IMovable
    {
        public event Action<float, float> OnSpeedChanged;
        void Accelerate(Vector3 accel);
    }
}
