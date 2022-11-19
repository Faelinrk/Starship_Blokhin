using Spaceship.Interfaces;
using System;


namespace Spaceship.Player
{
    public sealed class DamageModel : IDamageble
    {
        private int _hp = 100;

        public event Action<int> OnHealthChanged;
        public void TakeDamage(int damage)
        {
            if (_hp > 0)
            {
                _hp -= damage;
                OnHealthChanged?.Invoke(_hp);
            }
        }

    }
}
