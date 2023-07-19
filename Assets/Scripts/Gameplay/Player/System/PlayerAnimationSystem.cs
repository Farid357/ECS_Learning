using Leopotam.EcsLite;
using UnityEngine;

namespace ECS_Learning
{
    public class PlayerAnimationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly int _horizontal = Animator.StringToHash("Horizontal");
        private readonly int _vertical = Animator.StringToHash("Vertical");
      
        private EcsPool<PlayerComponent> _pool;
        private EcsPool<PlayerInput> _inputPool;
        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<PlayerComponent>().Inc<PlayerInput>().End();
            _pool = world.GetPool<PlayerComponent>();
            _inputPool = world.GetPool<PlayerInput>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref PlayerComponent player = ref _pool.Get(entity);
                ref PlayerInput input = ref _inputPool.Get(entity);
                
                player.Animator.SetFloat(_horizontal, input.MoveDirection.x);
                player.Animator.SetFloat(_vertical, input.MoveDirection.z);
            }
        }
    }
}