using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    public class PlayerInputSystem : ISystem
    {
        private Filter _filter;
  
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<PlayerInputComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref PlayerInputComponent input = ref entity.GetComponent<PlayerInputComponent>();
                input.MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                input.IsShooting = Input.GetMouseButtonDown(0);
            }
        }

        public void Dispose()
        {
        //    _filter = null;
        }
    }
}