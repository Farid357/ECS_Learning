using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private readonly Camera _camera;
        public CameraFollowSystem(Camera camera)
        {
            _camera = camera ? camera : throw new ArgumentNullException(nameof(camera));
        }
        
        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter filter = world.Filter<PlayerComponent>().End();
            EcsPool<PlayerComponent> playerPool = world.GetPool<PlayerComponent>();

            foreach (int entity in filter)
            {
                ref PlayerComponent player = ref playerPool.Get(entity);

                Vector3 position = _camera.transform.position;
                Vector3 nextPosition = Vector3.MoveTowards(position, player.Rigidbody.transform.position + player.FollowOffset, player.CameraFollowSpeed * Time.deltaTime);
            
                _camera.transform.position = nextPosition;
            }
        }
    }
}