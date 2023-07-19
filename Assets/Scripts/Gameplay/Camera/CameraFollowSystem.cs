using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS_Learning
{
    public class CameraFollowSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly Camera _camera;
      
        private EcsPool<PlayerComponent> _playerPool;
        private EcsFilter _filter;

        public CameraFollowSystem(Camera camera)
        {
            _camera = camera ? camera : throw new ArgumentNullException(nameof(camera));
        }
        
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            
            _filter = world.Filter<PlayerComponent>().End();
            _playerPool = world.GetPool<PlayerComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref PlayerComponent player = ref _playerPool.Get(entity);

                Vector3 position = _camera.transform.position;
                Vector3 nextPosition = Vector3.MoveTowards(position, player.Rigidbody.transform.position + player.FollowOffset, player.CameraFollowSpeed * Time.deltaTime);
            
                _camera.transform.position = nextPosition;
            }
        }
    }
}