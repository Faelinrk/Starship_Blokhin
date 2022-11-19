using Spaceship.Controllers;
using Spaceship.Models;
using Spaceship.Views;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Spaceship.Enemies
{
    public sealed class EnemyFactory
    {
        private ProjectEntrance _projectEntrance;
        private AsyncOperationHandle<GameObject> _currentEnemyHandle;
        public IEnumerator InstantiateEnemy(Enemy enemy)
        {
            if (_currentEnemyHandle.IsValid())
            {
                Addressables.Release(_currentEnemyHandle);
            }
            _currentEnemyHandle = Addressables.LoadAssetAsync<GameObject>(enemy.PrefabKey);
            yield return _currentEnemyHandle;
            var enemyInstance = Addressables.InstantiateAsync(enemy.PrefabKey);
            if (enemyInstance.Status == AsyncOperationStatus.Succeeded)
            {
                AttachEnemyControllers(enemyInstance.Result);
            }
            yield return null;
        }

        private void AttachEnemyControllers(GameObject enemy)
        {
            new EnemyMovementController(new MovementModel(), enemy.GetComponent<Rigidbody>(), _projectEntrance);
            new DamagebleController(enemy.GetComponent<HealthView>(), _projectEntrance);
        }
    }

}
