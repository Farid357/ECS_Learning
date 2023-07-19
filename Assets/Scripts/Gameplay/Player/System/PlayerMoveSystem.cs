using Leopotam.EcsLite;
using UnityEngine;

namespace ECS_Learning
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter filter = world.Filter<PlayerInput>().Inc<PlayerComponent>().End();

            foreach (int entity in filter)
            {
                ref PlayerInput input = ref world.GetPool<PlayerInput>().Get(entity);
                ref PlayerComponent player = ref world.GetPool<PlayerComponent>().Get(entity);

                player.Rigidbody.MovePosition(player.Rigidbody.position + input.MoveDirection * player.Speed * Time.fixedDeltaTime);
            }
        }
    }
}