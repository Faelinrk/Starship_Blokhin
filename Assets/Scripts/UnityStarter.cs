using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spaceship
{
    public class UnityStarter : MonoBehaviour
    {
        public event Action OnAwake;

        private void Awake()
        {
            OnAwake?.Invoke();
        }

    }
}

