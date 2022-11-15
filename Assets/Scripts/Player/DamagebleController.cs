using Spaceship.Interfaces;
using Spaceship.Views;
using System;

namespace Spaceship.Controllers
{
    public sealed class DamagebleController : IDisposable
    {
        private IDamageble _damagableInterface;
        private HealthView _view;

        public DamagebleController(IDamageble damagableInterface, HealthView view)
        {
            _damagableInterface = damagableInterface;
            _view = view;
            _damagableInterface.PlayerOnHealthChanged += _view.ChangeHealthText;
        }
        public void Dispose()
        {
            _damagableInterface.PlayerOnHealthChanged -= _view.ChangeHealthText;
        }
    }
}
