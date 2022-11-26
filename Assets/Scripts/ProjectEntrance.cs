using Cysharp.Threading.Tasks;
using Spaceship.Player;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Spaceship
{
    public sealed class ProjectEntrance : MonoBehaviour
    {
        #region Assets
        [SerializeField] private AssetReference _playerPrefab;
        [SerializeField] private AssetReference _asteroidPrefab;
        [SerializeField] private AssetReference _spaceshipPrefab;
        #endregion

        #region Events
        public event Action EventOnAwake;
        public event Action EventOnStart;
        public event Action EventOnDisable;
        public event Action EventOnUpdate;
        #endregion

        #region Managers
        public UnitFactory PlayerFactory;
        public AddressablesPool AsteroidPool;
        #endregion

        #region Objects

        #endregion

        private void Awake()
        {
            TestPoolsAndPatterns();
            EventOnAwake?.Invoke();
        }

        private void Start()
        {
            EventOnStart?.Invoke();
        }
        private void OnDisable()
        {
            EventOnDisable?.Invoke();
        }

        private void Update()
        {
            EventOnUpdate?.Invoke();
        }

        private async UniTask TestPoolsAndPatterns()
        {
            AsteroidPool = new AddressablesPool();
            await AsteroidPool.BuildAddressablesPoolAsync(8, _asteroidPrefab);
            GameObject asteroid = AsteroidPool.Take();
            PlayerFactory = new UnitFactory();
            GameObject _playerInstance = await PlayerFactory.InstantiateUnit(_playerPrefab);
            var asteroidPrototype = new Prototype(asteroid);
            asteroidPrototype.Clone();
            GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Capsule)
                .AddRigidbody(true)
                .AddCollider();
            bullet.name = "Bullet";
        }
    }
}

