using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public sealed class AddressablesPool : IPoolable
{
    private int _elementCount = 8;
    private AssetReference _assetReferenceToInstantiate = null;
    private static Dictionary<string, AddressablesPool> _allAvailablePools = new Dictionary<string, AddressablesPool>();
    private Stack<GameObject> _pool = null;

    public async UniTask BuildAddressablesPoolAsync(int elementCount, AssetReference assetReference)
    {
        _elementCount = elementCount;
        _assetReferenceToInstantiate = assetReference;
        await SetupPoolAsync();
    }
    public static AddressablesPool GetPool(AssetReference assetReference)
    {
        var exists = _allAvailablePools.TryGetValue(assetReference.AssetGUID, out AddressablesPool pool);
        if (exists)
        {
            return pool;
        }
        return null;
    }

    public void Enable()
    {
        _allAvailablePools[_assetReferenceToInstantiate.AssetGUID] = this;
        
    }

    public void Disable()
    {
        _allAvailablePools.Remove(_assetReferenceToInstantiate.AssetGUID);
        foreach (var obj in _pool)
        {
            Addressables.ReleaseInstance(obj);
        }
        _pool = null;
    }

    public async UniTask SetupPoolAsync()
    {
        
        _pool = new Stack<GameObject>(_elementCount);
        for (var i = 0; i < _elementCount; i++)
        {
            AsyncOperationHandle<GameObject> handle = _assetReferenceToInstantiate.InstantiateAsync();
            await handle;
            var newGameObject = handle.Result;
            newGameObject.SetActive(false);
            _pool.Push(newGameObject);
        }
    }

    public GameObject Take()
    {
        if (_pool.Count > 0)
        {
            var newGameObject = _pool.Pop();
            newGameObject.SetActive(true);
            return newGameObject;
        }

        return null;
    }
    public void Return(GameObject gameObjectToReturn)
    {
        gameObjectToReturn.SetActive(false);
        _pool.Push(gameObjectToReturn);
    }
}
