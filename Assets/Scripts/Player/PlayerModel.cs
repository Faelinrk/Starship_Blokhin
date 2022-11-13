using System;
using UnityEngine;

namespace Spaceship.Player
{
    public class PlayerModel
    {
        [field: SerializeField] public int Health { get; set; }
        [field: SerializeField] public float Speed { get; set; }
        [field: SerializeField] public Rigidbody PlayerRigidbody { get; set; }
    }

}
