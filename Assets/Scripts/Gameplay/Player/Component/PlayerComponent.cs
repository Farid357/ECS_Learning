using UnityEngine;

namespace ECS_Learning
{
    public struct PlayerComponent
    {
        public Rigidbody Rigidbody { get; set; }

        public float Speed { get; set; }
    }
}