using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    public class PlayerShootAnimationSystem : ISystem
    {
        private readonly int _isShooting = Animator.StringToHash("IsShooting");
        
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<AnimatorComponent>().With<PlayerInputComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            Animator animator = null;
            bool isShooting = false;

            foreach (Entity entity in _filter)
            {
                ref AnimatorComponent animatorComponent = ref entity.GetComponent<AnimatorComponent>();
                ref PlayerInputComponent input = ref entity.GetComponent<PlayerInputComponent>();
                animator = animatorComponent.Animator;

                if (input.IsShooting)
                {
                    isShooting = true;
                    break;
                }
            }

            animator?.SetBool(_isShooting, isShooting);
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}