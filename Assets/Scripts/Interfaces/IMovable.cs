using UnityEngine;
namespace Spaceship.Interfaces
{
    public interface IMovable
    {
        bool TryToMove(float speed);
    }
}
