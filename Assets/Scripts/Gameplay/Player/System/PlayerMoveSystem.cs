using Leopotam.EcsLite;
using UnityEngine;

namespace ECS_Learning
{
    public class PlayerMoveSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<PlayerInput> _inputPool;
        private EcsPool<PlayerComponent> _pool;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
          
            _filter = world.Filter<PlayerInput>().Inc<PlayerComponent>().End();
            _pool = world.GetPool<PlayerComponent>();
            _inputPool = world.GetPool<PlayerInput>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref PlayerInput input = ref _inputPool.Get(entity);
                ref PlayerComponent player = ref _pool.Get(entity);

                player.Rigidbody.MovePosition(player.Rigidbody.position + input.MoveDirection * player.Speed * Time.fixedDeltaTime);
            }
        }
    }
}