using Spaceship.Interfaces;
using System;


namespace Spaceship.Player
{
    public sealed class PlayerDamageModel : IDamageble
    {
        private int _hp = 100;

        public event Action<int> OnHealthChanged;
        public bool TryTakeDamage(int damage)
        {
            if (_hp > 0)
            {
                _hp -= damage;
                OnHealthChanged?.Invoke(_hp);
                return true;
            }
            return false;
        }

    }
}
