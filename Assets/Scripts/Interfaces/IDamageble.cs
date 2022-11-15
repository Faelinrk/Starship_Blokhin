using System;

namespace Spaceship.Interfaces
{
    public interface IDamageble
    {
        public event Action<int> PlayerOnHealthChanged;
        bool TryTakeDamage(int damage);
    }
}
