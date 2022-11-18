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
            GameObject player = UnityEngine.Object.Instantiate(new GameObject());
            new PlayerMovementController(player, _projectEntrance);
        }

        public void Dispose()
        {
            _projectEntrance.EventOnAwake -= InstantiatePlayer;
        }

    }
}