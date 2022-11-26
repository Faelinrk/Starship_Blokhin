using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressablesPool
{
    public Coroutine LoadingCoroutine;
    private int _elementCount = 8;
    private AssetReference _assetReferenceToInstantiate = null;
    public bool IsReady { get { return LoadingCoroutine == null; } }
    private static Dictionary<object, AddressablesPool> allAvailablePools = new Dictionary<object, AddressablesPool>();
    private Stack<GameObject> _pool = null;
    private Transform _transform;

    public AddressablesPool(Transform parentTransform, int elementCount, AssetReference assetReference)
    {
        _transform = parentTransform;
        _elementCount = elementCount;
        _assetReferenceToInstantiate = assetReference;
    }
    public static AddressablesPool GetPool(AssetReference assetReference)
    {
        var exists = allAvailablePools.TryGetValue(assetReference.RuntimeKey, out AddressablesPool pool);
        if (exists)
        {
            return pool;
        }
        return null;
    }
    public GameObject Take(Transform parent)
    {
        if (IsReady == false) return null;
        if (_pool.Count > 0)
        {
            var newGameObject = _pool.Pop();
            newGameObject.transform.SetParent(parent, false);
            newGameObject.SetActive(true);
            return newGameObject;
        }

        return null;
    }
    public void Return(GameObject gameObjectToReturn)
    {
        gameObjectToReturn.SetActive(false);
        gameObjectToReturn.transform.parent = _transform;
        _pool.Push(gameObjectToReturn);
    }

    void OnEnable()
    {
        allAvailablePools[_assetReferenceToInstantiate.RuntimeKey] = this;
        
    }

    void OnDisable()
    {
        allAvailablePools.Remove(_assetReferenceToInstantiate);
        foreach (var obj in _pool)
        {
            Addressables.ReleaseInstance(obj);
        }
        _pool = null;
    }

    public IEnumerator SetupPool()
    {
        _pool = new Stack<GameObject>(_elementCount);
        for (var i = 0; i < _elementCount; i++)
        {
            var handle = _assetReferenceToInstantiate.InstantiateAsync(_transform);
            yield return handle;
            var newGameObject = handle.Result;
            _pool.Push(newGameObject);
            newGameObject.SetActive(false);
        }

        LoadingCoroutine = null;
    }

}
