using Spaceship.Interfaces;
using Spaceship.Views;
using System;

namespace Spaceship.Controllers
{
    public sealed class DamagebleController : IDisposable
    {
        private IDamageble _damagableModel;
        private PlayerHealthView _healthView;

        public DamagebleController(IDamageble damagableInterface, PlayerHealthView view)
        {
            _damagableModel = damagableInterface;
            _healthView = view;

            _damagableModel.OnHealthChanged += ChangePlayerHealth;
        }

        private void ChangePlayerHealth(int health)
        {
            _healthView.HealthTextComponent.text = health.ToString();
        }

        public void Dispose()
        {
            _damagableModel.OnHealthChanged -= ChangePlayerHealth;
        }
    }
}
