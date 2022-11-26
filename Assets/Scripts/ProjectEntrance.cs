using Spaceship.Interfaces;
using Spaceship.Player;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Spaceship
{
    public class ProjectEntrance : MonoBehaviour
    {
        #region Assets
        [SerializeField] private AssetReference playerPrefab;
        [SerializeField] private AssetReference asteroidPrefab;
        [SerializeField] private AssetReference spaceshipPrefab;
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


        private void Awake()
        {
            InstantiatePools();
            EventOnAwake?.Invoke();
        }

        private void InstantiatePools()
        {
            AsteroidPool = new AddressablesPool(transform, 8, asteroidPrefab);
            AsteroidPool.LoadingCoroutine = StartCoroutine(AsteroidPool.SetupPool());
            StartCoroutine(TakeObject(AsteroidPool));
            
            PlayerFactory = new UnitFactory(this);
            StartCoroutine(PlayerFactory.InstantiateUnit(playerPrefab, new InputMovementModel(this)));
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
        IEnumerator TakeObject (AddressablesPool pool)
        {
            yield return new WaitForSeconds(1f);
            pool.Take(null);
        }
    }
}

