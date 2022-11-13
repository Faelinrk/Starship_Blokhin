using System;
using UnityEngine;

namespace Spaceship.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerModel player;
        private PlayerHealth playerHealth;
        private PlayerMove playerMove;
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

