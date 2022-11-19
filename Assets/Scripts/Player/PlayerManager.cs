using Spaceship.Controllers;
using Spaceship.Models;
using Spaceship.Views;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Spaceship.Player
{
    public sealed class PlayerManager : IDisposable
    {
        public const string PlayerPrefabKey = "Player";
        private ProjectEntrance _projectEntrance;
        private AsyncOperationHandle<GameObject> _currentPlayerHandle; // descriptor
        private GameObject _playerInstance;
        public event Action<Vector3> OnPlayerUpdatePosition;

        public PlayerManager(ProjectEntrance projectEntrance)
        {
            _projectEntrance = projectEntrance;
            _projectEntrance.EventOnUpdate += ActualizePlayerPosition;
        }

        public IEnumerator InstantiatePlayer()
        {
            if (_currentPlayerHandle.IsValid())
            {
                Addressables.Release(_currentPlayerHandle);
            }
            _currentPlayerHandle = Addressables.LoadAssetAsync<GameObject>(PlayerPrefabKey); ;
            yield return _currentPlayerHandle;
            var playerInstance = Addressables.InstantiateAsync(PlayerPrefabKey);
            if (playerInstance.Status == AsyncOperationStatus.Succeeded)
            {
                _playerInstance = playerInstance.Result;
                AttachPlayerControllers();
            }
            
        }

        private void AttachPlayerControllers()
        {
            new PlayerMovementController(new MovementModel(), _playerInstance.GetComponent<Rigidbody>(), _projectEntrance);
            new DamagebleController(_playerInstance.GetComponent<HealthView>(), _projectEntrance);
        }

        private void ActualizePlayerPosition()
        {
            OnPlayerUpdatePosition?.Invoke(_playerInstance.transform.position);
        }

        public void Dispose()
        {
            _projectEntrance.EventOnUpdate -= ActualizePlayerPosition;
        }
    }
}