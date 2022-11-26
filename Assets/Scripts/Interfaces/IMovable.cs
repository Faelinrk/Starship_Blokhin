using System;
using UnityEngine;
namespace Spaceship.Interfaces
{
    public interface IMovable
    {
        public event Action<Vector3> OnMovementInputChanged;
    }
}
