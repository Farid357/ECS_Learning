using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS_Learning
{
    public class PlayerRotationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly Camera _camera;
      
        private EcsFilter _filter;
        private EcsPool<PlayerComponent> _pool;

        public PlayerRotationSystem(Camera camera)
        {
            _camera = camera ? camera : throw new ArgumentNullException(nameof(camera));
        }

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            _filter = world.Filter<PlayerComponent>().End();
            _pool = world.GetPool<PlayerComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref PlayerComponent player = ref _pool.Get(entity);

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