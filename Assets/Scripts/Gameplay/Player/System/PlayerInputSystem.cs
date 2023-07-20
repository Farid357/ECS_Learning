using Leopotam.EcsLite;
using UnityEngine;

namespace Game
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter filter = world.Filter<PlayerInput>().End();
            EcsPool<PlayerInput> pool = world.GetPool<PlayerInput>();

            foreach (int entity in filter)
            {
                ref PlayerInput input = ref pool.Get(entity);
                input.MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            }
        }
    }
}