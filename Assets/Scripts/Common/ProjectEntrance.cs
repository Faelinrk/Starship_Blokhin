using Spaceship.Player;
using System;
using System.Collections;
using UnityEngine;

namespace Spaceship
{
    public class ProjectEntrance : MonoBehaviour
    {
        #region Constants
        public const string Vertical = "Vertical";
        public const string Horizontal = "Horizontal";
        #endregion

        #region Events
        public event Action EventOnAwake;
        public event Action EventOnStart;
        public event Action EventOnDisable;
        public event Action EventOnUpdate;
        public event Action<Vector3> OnMovementInputChanged;
        #endregion

        #region Managers
        public PlayerManager PlayerManager;
        #endregion

        private void Awake()
        {
            PlayerManager = new PlayerManager(this);
            StartCoroutine(PlayerManager.InstantiatePlayer());
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
            float horizontal = Input.GetAxis(Horizontal);
            float vertical = Input.GetAxis(Vertical);
            if(horizontal != 0 || vertical != 0)
                OnMovementInputChanged?.Invoke(new Vector3(horizontal, vertical, 0));
        }
    }
}

