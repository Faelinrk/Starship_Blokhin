using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spaceship.Interfaces;

namespace Spaceship.Player
{
    public class PlayerMove : PlayerComponent, IMovable
    {
        private const string Vertical = "Vertical";
        private const string Horyzontal = "Horyzontal";
        public bool TryToMove(float speed)
        {
            if (playerModel.PlayerRigidbody)
            {
                float horyzontal = Input.GetAxis(Horyzontal);
                float vertical = Input.GetAxis(Vertical);
                Vector2 direction = new Vector2(horyzontal, vertical); 
                playerModel.PlayerRigidbody.AddForce(direction * speed, ForceMode.Impulse);
                return true;
            }
            return false;
        }
    }
}

