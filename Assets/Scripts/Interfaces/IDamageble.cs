using System;

namespace Spaceship.Interfaces
{
    public interface IDamageble
    {
        public event Action<int> OnHealthChanged;
        void TakeDamage(int damage);
    }
}
