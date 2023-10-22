using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class CounterRunSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<CountComponent> _entityPool; 
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<CountComponent>().End();
            _entityPool = world.GetPool<CountComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach(int entity in _filter)
            {
                ref CountComponent testComponent = ref _entityPool.Get(entity);
                //ref int counter = ref testComponent.Counter;
                //counter++;
                //Debug.Log(counter);
                _entityPool.Get(entity).Transform.position += Vector3.forward;
            }
        }
    }
}