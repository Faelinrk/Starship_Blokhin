using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spaceship.Interfaces;
using System;

namespace Spaceship.Player
{
    public sealed class PlayerMovementModel :  IMovable
    {
        public Rigidbody Rb;

        public event Action OnMove;

        public bool TryToMove(Vector3 direction, float speed)
        {
            direction *= speed;
            Rb.AddForce(direction, ForceMode.Impulse);
            return true;
        }

    }
}

