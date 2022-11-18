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

        public PlayerMovementController(PlayerView player,  ProjectEntrance projectEntrance)
        {
            player.PlayerMovementView = player.gameObject.AddComponent(typeof(PlayerMovementView)) as PlayerMovementView;
            player.PlayerMovementModel = new PlayerMovementModel();
            _playerMovementModel = player.PlayerMovementModel;
            PlayerMovementView playerMovementView = player.PlayerMovementView;
            playerMovementView.PlayerRigidbody = player.GetComponent<Rigidbody>();
            _playerMovementModel.Rb = playerMovementView.PlayerRigidbody;
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
