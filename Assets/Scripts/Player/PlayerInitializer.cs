using System;
using UnityEngine;
using Spaceship.Interfaces;
using Spaceship.Player;
using Spaceship.Views;

namespace Spaceship.Controllers
{
    public sealed class PlayerInitializer
    {
        public UnityStarter UnityStarter;
        public PlayerView Player;
        public IDamageble PlayerHealth;
        public IMovable PlayerMove;
        public DamagebleController DamagebleController;
        public HealthView HealthView;

        public PlayerInitializer()
        {
            UnityStarter.OnAwake += Initialize;
        }

        private void Initialize()
        {
            Player = new PlayerView();
            PlayerMove = new PlayerMove(Player.PlayerRigidbody);
            PlayerHealth = new PlayerHealth(Player);
            DamagebleController = new DamagebleController(PlayerHealth, HealthView);
        }

        ~PlayerInitializer()
        {
            DamagebleController.Dispose();
        }
    }
}