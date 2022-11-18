using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spaceship.Interfaces;

namespace Spaceship.Player
{
    public class PlayerMovementController
    {
        private PlayerMovementModel _playerMovementModel;

        public const string Vertical = "Vertical";
        public const string Horizontal = "Horizontal";
        public const float PlayerSpeed = 5;

        public PlayerMovementController(GameObject player,  ProjectEntrance projectEntrance)
        {         
            _playerMovementModel = new PlayerMovementModel();
            _playerMovementModel.Rb = player.AddComponent<Rigidbody>();
            _playerMovementModel.Rb.useGravity = false; // TODO: Load rigidbody parametrs from config?
            projectEntrance.EventOnUpdate += MovePlayer;
        }

        void MovePlayer()
        {
            float horizontal = Input.GetAxis(Horizontal);
            float vertical = Input.GetAxis(Vertical);
            Vector3 direction = new Vector3(horizontal, vertical, 0);
            _playerMovementModel.TryToMove(direction, PlayerSpeed);
        }
    }

}
