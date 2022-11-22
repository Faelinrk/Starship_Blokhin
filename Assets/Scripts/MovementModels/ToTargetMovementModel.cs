using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spaceship.Interfaces
{
    public class ToTargetMovementModel : IMovable
    {
        public event Action<Vector3> OnMovementInputChanged;
        public Vector3 Target;
        public Vector3 ObjectPosition;
        public ToTargetMovementModel(Vector3 objectPosition, Vector3 target)
        {
            Target = target;
            ObjectPosition = objectPosition;
        }

        public void FollowTarget()
        {
            OnMovementInputChanged?.Invoke((ObjectPosition - Target).normalized);
        }
    }

}
