using Spaceship.Controllers;
using Spaceship.Player;
using System;
using UnityEngine;

namespace Spaceship
{
    public class UnityStarter : MonoBehaviour
    {
        private PlayerInstance _playerController;
        [SerializeField] private PlayerInstance _playerViewPrefab;
        public event Action EventOnAwake;
        public event Action EventOnStart;
        public event Action EventOnDisable;

        private void Awake()
        {
            EventOnAwake?.Invoke();
        }
        private void Start()
        {
            _playerController = Instantiate(_playerViewPrefab);
            _playerController._player = new PlayerInitializer(this);
            EventOnStart?.Invoke();
        }
        private void OnDisable()
        {
            Destroy(_playerController);
            EventOnDisable?.Invoke();
        }

    }
}

