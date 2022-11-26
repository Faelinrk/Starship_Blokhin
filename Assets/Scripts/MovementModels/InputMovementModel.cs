using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spaceship.Interfaces
{
    public class InputMovementModel : IMovable, IDisposable
    {
        public event Action<Vector3> OnMovementInputChanged;
        public ProjectEntrance ProjectEntrance;
        public const string Vertical = "Vertical";
        public const string Horizontal = "Horizontal";

        public InputMovementModel(ProjectEntrance projectEntrance)
        {
            ProjectEntrance = projectEntrance;
            ProjectEntrance.EventOnUpdate += InputControl;
        }
        private void InputControl()
        {
            float horizintal = Input.GetAxis(Horizontal);
            float vertical = Input.GetAxis(Vertical);
            if (horizintal != 0 || vertical != 0)
            {
                OnMovementInputChanged(new Vector3(horizintal, vertical, 0));
            }
        }
        public void ChangeAccel(Vector3 position, Vector3 target)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            ProjectEntrance.EventOnUpdate -= InputControl;
        }
    }

}
