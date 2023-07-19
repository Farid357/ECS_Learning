using UnityEngine;

namespace ECS_Learning
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

        [field: SerializeField] public float Speed { get; private set; }
        
        [field: SerializeField] public Animator Animator { get; private set; }
        
       
        [field: SerializeField] public Vector3 FollowOffset { get; private set; }

        [field: SerializeField] public float CameraFollowSpeed { get; private set; } = 1.5f;


    }
}