using Leopotam.EcsLite;
using UnityEngine;

namespace ECS_Learning
{
    public class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<PlayerInput> _pool;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
          
            _filter = world.Filter<PlayerInput>().End();
            _pool = world.GetPool<PlayerInput>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref PlayerInput input = ref _pool.Get(entity);
                input.MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            }
        }
    }
}