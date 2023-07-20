using Leopotam.EcsLite;
using UnityEngine;

namespace Game
{
    public class PlayerAnimationSystem : IEcsRunSystem
    {
        private readonly int _horizontal = Animator.StringToHash("Horizontal");
        private readonly int _vertical = Animator.StringToHash("Vertical");

        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter filter = world.Filter<PlayerComponent>().Inc<PlayerInput>().End();
            EcsPool<PlayerComponent> pool = world.GetPool<PlayerComponent>();
            EcsPool<PlayerInput> inputPool = world.GetPool<PlayerInput>();

            foreach (int entity in filter)
            {
                ref PlayerComponent player = ref pool.Get(entity);
                ref PlayerInput input = ref inputPool.Get(entity);
                
                player.Animator.SetFloat(_horizontal, input.MoveDirection.x);
                player.Animator.SetFloat(_vertical, input.MoveDirection.z);
            }
        }
    }
}