using Leopotam.EcsLite;
using UnityEngine;

namespace Game
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter filter = world.Filter<PlayerInput>().Inc<PlayerComponent>().End();
            EcsPool<PlayerComponent> pool = world.GetPool<PlayerComponent>();
            EcsPool<PlayerInput> inputPool = world.GetPool<PlayerInput>();

            foreach (int entity in filter)
            {
                ref PlayerInput input = ref inputPool.Get(entity);
                ref PlayerComponent player = ref pool.Get(entity);

                player.Rigidbody.MovePosition(player.Rigidbody.position + input.MoveDirection * player.Speed * Time.fixedDeltaTime);
            }
        }
    }
}