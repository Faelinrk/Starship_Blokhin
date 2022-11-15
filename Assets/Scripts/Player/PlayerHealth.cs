using Spaceship.Interfaces;
using System;


namespace Spaceship.Player
{
    public sealed class PlayerHealth : IDamageble
    {
        PlayerView _playerView;
        public PlayerHealth(PlayerView playerView)
        {
            _playerView = playerView;
        }

        public event Action<int> PlayerOnHealthChanged;
        public bool TryTakeDamage(int damage)
        {
            if (_playerView.Health > 0)
            {
                _playerView.Health -= damage;
                PlayerOnHealthChanged?.Invoke(_playerView.Health);
                return true;
            }
            return false;
        }

    }
}
