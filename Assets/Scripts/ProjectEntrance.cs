using Spaceship.Player;
using System;
using UnityEngine;

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
        private PlayerManager _playerManager;
        #endregion

        private void Awake()
        {
            _playerManager = new PlayerManager(this);
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
            _playerManager.Dispose();
        }

    }
}

