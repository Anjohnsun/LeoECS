using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class BallGenerationSystem : IEcsPreInitSystem
    {
        private GameObject _prefab;
        private int _prefabNumber;

        public BallGenerationSystem(GameObject prefab, int prefabNumber)
        {
            _prefab = prefab;
            _prefabNumber = prefabNumber;
        }
        public void PreInit(IEcsSystems systems)
        {
            for(int i = 0; i < _prefabNumber; i++)
            {
                GameObject.Instantiate(_prefab, new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);
            }
        }
    }
}