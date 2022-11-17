using Spaceship.Controllers;
using Spaceship.Player;
using System;
using UnityEngine;

namespace Spaceship
{
    public class ProjectEntrance : MonoBehaviour
    {
        public event Action EventOnAwake;
        public event Action EventOnStart;
        public event Action EventOnDisable;
        public event Action EventOnUpdate;

        private void Awake()
        {
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

    }
}

