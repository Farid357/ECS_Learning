using UnityEngine;

namespace ECS_Learning
{
    public struct PlayerComponent
    {
        public Rigidbody Rigidbody { get; set; }

        public float Speed { get; set; }
        
        public Animator Animator { get; set; }
       
        public Vector3 FollowOffset { get; set; }
       
        public float CameraFollowSpeed { get; set; }
    }
}