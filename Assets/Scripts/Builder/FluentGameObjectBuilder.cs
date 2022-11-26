using UnityEngine;

namespace Spaceship
{
    public static class FluentGameObjectBuilder
    {
        public static GameObject AddRigidbody(this GameObject gameObject, bool useGravity)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody>();
            component.useGravity = useGravity;
            return gameObject;
        }

        public static GameObject AddCollider(this GameObject gameObject)
        {
            var component = gameObject.GetOrAddComponent<BoxCollider>();
            return gameObject;
        }

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>()?
                gameObject.GetComponent<T>():
                gameObject.AddComponent<T>();
            return component;
        }

    }
}