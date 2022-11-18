using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spaceship.Player;
using System;

namespace Spaceship.Factories
{
    public class PlayerFactory : IDisposable
    {
        private ProjectEntrance _projectEntrance;

        public PlayerFactory(ProjectEntrance projectEntrance)
        {
            _projectEntrance = projectEntrance;
            _projectEntrance.EventOnAwake += InstantiatePlayer;
        }

        public void InstantiatePlayer()
        {
            PlayerView player = UnityEngine.Object.Instantiate(new GameObject().AddComponent(typeof(PlayerView))) as PlayerView;
            player.PlayerMovementView = player.gameObject.AddComponent(typeof(PlayerMovementView)) as PlayerMovementView;
            player.PlayerMovementView.PlayerRigidbody = player.GetComponent<Rigidbody>();
            player.PlayerMovementModel = new PlayerMovementModel();
            player.PlayerMovementController = new PlayerMovementController(player.PlayerMovementModel, player.PlayerMovementView, _projectEntrance);
        }

        public void Dispose()
        {
            _projectEntrance.EventOnAwake -= InstantiatePlayer;
        }

    }
}

