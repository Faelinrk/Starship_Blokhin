using Spaceship.Controllers;
using Spaceship.Interfaces;
using Spaceship.Models;
using Spaceship.Views;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Spaceship.Player
{
    public sealed class UnitFactory
    {
        private ProjectEntrance _projectEntrance;
        private AsyncOperationHandle<GameObject> _currentUnitHandle;
        private GameObject _unitInstance;

        public UnitFactory(ProjectEntrance projectEntrance)
        {
            _projectEntrance = projectEntrance;
        }

        public IEnumerator InstantiateUnit(AssetReference assetReference, IMovable movementModel)
        {
            yield return new WaitForSeconds(1f);
            if (_currentUnitHandle.IsValid())
            {
                Addressables.Release(_currentUnitHandle);
            }
            _currentUnitHandle = assetReference.LoadAssetAsync<GameObject>(); ;
            yield return _currentUnitHandle;
            var unitInstance = assetReference.InstantiateAsync();
            if (unitInstance.Status == AsyncOperationStatus.Succeeded)
            {
                _unitInstance = unitInstance.Result;
                AttachUnitControllers(movementModel);
            }
            
        }

        private void AttachUnitControllers(IMovable movementModel)
        {
            new UnitMovementController(new MovementModel(), _unitInstance.GetComponent<Rigidbody>(), movementModel);
            new DamagebleController(_unitInstance.GetComponent<HealthView>(), _projectEntrance);
        }
    }
}