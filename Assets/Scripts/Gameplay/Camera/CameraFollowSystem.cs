using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    public class CameraFollowSystem : ISystem
    {
        private Filter _playerFilter;
        private Filter _cameraFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _cameraFilter = World.Filter.With<CameraComponent>();
            _playerFilter = World.Filter.With<PhysicsMoveComponent>().With<PlayerInputComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            Rigidbody rigidbody = null;
            
            foreach (Entity entity in _playerFilter)
            {
                ref PhysicsMoveComponent moveComponent = ref entity.GetComponent<PhysicsMoveComponent>();
                rigidbody = moveComponent.Rigidbody;
            }

            foreach (Entity entity in _cameraFilter)
            {
                ref CameraComponent component = ref entity.GetComponent<CameraComponent>();
                Camera camera = component.Camera;
                Vector3 position = camera.transform.position;
                Vector3 nextPosition = Vector3.MoveTowards(position, rigidbody.transform.position + component.FollowOffset, component.FollowSpeed * Time.deltaTime);
                camera.transform.position = nextPosition;
            }
        }

        public void Dispose()
        {
            _playerFilter = null;
        }
    }
}