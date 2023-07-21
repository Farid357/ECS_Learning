using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    public class PlayerRotationSystem : ISystem
    {
        private Camera _camera;
        private Filter _filter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<PhysicsMoveComponent>();
            _camera = Camera.main;
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref PhysicsMoveComponent player = ref entity.GetComponent<PhysicsMoveComponent>();
                Plane plane = new Plane(Vector3.up, player.Rigidbody.position);
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (plane.Raycast(ray, out float enter))
                {
                    player.Rigidbody.transform.forward = ray.GetPoint(enter) - player.Rigidbody.position;
                }
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}