using Spaceship.Interfaces;
using System;


namespace Spaceship.Player
{
    public class PlayerHealth : PlayerComponent, IDamagable
    {
        public static event Action<int> PlayerOnHealthChanged;
        public bool TryTakeDamage(int damage)
        {
            if (damage > playerModel.Health)
            {
                damage = playerModel.Health;
            }
            if (playerModel.Health > 0)
            {
                playerModel.Health -= damage;
                PlayerOnHealthChanged?.Invoke(playerModel.Health);
                return true;
            }
            return false;
        }

    }
}
