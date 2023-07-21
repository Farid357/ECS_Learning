using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    public class PlayerMoveSystem : IFixedSystem
    {
        private Filter _filter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<PlayerInputComponent>().With<PhysicsMoveComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref PlayerInputComponent input = ref entity.GetComponent<PlayerInputComponent>();
                ref PhysicsMoveComponent player = ref entity.GetComponent<PhysicsMoveComponent>();
              
                player.Rigidbody.MovePosition(player.Rigidbody.position + input.MoveDirection * player.Speed * Time.fixedDeltaTime);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}