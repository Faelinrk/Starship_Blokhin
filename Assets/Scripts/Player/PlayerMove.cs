using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spaceship.Interfaces;

namespace Spaceship.Player
{
    public sealed class PlayerMove :  IMovable
    {
        private const string Vertical = "Vertical";
        private const string Horyzontal = "Horyzontal";

        private bool _canMove = true;
        private Vector2 direction;
        private Rigidbody _rb;

        public PlayerMove(Rigidbody rb)
        {
            _rb = rb;
        }

        public bool TryToMove(float speed)
        {
            float horyzontal = Input.GetAxis(Horyzontal);
            float vertical = Input.GetAxis(Vertical);
            direction.Set(horyzontal, vertical);
            direction *= speed;
            return TryAddForce(direction, ForceMode.Impulse);
        }

        private bool TryAddForce(Vector3 direction, ForceMode forceMode)
        {
            if(_canMove)
            {
                _rb.AddForce(direction, ForceMode.Impulse);
                return true;
            }
            return false;
        }
    }
}

