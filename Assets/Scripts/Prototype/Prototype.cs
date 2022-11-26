using System;
using UnityEngine;

namespace Spaceship
{
    public class Prototype : ICloneable
    {
        private GameObject _prototype;
        public Prototype(GameObject prototype)
        {
            _prototype = prototype;
        }
        public object Clone()
        {
            GameObject clone = new GameObject();
            clone.name = _prototype.name;
            var components = _prototype.GetComponents<Component>();
            for(int componentIndex = 0; componentIndex < components.Length; componentIndex++)
            {
                UnityEditorInternal.ComponentUtility.CopyComponent(components[componentIndex]);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(clone);
            }
            return clone;
        }
    }
}
