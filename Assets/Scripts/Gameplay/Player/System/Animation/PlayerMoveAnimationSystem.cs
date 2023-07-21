using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    public class PlayerMoveAnimationSystem : ISystem
    {
        private readonly int _horizontal = Animator.StringToHash("Horizontal");
        private readonly int _vertical = Animator.StringToHash("Vertical");

        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<AnimatorComponent>().With<PlayerInputComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref AnimatorComponent player = ref entity.GetComponent<AnimatorComponent>();
                ref PlayerInputComponent input = ref entity.GetComponent<PlayerInputComponent>();

                player.Animator.SetFloat(_horizontal, input.MoveDirection.x);
                player.Animator.SetFloat(_vertical, input.MoveDirection.z);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}