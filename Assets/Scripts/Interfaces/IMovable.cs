using System;
using UnityEngine;
namespace Spaceship.Interfaces
{
    public interface IMovable
    {
        public event Action OnMove;
        bool TryToMove(Vector3 direction, float speed);
    }
}
