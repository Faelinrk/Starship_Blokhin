using Spaceship.Controllers;
using Spaceship.Player;
using System;
using UnityEngine;
using Spaceship.Factories;

namespace Spaceship
{
    public class ProjectEntrance : MonoBehaviour
    {
        #region Events
        public event Action EventOnAwake;
        public event Action EventOnStart;
        public event Action EventOnDisable;
        public event Action EventOnUpdate;
        #endregion

        #region Factories
        private PlayerFactory _playerFactory;
        #endregion

        private void Awake()
        {
            _playerFactory = new PlayerFactory(this);
            EventOnAwake?.Invoke();
        }
        private void Start()
        {
            EventOnStart?.Invoke();
        }
        private void OnDisable()
        {
            EventOnDisable?.Invoke();
        }

        private void Update()
        {
            EventOnUpdate?.Invoke();
        }

        private void OnDestroy()
        {
            _playerFactory.Dispose();
        }

    }
}

