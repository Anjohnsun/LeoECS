using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class ZigzagMovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<ZigzagMovementComponent> _entityPool;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<ZigzagMovementComponent>().End();
            _entityPool = world.GetPool<ZigzagMovementComponent>();

            Debug.Log(_filter.GetEntitiesCount());
            foreach (int entity in _filter)
            {
                _entityPool.Get(entity).ZigzagAmplitude = Random.Range(1, 6);
            }
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                if (_entityPool.Get(entity).MoveRightSite)
                {
                    _entityPool.Get(entity).Transform.position += Vector3.right * _entityPool.Get(entity).Speed * Time.deltaTime;
                }
                else
                {
                    _entityPool.Get(entity).Transform.position += Vector3.forward * _entityPool.Get(entity).Speed * Time.deltaTime;
                }

                _entityPool.Get(entity).MovingProgress += _entityPool.Get(entity).Speed * Time.deltaTime;
                if (_entityPool.Get(entity).MovingProgress > _entityPool.Get(entity).ZigzagAmplitude)
                {
                    _entityPool.Get(entity).MoveRightSite = !_entityPool.Get(entity).MoveRightSite;
                    _entityPool.Get(entity).MovingProgress = 0;
                }
            }
        }
    }
}