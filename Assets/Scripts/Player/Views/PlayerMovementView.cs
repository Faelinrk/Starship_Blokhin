using UnityEngine;

namespace Spaceship.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerMovementView : MonoBehaviour
    {
        public Rigidbody PlayerRigidbody;
    }
}
