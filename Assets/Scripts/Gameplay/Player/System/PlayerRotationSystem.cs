using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game
{
    public class PlayerRotationSystem : IEcsRunSystem
    {
        private readonly Camera _camera;

        public PlayerRotationSystem(Camera camera)
        {
            _camera = camera ? camera : throw new ArgumentNullException(nameof(camera));
        }

        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter filter = world.Filter<PlayerComponent>().End();
            EcsPool<PlayerComponent> pool = world.GetPool<PlayerComponent>();

            foreach (int entity in filter)
            {
                ref PlayerComponent player = ref pool.Get(entity);

                Plane plane = new Plane(Vector3.up, player.Rigidbody.position);
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (plane.Raycast(ray, out float enter))
                {
                    player.Rigidbody.transform.forward = ray.GetPoint(enter) - player.Rigidbody.position;
                }
            }
        }
    }
}