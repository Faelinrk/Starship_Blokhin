using System;

namespace Spaceship.Interfaces
{
    public interface IDamageble
    {
        public event Action<int> OnHealthChanged;
        bool TryTakeDamage(int damage);
    }
}
