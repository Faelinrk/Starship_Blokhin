using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


public class PoolTest : MonoBehaviour
{
    [SerializeField] private AssetReference assetReferenceToInstantiate = null;
    Stack<GameObject> asteroids = new Stack<GameObject>();
    IEnumerator Start()
    {
        GameObject newObject = null;
        var wait = new WaitForSeconds(1f);
        yield return wait;

        var pool = AddressablesPool.GetPool(assetReferenceToInstantiate);
        for (int i = 0; i < 12; i++)
        {
            yield return wait;
            var newAsteroid = pool.Take(transform);
            yield return wait;
            pool.Return(newAsteroid);
        }
    }
}

