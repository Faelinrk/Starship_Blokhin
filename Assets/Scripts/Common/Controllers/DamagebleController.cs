using Spaceship.Interfaces;
using Spaceship.Views;
using System;
using UnityEngine;
using Spaceship.Player;

namespace Spaceship.Controllers
{
    public sealed class DamagebleController : IDisposable
    {
        private ProjectEntrance _projectEntrance;
        private IDamageble _damagableModel;
        private HealthView _healthView;
        private int damage = 10;

        public DamagebleController(HealthView healthView, ProjectEntrance projectEntrance)
        {
            _projectEntrance = projectEntrance;
            _healthView = healthView;
            _damagableModel = new DamageModel();
            _damagableModel.OnHealthChanged += ChangePlayerViewHealth;
            _projectEntrance.EventOnUpdate += CheckEnemyNearby;
        }

        private void CheckEnemyNearby()
        {
            if (Physics.CheckSphere(_healthView.transform.position, 1f, _healthView.DangerousLayer))
            {
                _damagableModel.TakeDamage(damage);
            }
        }

        private void ChangePlayerViewHealth(int health)
        {
            _healthView.HealthTextComponent.text = health.ToString();
        }

        public void Dispose()
        {
            _damagableModel.OnHealthChanged -= ChangePlayerViewHealth;
            _projectEntrance.EventOnUpdate -= CheckEnemyNearby;
        }
    }
}
