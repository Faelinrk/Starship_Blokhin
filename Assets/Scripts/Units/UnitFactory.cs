using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Spaceship.Player
{
    public sealed class UnitFactory
    {
        private AsyncOperationHandle<GameObject> _currentUnitHandle;
        private GameObject _unitInstance;

        public async UniTask<GameObject> InstantiateUnit(AssetReference assetReference)
        {
            if (_currentUnitHandle.IsValid())
            {
                Addressables.Release(_currentUnitHandle);
            }
            _currentUnitHandle = assetReference.LoadAssetAsync<GameObject>();
            var unitInstance = assetReference.InstantiateAsync();
            await unitInstance;
            if (unitInstance.Status == AsyncOperationStatus.Succeeded)
            {
                _unitInstance = unitInstance.Result;
            }
            return _unitInstance;
        }
    }
}