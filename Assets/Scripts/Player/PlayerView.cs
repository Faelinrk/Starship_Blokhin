using System;
using UnityEngine;

namespace Spaceship.Player
{
    public sealed class PlayerView : MonoBehaviour
    {
        [field: SerializeField] public int Health;
        [field: SerializeField] public float Speed;
        [field: SerializeField] public Rigidbody PlayerRigidbody;
    }

}
