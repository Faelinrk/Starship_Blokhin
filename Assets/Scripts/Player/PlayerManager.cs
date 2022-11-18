using System;
using UnityEngine;

namespace Spaceship.Player
{
    public class PlayerManager : IDisposable
    {
        private ProjectEntrance _projectEntrance;

        public PlayerManager(ProjectEntrance projectEntrance)
        {
            _projectEntrance = projectEntrance;
            _projectEntrance.EventOnAwake += InstantiatePlayer;
        }

        public void InstantiatePlayer()
        {
            PlayerView player = UnityEngine.Object.Instantiate(new GameObject().AddComponent(typeof(PlayerView))) as PlayerView;
            player.PlayerMovementController = new PlayerMovementController(player, _projectEntrance);
        }

        public void Dispose()
        {
            _projectEntrance.EventOnAwake -= InstantiatePlayer;
        }

    }
}