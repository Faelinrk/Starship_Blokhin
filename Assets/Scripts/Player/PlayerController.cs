using System;
using UnityEngine;
using Spaceship.Interfaces;

namespace Spaceship.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerModel player;
        private IDamagable playerHealth;
        private IMovable playerMove;
        public static event Action<PlayerModel> OnPlayerInitialized;
        private void Awake()
        {
            player = new PlayerModel();
            playerMove = new PlayerMove();
            playerHealth = new PlayerHealth();
            OnPlayerInitialized?.Invoke(player);
        }
        private void OnTriggerEnter(Collider other)
        {
            playerHealth.TryTakeDamage(1);
        }
    }
}

