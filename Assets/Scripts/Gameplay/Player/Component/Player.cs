using UnityEngine;

namespace ECS_Learning
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

        [field: SerializeField] public float Speed { get; private set; }
    }
}